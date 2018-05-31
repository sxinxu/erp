using erpcore.entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using NLog;

namespace erpcore
{
    public class EbayService
    {
        private const string url = "https://api.ebay.com/ws/api.dll";
        private const string ebayNs = "{urn:ebay:apis:eBLBaseComponents}";

        private const string devId = "8dc6ba1f-5567-41d5-9bd1-63b69431ae11";
        private const string appId = "XinXu6b4b-d44f-493b-8a83-7fd2be893ea";
        private const string certId = "60f3aa83-8c15-4a31-ad3f-986cd05324e9";
        private Dictionary<string, string> m_ebayTokenDictionary = new Dictionary<string, string>();
        private static Logger m_logger = NLog.LogManager.GetCurrentClassLogger();

        public EbayService()
        {
            using (v3_allContext context = new v3_allContext())
            {
                var q = from ebayAccount in context.EbayAccount
                        select ebayAccount;
                foreach(var row in q)
                {
                    m_ebayTokenDictionary[row.EbayAccount1] = row.EbayToken;
                }
            }
        }

        public void GetSellerList( string ebayAccount )
        {
            
            DateTime startTimeTo = DateTime.Now;
            DateTime startTimeFrom = DateTime.Now.AddDays(-120);
            Dictionary<string, EbayList> ebayListDictionary = new Dictionary<string, EbayList>();
            Dictionary<string, List<EbayListvariations>> ebayListVariationDictionary = new Dictionary<string, List<EbayListvariations>>();

            using (v3_allContext context = new v3_allContext())
            {
                var q = from ebayList in context.EbayList
                        where ebayList.EbayAccount == ebayAccount
                        select ebayList;
                foreach (var listing in q)
                {
                    ebayListDictionary[listing.ItemId] = listing;
                }

                var q1 = from ebayListVariations in context.EbayListvariations
                         where ebayListVariations.EbayAccount == ebayAccount
                         select ebayListVariations;
                foreach (var ebayListVariation in q1)
                {
                    List<EbayListvariations> listVariations = null;
                    if (ebayListVariationDictionary.ContainsKey(ebayListVariation.Itemid))
                    {
                        listVariations = ebayListVariationDictionary[ebayListVariation.Itemid];
                    }
                    else
                    {
                        listVariations = new List<EbayListvariations>();
                    }
                    listVariations.Add(ebayListVariation);
                }

                for (int i = 0; i < 6; i++)
                {
                    int currentPage = 0;
                    string startTimeToString = startTimeTo.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
                    string startTimeFromString = startTimeFrom.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
                    while (true)
                    {
                        XElement input = new XElement(ebayNs + "GetSellerListRequest",
                        new XElement(ebayNs + "StartTimeFrom", startTimeFromString),
                        new XElement(ebayNs + "StartTimeTo", startTimeToString),
                        new XElement(ebayNs + "DetailLevel", "ItemReturnDescription"),
                        new XElement(ebayNs + "IncludeVariations"),
                        new XElement(ebayNs + "OutputSelector", "PaginationResult"),
                        new XElement(ebayNs + "OutputSelector", "PageNumber"),
                        new XElement(ebayNs + "OutputSelector", "ItemID"),
                        new XElement(ebayNs + "OutputSelector", "SKU"),
                        new XElement(ebayNs + "OutputSelector", "Title"),
                        new XElement(ebayNs + "OutputSelector", "ListingType"),
                        new XElement(ebayNs + "OutputSelector", "TimeLeft"),
                        new XElement(ebayNs + "OutputSelector", "Quantity"),
                        new XElement(ebayNs + "OutputSelector", "GalleryURL"),
                        new XElement(ebayNs + "OutputSelector", "Location"),
                        new XElement(ebayNs + "OutputSelector", "ViewItemURL"),
                        new XElement(ebayNs + "OutputSelector", "PayPalEmailAddress"),
                        new XElement(ebayNs + "Pagination",
                            new XElement(ebayNs + "EntriesPerPage", 100)));
                        AddCredentials(ebayAccount, input);
                        if (currentPage > 0)
                        {
                            input.Element(ebayNs + "Pagination").Add(new XElement(ebayNs + "PageNumber", currentPage));
                        }
                        XElement output = MakeCall("GetSellerList", input);

                        int totalPages = (int)output.Element(ebayNs + "PaginationResult").Element(ebayNs + "TotalNumberOfPages");

                        IEnumerable<XElement> items = output.Descendants(ebayNs + "Item");
                        foreach (XElement item in items)
                        {
                            string itemId = (string)item.Element(ebayNs + "ItemID");
                            if (ebayListDictionary.ContainsKey(itemId))
                            {
                                ebayListDictionary.Remove(itemId);
                                ebayListVariationDictionary.Remove(itemId);
                            }
                            else
                            {
                                AddItem(context, item);
                            }
                        }
                        currentPage = (int)output.Element(ebayNs + "PageNumber");

                        if (currentPage >= totalPages)
                        {
                            break;
                        }
                        currentPage++;
                    }
                    startTimeTo = startTimeFrom;
                    startTimeFrom = startTimeTo.AddDays(-120);
                }

                foreach (string itemId in ebayListDictionary.Keys)
                {
                    context.EbayList.Remove(ebayListDictionary[itemId]);
                    foreach (var row in ebayListVariationDictionary[itemId])
                    {
                        context.EbayListvariations.Remove(row);
                    }
                }

                context.SaveChanges();
            }
        }

        public void GetItem(string ebayAccount, string itemId)
        {
            XElement input = new XElement(ebayNs + "GetItemRequest",
                new XElement(ebayNs+"ItemID", itemId));
            AddCredentials(ebayAccount, input);
            XElement output = MakeCall("GetItem", input);
        }

        private void AddItem(v3_allContext context, XElement item)
        {
            EbayList listing = new EbayList();
            listing.ItemId = (string)item.Element(ebayNs + "ItemID"); ;
            listing.Sku = (string)item.Element(ebayNs + "SKU");
            listing.Title = (string)item.Element(ebayNs + "Title");
            listing.ListingType = (string)item.Element(ebayNs + "ListingType");
            listing.TimeLeft = (string)item.Element(ebayNs + "TimeLeft");
            listing.Quantity = (string)item.Element(ebayNs + "Quantity");
            listing.GalleryUrl = (string)item.Element(ebayNs + "PictureDetails").Element(ebayNs + "GalleryURL");
            listing.Location = (string)item.Element(ebayNs + "Location");
            listing.ViewItemUrl = (string)item.Element(ebayNs + "ListingDetails").Element(ebayNs + "ViewItemURL");
            listing.EbayAccount = (string)item.Element(ebayNs + "Seller").Element(ebayNs + "UserID");
            listing.EbayUser = "vipadmin";
            listing.PayPalEmailAddress = (string)item.Element(ebayNs + "PayPalEmailAddress");
            listing.Active = true;
            context.EbayList.Add(listing);

            IEnumerable<XElement> variations = item.Descendants(ebayNs + "Variation");
            if (variations != null && variations.Count() > 0)
            {
                foreach( XElement variation in variations)
                {
                    EbayListvariations listVariation = new EbayListvariations();
                    listVariation.Sku = (string)variation.Element(ebayNs + "SKU");
                    listVariation.Quantity = (string)variation.Element(ebayNs + "Quantity");
                    listVariation.Itemid = listing.ItemId;
                    listVariation.EbayAccount = listing.EbayAccount;
                    listVariation.EbayUser = "vipadmin";
                    context.EbayListvariations.Add(listVariation);
                }
            }
        }

        public void ReviseListingQuantity( string ebayAccount, string itemId, int quantity)
        {
            XElement input = new XElement(ebayNs + "ReviseFixedPriceItemRequest");
            XElement itemElement = new XElement(ebayNs + "Item",
                new XElement(ebayNs + "ItemID", itemId),
                new XElement(ebayNs+"Quantity", quantity));
            input.Add(itemElement);
            AddCredentials(ebayAccount, input);
            
            MakeCall("ReviseFixedPriceItem", input);
        }

        public void ReviseVariationQuantity(string ebayAccount, string itemId, string sku, int quantity)
        {
            XElement input = new XElement(ebayNs + "ReviseFixedPriceItemRequest");
            XElement itemElement = new XElement(ebayNs + "Item",
                new XElement(ebayNs + "ItemID", itemId),
                new XElement(ebayNs+ "Variations",
                    new XElement(ebayNs+ "Variation",
                        new XElement(ebayNs+"SKU", sku),
                        new XElement(ebayNs+"Quantity", quantity)
                    )));
            input.Add(itemElement);
            AddCredentials(ebayAccount, input);

            MakeCall("ReviseFixedPriceItem", input);
        }

        public void GetOrder(string ebayAccount, string orderId)
        {
            XElement input = new XElement(ebayNs + "GetOrdersRequest",
                                new XElement(ebayNs+"DetailLevel", "ReturnAll"),
                                new XElement(ebayNs + "OrderIDArray",
                                    new XElement(ebayNs + "OrderID", orderId)));
            AddCredentials(ebayAccount, input);
            XElement output = MakeCall("GetOrders", input);
        }

        public void ProcessGetOrdersResponse( XElement output)
        {
            using (v3_allContext context = new v3_allContext())
            {
                IEnumerable<XElement> orders = output.Descendants(ebayNs + "Order");
                foreach (XElement orderElement in orders)
                {
                    string orderId = (string)orderElement.Element(ebayNs + "OrderID");
                    XElement firstTransactionElement = orderElement.Element(ebayNs + "TransactionArray").Element(ebayNs + "Transaction");
                    var query = from order in context.EbayOrder
                                where order.EbayOrdersn == orderId
                                select order;
                    if (query.Count() == 0)
                    {
                        EbayOrder ebayOrder = new EbayOrder();
                        ebayOrder.EbayPaystatus = (string)orderElement.Element(ebayNs + "CheckoutStatus").Element(ebayNs + "eBayPaymentStatus");
                        ebayOrder.EbayOrdersn = orderId;
                        XElement externalTransactionElement = orderElement.Element(ebayNs + "ExternalTransaction");
                        if (externalTransactionElement != null)
                        {
                            ebayOrder.EbayPtid = (string)externalTransactionElement.Element(ebayNs + "ExternalTransactionID");
                        }
                        ebayOrder.EbayOrderid = orderId;
                        string createdTime = (string)orderElement.Element(ebayNs + "CreatedTime");
                        ebayOrder.EbayCreatedtime = DateUtils.ConvertToUnixTime(DateTime.Parse(createdTime));
                        ebayOrder.EbayPaidtime = ebayOrder.EbayCreatedtime.ToString();
                        ebayOrder.EbayAddtime = ebayOrder.EbayCreatedtime;
                        XElement buyer = firstTransactionElement.Element(ebayNs + "Buyer");
                        ebayOrder.EbayUserid = (string)orderElement.Element(ebayNs + "BuyerUserID");

                        XElement shippingAddress = orderElement.Element(ebayNs + "ShippingAddress");
                        ebayOrder.EbayUsername = (string)shippingAddress.Element(ebayNs + "Name");
                        ebayOrder.EbayUsermail = (string)buyer.Element(ebayNs + "Email");
                        ebayOrder.EbayStreet = (string)shippingAddress.Element(ebayNs + "Street1");
                        ebayOrder.EbayStreet1 = (string)shippingAddress.Element(ebayNs + "Street2");
                        ebayOrder.EbayCity = (string)shippingAddress.Element(ebayNs + "CityName");
                        ebayOrder.EbayState = (string)shippingAddress.Element(ebayNs + "StateOrProvince");
                        ebayOrder.EbayCouny = (string)shippingAddress.Element(ebayNs + "Country");
                        ebayOrder.EbayCountryname = (string)shippingAddress.Element(ebayNs + "CountryName");
                        if (ebayOrder.EbayCountryname == "US")
                        {
                            ebayOrder.EbayCountryname = "United States";
                        }
                        ebayOrder.EbayPostcode = (string)shippingAddress.Element(ebayNs + "PostalCode");
                        ebayOrder.EbayPhone = (string)shippingAddress.Element(ebayNs + "Phone");
                        ebayOrder.EbayCurrency = (string)orderElement.Element(ebayNs + "AmountPaid").Attribute(ebayNs + "currencyID");
                        ebayOrder.EbayTotal = Convert.ToDouble((string)orderElement.Element(ebayNs + "Total"));
                        ebayOrder.Status = "0";
                        ebayOrder.EbayCarrier2 = "";
                        ebayOrder.EbayTracknumber2 = "";
                        ebayOrder.IsYichang = "0";
                        ebayOrder.Ishide = 0;
                        ebayOrder.EbayCombine = "0";
                        ebayOrder.EbayStatus = 1;
                        ebayOrder.EbayUser = "vipadmin";
                        ebayOrder.EbayAccount = (string)orderElement.Element(ebayNs + "SellerUserID");
                        ebayOrder.EbayAccount2 = ebayOrder.EbayAccount;
                        ebayOrder.Recordnumber = (string)orderElement.Element(ebayNs + "ShippingDetails").Element(ebayNs + "SellingManagerSalesRecordNumber");
                        ebayOrder.EbayNote = (string)orderElement.Element(ebayNs + "BuyerCheckoutMessage");
                        ebayOrder.EBayPaymentStatus = (string)orderElement.Element(ebayNs + "CheckoutStatus").Element(ebayNs + "eBayPaymentStatus");
                        double feeOrCreditAmount = Convert.ToDouble((string)orderElement.Element(ebayNs+ "MonetaryDetails").Element(ebayNs + "Payments").Element(ebayNs + "Payment").Element(ebayNs + "FeeOrCreditAmount"));

                        context.EbayOrder.Add(ebayOrder);

                        IEnumerable<XElement> transactions = orderElement.Descendants(ebayNs + "Transaction");
                        foreach (XElement transaction in transactions)
                        {
                            string recordNumber = (string)transaction.Element(ebayNs + "ShippingDetails").Element(ebayNs + "SellingManagerSalesRecordNumber");
                            EbayOrderdetail ebayOrderdetail = ebayOrderdetail = new EbayOrderdetail();
                            ebayOrderdetail.OrderLineItemId = (string)transaction.Element(ebayNs + "OrderLineItemID"); ;
                            ebayOrderdetail.EbayOrdersn = orderId;
                            ebayOrderdetail.Recordnumber = recordNumber;
                            ebayOrderdetail.EbayItemprice = (string)transaction.Element(ebayNs + "TransactionPrice");
                            ebayOrderdetail.EbayAmount = (string)transaction.Element(ebayNs + "QuantityPurchased");
                            ebayOrderdetail.EbayCreatedtime = DateUtils.ConvertToUnixTime(DateTime.Now);
                            XElement shippingServiceSelectedElement = transaction.Element(ebayNs + "ShippingServiceSelected");
                            if (shippingServiceSelectedElement != null)
                            {
                                ebayOrderdetail.EbayShiptype = (string)shippingServiceSelectedElement.Element(ebayNs + "ShippingService");
                            }
                            ebayOrderdetail.EbayUser = "vipadmin";

                            XElement item = transaction.Element(ebayNs + "Item");
                            ebayOrderdetail.EbayItemid = (string)item.Element(ebayNs + "ItemID");
                            ebayOrderdetail.EbayItemtitle = (string)item.Element(ebayNs + "Title");
                            ebayOrderdetail.EbayItemurl = (string)item.Element(ebayNs + "ListingDetails").Element(ebayNs + "ViewItemURL");
                            ebayOrderdetail.Sku = (string)item.Element(ebayNs + "SKU");
                            if (ebayOrderdetail.Sku == null)
                            {
                                ebayOrderdetail.Sku = "";
                            }
                            ebayOrderdetail.Shipingfee = (string)transaction.Element(ebayNs + "ActualShippingCost");
                            ebayOrderdetail.EbayAccount = ebayOrder.EbayAccount;
                            ebayOrderdetail.Addtime = DateUtils.ConvertToUnixTime(DateTime.Now).ToString();
                            ebayOrderdetail.EbayTid = (string)transaction.Element(ebayNs + "TransactionID");
                            double transactionPrice = Convert.ToDouble((string)transaction.Element(ebayNs + "TransactionPrice"));
                            double actualShippingCost = Convert.ToDouble((string)transaction.Element(ebayNs + "ActualShippingCost"));
                            ebayOrderdetail.FeeOrCreditAmount = (feeOrCreditAmount*(transactionPrice+actualShippingCost)/ebayOrder.EbayTotal).ToString();
                            ebayOrderdetail.FinalValueFee = float.Parse((string)transaction.Element(ebayNs + "FinalValueFee"));
                            ebayOrderdetail.PayPalEmailAddress = (string)transaction.Element(ebayNs + "PayPalEmailAddress");
                            ebayOrderdetail.ListingType = (string)item.Element(ebayNs + "ListingType");
                            context.EbayOrderdetail.Add(ebayOrderdetail);
                        }
                    }
                }

                context.SaveChanges();

            }
        }

        public void ProcessAuctionCheckoutComplete(XElement element)
        {
            using (v3_allContext context = new v3_allContext())
            {
                XElement item = element.Element(ebayNs + "Item");
                string accountName = item.Element(ebayNs + "Seller").Element(ebayNs + "UserID").Value;
                IEnumerable<XElement> transactions = element.Descendants(ebayNs + "Transaction");
                foreach (XElement transaction in transactions)
                {
                    string orderId = (string)transaction.Element(ebayNs + "ContainingOrder").Element(ebayNs + "OrderID");
                    string orderLineItemId = (string)transaction.Element(ebayNs + "OrderLineItemID");

                    // Handle multiple line item orders
                    if (orderId != orderLineItemId)
                    {
                        GetOrder(accountName, orderId);
                    }
                    else
                    {
                        string recordNumber = (string)transaction.Element(ebayNs + "ShippingDetails").Element(ebayNs + "SellingManagerSalesRecordNumber");
                        EbayOrder ebayOrder = null;
                        var query = from order in context.EbayOrder
                                    where order.EbayOrdersn == orderId
                                    select order;
                        if (query.Count() == 0)
                        {
                            ebayOrder = new EbayOrder();
                            ebayOrder.EbayPaystatus = (string)transaction.Element(ebayNs + "Status").Element(ebayNs + "eBayPaymentStatus");
                            ebayOrder.EbayOrdersn = orderId;
                            XElement externalTransactionElement = transaction.Element(ebayNs + "ExternalTransaction");
                            if (externalTransactionElement != null)
                            {
                                ebayOrder.EbayPtid = (string)externalTransactionElement.Element(ebayNs + "ExternalTransactionID");
                            }
                            ebayOrder.EbayOrderid = orderId;
                            ebayOrder.EbayCreatedtime = DateUtils.ConvertToUnixTime(DateTime.Now);
                            ebayOrder.EbayPaidtime = ebayOrder.EbayCreatedtime.ToString();
                            ebayOrder.EbayAddtime = ebayOrder.EbayCreatedtime;
                            XElement buyer = transaction.Element(ebayNs + "Buyer");
                            ebayOrder.EbayUserid = (string)buyer.Element(ebayNs + "UserID");

                            XElement shippingAddress = buyer.Element(ebayNs + "BuyerInfo").Element(ebayNs + "ShippingAddress");
                            ebayOrder.EbayUsername = (string)shippingAddress.Element(ebayNs + "Name");
                            ebayOrder.EbayUsermail = (string)buyer.Element(ebayNs + "Email");
                            ebayOrder.EbayStreet = (string)shippingAddress.Element(ebayNs + "Street1");
                            ebayOrder.EbayStreet1 = (string)shippingAddress.Element(ebayNs + "Street2");
                            ebayOrder.EbayCity = (string)shippingAddress.Element(ebayNs + "CityName");
                            ebayOrder.EbayState = (string)shippingAddress.Element(ebayNs + "StateOrProvince");
                            ebayOrder.EbayCouny = (string)shippingAddress.Element(ebayNs + "Country");
                            ebayOrder.EbayCountryname = (string)shippingAddress.Element(ebayNs + "CountryName");
                            if (ebayOrder.EbayCountryname == "US")
                            {
                                ebayOrder.EbayCountryname = "United States";
                            }
                            ebayOrder.EbayPostcode = (string)shippingAddress.Element(ebayNs + "PostalCode");
                            ebayOrder.EbayPhone = (string)shippingAddress.Element(ebayNs + "Phone");
                            ebayOrder.EbayCurrency = (string)item.Element(ebayNs + "Currency");
                            ebayOrder.Status = "0";
                            ebayOrder.EbayCarrier2 = "";
                            ebayOrder.EbayTracknumber2 = "";
                            ebayOrder.IsYichang = "0";
                            ebayOrder.Ishide = 0;
                            ebayOrder.EbayCombine = "0";
                            ebayOrder.EbayStatus = 1;
                            ebayOrder.EbayUser = "vipadmin";
                            ebayOrder.EbayAccount = accountName;
                            ebayOrder.EbayAccount2 = accountName;
                            ebayOrder.Recordnumber = (string)transaction.Element(ebayNs + "ShippingDetails").Element(ebayNs + "SellingManagerSalesRecordNumber");
                            ebayOrder.EbayNote = (string)transaction.Element(ebayNs + "BuyerCheckoutMessage");
                            ebayOrder.EBayPaymentStatus = (string)transaction.Element(ebayNs + "Status").Element(ebayNs + "eBayPaymentStatus");

                            context.EbayOrder.Add(ebayOrder);
                        }

                        EbayOrderdetail ebayOrderdetail = null;
                        var orderDetailQuery = from orderDetail in context.EbayOrderdetail
                                               where orderDetail.EbayOrdersn == orderId
                                               where orderDetail.Recordnumber == recordNumber
                                               select orderDetail;
                        if (orderDetailQuery.Count() > 0)
                        {
                            ebayOrderdetail = orderDetailQuery.First();
                        }
                        else
                        {
                            ebayOrderdetail = new EbayOrderdetail();
                        }
                        ebayOrderdetail.OrderLineItemId = orderLineItemId;
                        ebayOrderdetail.EbayOrdersn = orderId;
                        ebayOrderdetail.Recordnumber = recordNumber;
                        ebayOrderdetail.EbayItemprice = (string)transaction.Element(ebayNs + "TransactionPrice");
                        ebayOrderdetail.EbayAmount = (string)transaction.Element(ebayNs + "QuantityPurchased");
                        ebayOrderdetail.EbayCreatedtime = DateUtils.ConvertToUnixTime(DateTime.Now);
                        XElement shippingServiceSelectedElement = transaction.Element(ebayNs + "ShippingServiceSelected");
                        if (shippingServiceSelectedElement != null)
                        {
                            ebayOrderdetail.EbayShiptype = (string)shippingServiceSelectedElement.Element(ebayNs + "ShippingService");
                        }
                        ebayOrderdetail.EbayUser = "vipadmin";

                        ebayOrderdetail.EbayItemid = (string)item.Element(ebayNs + "ItemID");
                        ebayOrderdetail.EbayItemtitle = (string)item.Element(ebayNs + "Title");
                        ebayOrderdetail.EbayItemurl = (string)item.Element(ebayNs + "ListingDetails").Element(ebayNs + "ViewItemURL");
                        ebayOrderdetail.Sku = (string)item.Element(ebayNs + "SKU");
                        if (ebayOrderdetail.Sku == null)
                        {
                            ebayOrderdetail.Sku = "";
                        }
                        ebayOrderdetail.Shipingfee = (string)transaction.Element(ebayNs + "ActualShippingCost");
                        ebayOrderdetail.EbayAccount = accountName;
                        ebayOrderdetail.Addtime = DateUtils.ConvertToUnixTime(DateTime.Now).ToString();
                        ebayOrderdetail.EbayTid = (string)transaction.Element(ebayNs + "TransactionID");
                        ebayOrderdetail.FeeOrCreditAmount = (string)transaction.Element(ebayNs + "MonetaryDetails").Element(ebayNs + "Payments").Element(ebayNs + "Payment").Element(ebayNs + "FeeOrCreditAmount");
                        ebayOrderdetail.FinalValueFee = float.Parse((string)transaction.Element(ebayNs + "FinalValueFee"));
                        ebayOrderdetail.PayPalEmailAddress = (string)transaction.Element(ebayNs + "PayPalEmailAddress");
                        ebayOrderdetail.ListingType = (string)item.Element(ebayNs + "ListingType");
                        context.EbayOrderdetail.Add(ebayOrderdetail);
                    }

                }

                context.SaveChanges();
            }
        }

        public void ProcessMessage(XElement element)
        {
            using (v3_allContext context = new v3_allContext())
            {
                EbayMessage message = new EbayMessage();
                foreach (XElement messageElement in element.Descendants(ebayNs + "Message"))
                {
                    string sender = (string)messageElement.Element(ebayNs + "Sender");
                    message.MessageId = (string)messageElement.Element(ebayNs + "MessageID");
                    message.ExternalMessageId = (string)messageElement.Element(ebayNs + "ExternalMessageId");
                    message.MessageType = (string)messageElement.Element(ebayNs + "MessageType");
                    message.Recipientid = (string)messageElement.Element(ebayNs + "RecipientUserID");
                    message.Sendid = (string)messageElement.Element(ebayNs + "Sender");
                    message.Subject = (string)messageElement.Element(ebayNs + "Subject");
                    message.Body = (string)messageElement.Element(ebayNs + "Text");
                    message.Itemid = (string)messageElement.Element(ebayNs + "ItemID");
                    message.Title = (string)messageElement.Element(ebayNs + "ItemTitle");
                    message.EbayAccount = (string)messageElement.Element(ebayNs + "RecipientUserID");
                    message.Read = (bool)messageElement.Element(ebayNs + "Read") ? 1 : 0;

                    bool highPriority = false;
                    XElement highPriorityElement = messageElement.Element(ebayNs + "HighPriority");
                    if (highPriorityElement != null)
                    {
                        highPriority = (bool)highPriorityElement;
                    }
                    if (message.Sendid == "eBay")
                    {
                        message.Forms = 2;
                    }
                    else if (highPriority)
                    {
                        message.Forms = 3;
                    }
                    else
                    {
                        message.Forms = 0;
                    }
                    message.Status = (bool)messageElement.Element(ebayNs + "Replied") ? 1 : 0;
                    var q = from messageCategory in context.EbayMessagecategory
                            where messageCategory.CategoryName == message.Recipientid
                            select messageCategory;
                    int classId = 0;
                    if (q.Count() == 0)
                    {
                        EbayMessagecategory ebayMessageCategory = new EbayMessagecategory();
                        ebayMessageCategory.CategoryName = message.Recipientid;
                        ebayMessageCategory.EbayNote = message.Recipientid;
                        ebayMessageCategory.EbayUser = "vipadmin";
                        context.SaveChanges();
                        var q1 = from messageCategory in context.EbayMessagecategory
                                 where messageCategory.CategoryName == message.Recipientid
                                 select messageCategory;
                        classId = q1.First().Id;
                    }
                    else
                    {
                        classId = q.First().Id;
                    }

                    message.Createtime = (string)messageElement.Element(ebayNs + "ReceiveDate");
                    message.Createtime1 = DateUtils.ConvertToUnixTime(DateTime.Parse(message.Createtime));
                    message.AddTime = DateUtils.ConvertToUnixTime(DateTime.Now);
                    message.EbayUser = "vipadmin";
                    message.Classid = classId;

                    context.EbayMessage.Add(message);
                }

                context.SaveChanges();
            }
        }

        public void ProcessItemListed(XElement element)
        {
            XElement item = element.Element(ebayNs + "Item");
            string itemId = (string)item.Element(ebayNs + "ItemID");
            using (v3_allContext context = new v3_allContext())
            {
                var q = from ebayList in context.EbayList
                        where ebayList.ItemId == itemId
                        select ebayList;
                if (q.Count() == 0)
                {
                    AddItem(context, element);
                }
                context.SaveChanges();
            }
        }

        public void ProcessItemClosed(XElement element)
        {
            XElement item = element.Element(ebayNs + "Item");
            string itemId = (string)item.Element(ebayNs + "ItemID");
            using (v3_allContext context = new v3_allContext())
            {
                var q = from ebayList in context.EbayList
                        where ebayList.ItemId == itemId
                        select ebayList;
                if (q.Count() == 1)
                {
                    context.EbayList.Remove(q.First());
                }
                else
                {
                    m_logger.Error("Item " + itemId + " does not exist in ebay_list table.");
                }
                context.SaveChanges();
            }
        }

        public bool IsPlatformNotificationEnabled(string ebayAccount)
        {
            bool isEnabled = false;
            XElement input = new XElement(ebayNs + "GetNotificationPreferencesRequest",
                                new XElement(ebayNs + "PreferenceLevel", "Application"));
            AddCredentials(ebayAccount, input);
            XElement output = MakeCall("GetNotificationPreferences", input);
            if( (string)output.Element(ebayNs + "ApplicationDeliveryPreferences").Element(ebayNs + "ApplicationEnable") == "Enable")
            {
                isEnabled = true;
            }
            return isEnabled;
        }

        public List<string> GetEnabledNotificationTypes(string ebayAccount )
        {
            List<string> eventTypes = new List<string>();
            XElement input = new XElement(ebayNs + "GetNotificationPreferencesRequest",
                                new XElement(ebayNs + "PreferenceLevel", "User"));
            AddCredentials(ebayAccount, input);
            XElement output = MakeCall("GetNotificationPreferences", input);
            foreach( XElement notification in output.Descendants(ebayNs + "NotificationEnable"))
            {
                if((string)notification.Element(ebayNs+"EventEnable") == "Enable")
                {
                    eventTypes.Add((string)notification.Element(ebayNs + "EventType"));
                }
            }

            return eventTypes;
        }

        public void SetNotificationPreferences(string ebayAccount, bool enable, string[] eventTypes)
        {

            XElement input = new XElement(ebayNs+ "SetNotificationPreferencesRequest",
                                new XElement(ebayNs+ "ApplicationDeliveryPreferences",
                                    new XElement(ebayNs+ "ApplicationEnable", enable?"Enable":"Disable"),
                                    new XElement(ebayNs+ "ApplicationURL", "http://74.215.110.166/api/EbayNotification")));
            AddCredentials(ebayAccount, input);
            if( enable )
            {
                List<string> enabledEventTypes = GetEnabledNotificationTypes(ebayAccount);
                XElement userElement = new XElement(ebayNs + "UserDeliveryPreferenceArray");
                foreach (string eventType in eventTypes)
                {
                    userElement.Add(new XElement(ebayNs + "NotificationEnable",
                                        new XElement(ebayNs + "EventType", eventType),
                                        new XElement(ebayNs + "EventEnable", "Enable")));
                    if( enabledEventTypes.Contains(eventType))
                    {
                        enabledEventTypes.Remove(eventType);
                    }
                }
                foreach (string eventType in enabledEventTypes)
                {
                    userElement.Add(new XElement(ebayNs + "NotificationEnable",
                                        new XElement(ebayNs + "EventType", eventType),
                                        new XElement(ebayNs + "EventEnable", "Disable")));
                }
                    input.Add(userElement);
            }
            XElement output = MakeCall("SetNotificationPreferences", input);
        }

        public Dictionary<string, Object> GetUserPreferences( string ebayAccount, List<string> preferenceNames )
        {
            Dictionary<string, Object> preferences = new Dictionary<string, object>();
            XElement input = new XElement(ebayNs + "GetUserPreferencesRequest");
            foreach(string preferenceName in preferenceNames)
            {
                input.Add(new XElement(ebayNs + preferenceName, true));
            }
            AddCredentials(ebayAccount, input);
            XElement output = MakeCall("GetUserPreferences", input);
            foreach(XElement element in output.Elements())
            {
                if(element.Name.LocalName.EndsWith("Preferences"))
                {
                    Dictionary<string, object> childPreferences = new Dictionary<string, object>();
                    foreach(XElement childElement in element.Elements())
                    {
                        childPreferences[childElement.Name.LocalName] = childElement.Value;
                    }
                    preferences[element.Name.LocalName] = childPreferences;
                }
                else if(element.Name.LocalName.EndsWith("Preference"))
                {
                    preferences[element.Name.LocalName] = element.Value;
                }
            }

            return preferences;
        }

        public void SetUserPreferences( string ebayAccount, Dictionary<string, Object> preferences)
        {
            XElement input = new XElement(ebayNs + "SetUserPreferencesRequest");
            foreach( KeyValuePair<string, Object> pair in preferences)
            {
                if( pair.Value is Dictionary<string, Object>)
                {
                    XElement preferenceElement = new XElement(ebayNs + pair.Key);
                    input.Add(preferenceElement);
                    foreach (KeyValuePair<string, Object> pair1 in (Dictionary<string, Object>)(pair.Value))
                    {
                        preferenceElement.Add(new XElement(ebayNs + pair1.Key, pair1.Value));
                    }
                }
                else
                {
                    input.Add(new XElement(ebayNs + pair.Key, pair.Value));
                }
            }
            AddCredentials(ebayAccount, input);
            XElement output = MakeCall("SetUserPreferences", input);
        }

        private void AddCredentials(string ebayAccount, XElement doc)
        {
            string token = GetEbayToken(ebayAccount);
            doc.Add(new XElement(ebayNs + "RequesterCredentials",
                        new XElement(ebayNs + "eBayAuthToken", token)));
            doc.Add(new XElement(ebayNs + "Version", 967));
        }


        private XElement MakeCall( string method, XElement input )
        {
            XElement output = null;
            int retryCount = 3;
            for (int i = 0; i < retryCount; i++)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Headers.Add("X-EBAY-API-DEV-NAME", devId);
                request.Headers.Add("X-EBAY-API-APP-NAME", appId);
                request.Headers.Add("X-EBAY-API-CERT-NAME", certId);
                request.Headers.Add("X-EBAY-API-CALL-NAME", method);
                request.Headers.Add("X-EBAY-API-COMPATIBILITY-LEVEL", "967");
                request.Headers.Add("X-EBAY-API-SITEID", "0");
                input.Save(request.GetRequestStream());

                try
                {
                    using (WebResponse response = request.GetResponse())
                    {

                        output = XElement.Load(response.GetResponseStream());
                        string ack = (string)output.Element(ebayNs + "Ack");
                        if (ack == "Success")
                        {
                            break;
                        }
                        else if (ack == "Warning")
                        {
                            // Log warning
                        }
                        else if (ack == "Failure")
                        {
                            foreach (XElement error in output.Descendants(ebayNs + "Errors"))
                            {
                                string severityCode = (string)error.Element(ebayNs + "SeverityCode");
                                int errorCode = (int)error.Element(ebayNs + "ErrorCode");
                                if (severityCode == "Warning")
                                {
                                    // Log warning
                                }
                                else if (severityCode == "Error")
                                {
                                    string errorClassification = (string)error.Element(ebayNs + "ErrorClassification");
                                    if (errorClassification == "SystemError")
                                    {
                                        if (errorCode == 21359)
                                        {
                                            request.Timeout = request.Timeout * 2;
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                catch(WebException webException)
                {
                    if( webException.Status == WebExceptionStatus.Timeout)
                    {
                        request.Timeout = request.Timeout * 2;
                    }
                }
            }

            return output;
        }

        private string GetEbayToken(string ebayAccount)
        {
            string ebayToken = null;
            if (m_ebayTokenDictionary.ContainsKey(ebayAccount))
            {
                ebayToken = m_ebayTokenDictionary[ebayAccount];
            }
            return ebayToken;
        }

        private void UpdateListingQuantitiesInternal(v3_allContext context, string sku, int quantity)
        {
            var q = from ebayList in context.EbayList
                    where ebayList.Sku == sku
                    where ebayList.ListingType == "FixedPriceItem"
                    select ebayList;
            if (q.Count() > 0)
            {
                EbayList listing = q.First();
                string location = listing.Location.ToUpper();
                if (location.Contains("MASON") || location.Contains("KENTUCKY") || location.Contains("UNITED STATES") || location.Contains("WEST CHESTER") || location.Contains("MIDDLETOWN"))
                {
                    this.ReviseListingQuantity(listing.EbayAccount, listing.ItemId, quantity);
                }
            }
            else
            {
                // Check if sku has variations
                var variantQ = from ebayListvariations in context.EbayListvariations
                               from ebayList in context.EbayList
                               where ebayListvariations.Sku == sku
                               where ebayListvariations.Itemid == ebayList.ItemId
                               select ebayList;
                if (variantQ.Count() > 0)
                {
                    EbayList listing = variantQ.First();
                    string location = listing.Location.ToUpper();
                    if (location.Contains("MASON") || location.Contains("KENTUCKY") || location.Contains("UNITED STATES") || location.Contains("WEST CHESTER") || location.Contains("MIDDLETOWN"))
                    {
                        this.ReviseVariationQuantity(listing.EbayAccount, listing.ItemId, sku, quantity);
                    }
                }
            }
        }

        public void UpdateListingQuantities( string sku, int quantity )
        {
            using (v3_allContext context = new v3_allContext())
            {
                UpdateListingQuantitiesInternal(context, sku, quantity);

                // Handle productsCombine
                var productsCombineQuery = from productsCombine in context.EbayProductscombine
                                           where productsCombine.GoodsSncombine.Contains(sku)
                                           select productsCombine;
                foreach (var row in productsCombineQuery)
                {
                    string[] skuStrings = row.GoodsSncombine.Split(',');
                    foreach (string skuString in skuStrings)
                    {
                        if (skuString.Trim().Length > 0)
                        {
                            string[] values = skuString.Trim().Split('*');
                            if (values.Length == 2)
                            {
                                int quantity1 = 0;
                                bool success = Int32.TryParse(values[1].Trim(), out quantity1);
                                if (success)
                                {
                                    int quantity2 = Convert.ToInt16(Math.Ceiling((double)quantity / (double)quantity1));
                                    UpdateListingQuantitiesInternal(context, values[0], quantity2);
                                }
                                else
                                {
                                    m_logger.Error("Combined Sku Error: " + row.GoodsSn);
                                }
                            }
                            else
                            {
                                m_logger.Error("Combined Sku Error: " + row.GoodsSn);
                            }
                        }
                    }

                }
            }
        }
    }
}
