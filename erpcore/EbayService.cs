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
    public class EbayService : IEbayService
    {
        private IPlatformServiceFactory m_platformServiceFactory;
        private string m_company;
        private string m_connectionString = null;
        private int[] m_storeIds = null;
        private const string url = "https://api.ebay.com/ws/api.dll";
        private const string ebayNs = "{urn:ebay:apis:eBLBaseComponents}";

        /*
        private const string devId = "8dc6ba1f-5567-41d5-9bd1-63b69431ae11";
        private const string appId = "XinXu6b4b-d44f-493b-8a83-7fd2be893ea";
        private const string certId = "60f3aa83-8c15-4a31-ad3f-986cd05324e9";
        */
        private const string devId = "57b6d257-5a51-4aef-b081-8e3563cf989c";
        private const string appId = "XinXu59fa-2456-4989-8556-07c34764a70";
        private const string certId = "deb04ec3-d57f-4f2e-ad82-90523d62caec";
        private Dictionary<string, string> m_ebayTokenDictionary = new Dictionary<string, string>();
        private static Logger m_logger = NLog.LogManager.GetCurrentClassLogger();

        public EbayService(PlatformServiceFactory platformServiceFactory, string company, string connectionString, int[] storeIds)
        {
            m_platformServiceFactory = platformServiceFactory;
            m_company = company;
            m_connectionString = connectionString;
            m_storeIds = storeIds;
            using (ERPContext context = new ERPContext(m_connectionString))
            {
                var q = from ebayAccount in context.EbayAccount
                        where ebayAccount.EbayToken5 != null
                        select ebayAccount;
                foreach(var row in q)
                {
                    m_ebayTokenDictionary[row.EbayAccount1] = row.EbayToken5;
                }
            }
        }
        
        public List<string> GetAccountNames()
        {
            List<string> accountNames = new List<string>();
            accountNames.AddRange(m_ebayTokenDictionary.Keys);
            return accountNames;
        }

        public void RefreshListings(ERPContext context)
        {
            foreach( string ebayAcocuntName in m_ebayTokenDictionary.Keys)
            {
                RefreshListings(context, ebayAcocuntName);
            }

            // Delete remaining ebayList
            List<string> ebayAccountNames = m_ebayTokenDictionary.Keys.ToList();
            var q = from ebayList in context.EbayList
                    where ! ebayAccountNames.Contains(ebayList.EbayAccount)
                    select ebayList;
            foreach(var row in q)
            {
                context.EbayList.Remove(row);
            }
            var q1 = from ebayListVariation in context.EbayListvariations
                    where !ebayAccountNames.Contains(ebayListVariation.EbayAccount)
                    select ebayListVariation;
            foreach (var row in q1)
            {
                context.EbayListvariations.Remove(row);
            }
            context.SaveChanges();
        }

        public void RefreshListings( ERPContext context, string ebayAccount )
        {
            m_logger.Info("Start to Refresh listings of " + ebayAccount);
            DateTime startTimeTo = DateTime.Now;
            DateTime startTimeFrom = DateTime.Now.AddDays(-120);
            Dictionary<string, EbayList> ebayListDictionary = new Dictionary<string, EbayList>();
            Dictionary<string, Dictionary<string, EbayListvariations>> ebayListVariationDictionary = new Dictionary<string, Dictionary<string, EbayListvariations>>();
            
            var q = from ebayList in context.EbayList
                    where ebayList.EbayAccount == ebayAccount
                    select ebayList;
            foreach (var listing in q)
            {
                if(ebayListDictionary.ContainsKey(listing.ItemId))
                {
                    context.EbayList.Remove(listing);
                }
                else
                {
                    ebayListDictionary[listing.ItemId] = listing;
                }
            }

            var q1 = from ebayListVariations in context.EbayListvariations
                        where ebayListVariations.EbayAccount == ebayAccount
                        select ebayListVariations;
            foreach (var ebayListVariation in q1)
            {
                Dictionary<string, EbayListvariations> listVariations = null;
                if (ebayListVariationDictionary.ContainsKey(ebayListVariation.Itemid))
                {
                    listVariations = ebayListVariationDictionary[ebayListVariation.Itemid];
                }
                else
                {
                    listVariations = new Dictionary<string, EbayListvariations>();
                    ebayListVariationDictionary[ebayListVariation.Itemid] = listVariations;
                }
                if( listVariations.ContainsKey(ebayListVariation.Sku))
                {
                    context.EbayListvariations.Remove(ebayListVariation);
                }
                else
                {
                    listVariations[ebayListVariation.Sku] = ebayListVariation;
                }
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
                    new XElement(ebayNs + "IncludeVariations", true),
                    new XElement(ebayNs + "OutputSelector", "PaginationResult"),
                    new XElement(ebayNs + "OutputSelector", "PageNumber"),
                    new XElement(ebayNs + "OutputSelector", "ItemID"),
                    new XElement(ebayNs + "OutputSelector", "SKU"),
                    new XElement(ebayNs + "OutputSelector", "Title"),
                    new XElement(ebayNs + "OutputSelector", "ListingType"),
                    new XElement(ebayNs + "OutputSelector", "TimeLeft"),
                    new XElement(ebayNs + "OutputSelector", "Quantity"),
                    new XElement(ebayNs + "OutputSelector", "QuantitySold"),
                    new XElement(ebayNs + "OutputSelector", "GalleryURL"),
                    new XElement(ebayNs + "OutputSelector", "PictureDetails"),
                    new XElement(ebayNs + "OutputSelector", "Location"),
                    new XElement(ebayNs + "OutputSelector", "ViewItemURL"),
                    new XElement(ebayNs + "OutputSelector", "PayPalEmailAddress"),
                    new XElement(ebayNs + "OutputSelector", "SellingStatus"),
                    new XElement(ebayNs + "OutputSelector", "HitCount"),
                    new XElement(ebayNs + "OutputSelector", "BuyItNowPrice"),
                    new XElement(ebayNs + "OutputSelector", "StartPrice"),
                    new XElement(ebayNs + "OutputSelector", "Site"),
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
                        string listingType = (string)item.Element(ebayNs + "ListingType");
                        string listingStatus = (string)item.Element(ebayNs + "SellingStatus").Element(ebayNs + "ListingStatus");
                        if (listingType == "FixedPriceItem" && (listingStatus == "Active" || listingStatus == "Completed"))
                        {
                            if (ebayListDictionary.ContainsKey(itemId))
                            {
                                EbayList ebayList = ebayListDictionary[itemId];
                                Dictionary<string, EbayListvariations> listVariations = null;
                                if (ebayListVariationDictionary.ContainsKey(itemId))
                                {
                                    listVariations = ebayListVariationDictionary[itemId];
                                }
                                AddOrUpdateItem(context, item, ebayAccount, ebayList, listVariations);
                                ebayListDictionary.Remove(itemId);
                                ebayListVariationDictionary.Remove(itemId);
                            }
                            else
                            {
                                AddOrUpdateItem(context, item, ebayAccount, null, null);
                                IEnumerable<XElement> variations = item.Descendants(ebayNs + "Variation");
                                foreach (XElement variation in variations)
                                {
                                    AddVariation(context, ebayAccount, itemId, variation);
                                }
                            }
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

            foreach (KeyValuePair < string, EbayList> pair in ebayListDictionary)
            {
                context.EbayList.Remove(pair.Value);
            }

            foreach(KeyValuePair<string, Dictionary<string, EbayListvariations>> pair in ebayListVariationDictionary)
            {
                foreach(KeyValuePair<string, EbayListvariations> pair1 in pair.Value)
                {
                    context.EbayListvariations.Remove(pair1.Value);
                }
            }

            context.SaveChanges();

            m_logger.Info("Complete Refresh listings of " + ebayAccount);
        }
        
        private EbayList AddOrUpdateItem(ERPContext context, XElement item, string ebayAccount, EbayList ebayList, Dictionary<string, EbayListvariations> ebayListVariations)
        {
            EbayList listing = null;
            if( ebayList ==  null )
            {
                listing = new EbayList();
                context.EbayList.Add(listing);
            }
            else
            {
                listing = ebayList;
            }
            listing.ItemId = (string)item.Element(ebayNs + "ItemID"); ;
            listing.Sku = (string)item.Element(ebayNs + "SKU");
            listing.Title = (string)item.Element(ebayNs + "Title");
            listing.ListingType = (string)item.Element(ebayNs + "ListingType");
            listing.TimeLeft = (string)item.Element(ebayNs + "TimeLeft");
            listing.Quantity = (string)item.Element(ebayNs + "Quantity");
            int quantity = 0;
            bool success = int.TryParse(listing.Quantity, out quantity);
            if( !success )
            {
                m_logger.Error("Invalid quantity " + listing.Quantity + " for item " + listing.ItemId);
            }
            XElement sellingStatusElement = item.Element(ebayNs + "SellingStatus");
            listing.QuantitySold = (int)sellingStatusElement.Element(ebayNs + "QuantitySold");
            listing.QuantityAvailable = quantity - listing.QuantitySold;
            listing.Site = (string)sellingStatusElement.Element(ebayNs + "Site");
            listing.StartPrice = (string)item.Element(ebayNs + "StartPrice");
            listing.StartPricecurrencyId = (string)item.Element(ebayNs + "StartPrice").Attribute("currencyID");
            XElement pictureDetailsElement = item.Element(ebayNs + "PictureDetails");
            listing.GalleryUrl = (string)pictureDetailsElement.Element(ebayNs + "GalleryURL");
            List<XElement> pictureURLs = pictureDetailsElement.Elements(ebayNs + "PictureURL").ToList();
            if( pictureURLs.Count > 0)
            {
                listing.PictureUrl01 = (string)pictureURLs[0];
            }
            if (pictureURLs.Count > 1)
            {
                listing.PictureUrl02 = (string)pictureURLs[1];
            }
            if (pictureURLs.Count > 2)
            {
                listing.PictureUrl03 = (string)pictureURLs[2];
            }
            if (pictureURLs.Count > 3)
            {
                listing.PictureUrl04 = (string)pictureURLs[3];
            }

            listing.Location = (string)item.Element(ebayNs + "Location");
            listing.ViewItemUrl = (string)item.Element(ebayNs + "ListingDetails").Element(ebayNs + "ViewItemURL");
            listing.EbayAccount = ebayAccount;
            listing.EbayUser = "vipadmin";
            listing.PayPalEmailAddress = (string)item.Element(ebayNs + "PayPalEmailAddress");
            listing.Active = true;
            listing.GalleryType = (string)item.Element(ebayNs + "PictureDetails").Element(ebayNs + "GalleryType");
            listing.BidCount = (string)sellingStatusElement.Element(ebayNs + "BidCount");
            listing.HitCount = (string)item.Element(ebayNs + "HitCount");
            listing.BuyItNowPrice = (string)item.Element(ebayNs + "BuyItNowPrice");
            

            IEnumerable<XElement> variations = item.Descendants(ebayNs + "Variation");
            if (variations != null && variations.Count() > 0)
            {
                foreach( XElement variation in variations)
                {
                    string sku = (string)variation.Element(ebayNs + "SKU");
                    EbayListvariations listVariation = null;
                    if ( ebayListVariations != null && ebayListVariations.ContainsKey(sku))
                    {
                        listVariation = ebayListVariations[sku];
                        ebayListVariations.Remove(sku);
                    }
                    else
                    {
                        listVariation = new EbayListvariations();
                        context.EbayListvariations.Add(listVariation);
                    }
                    listVariation.Sku = sku;
                    listVariation.Quantity = (string)variation.Element(ebayNs + "Quantity");
                    quantity = 0;
                    success = int.TryParse(listVariation.Quantity, out quantity);
                    if (!success)
                    {
                        m_logger.Error("Invalid quantity " + listVariation.Quantity + " for item " + listing.ItemId+", SKU "+listVariation.Sku);
                    }
                    listVariation.QuantitySold = (int)variation.Element(ebayNs + "SellingStatus").Element(ebayNs + "QuantitySold");
                    listVariation.QuantityAvailable = quantity - listVariation.QuantitySold;
                    listVariation.Itemid = listing.ItemId;
                    listVariation.EbayAccount = listing.EbayAccount;
                    listVariation.EbayUser = "vipadmin";
                }

                if(ebayListVariations != null)
                {
                    foreach (KeyValuePair<string, EbayListvariations> pair in ebayListVariations)
                    {
                        context.EbayListvariations.Remove(pair.Value);
                    }
                }
            }

            return listing;
        }

        private void AddVariation(ERPContext context, string ebayAccount, string itemId, XElement variation)
        {
            EbayListvariations listVariation = new EbayListvariations();
            listVariation.Sku = (string)variation.Element(ebayNs + "SKU");
            listVariation.Itemid = itemId;
            listVariation.Quantity = (string)variation.Element(ebayNs + "Quantity");
            listVariation.QuantitySold = (int)variation.Element(ebayNs + "QuantitySold");
            listVariation.QuantityAvailable = (int)variation.Element(ebayNs + "QuantityAvailable");
            listVariation.StartPrice = (string)variation.Element(ebayNs + "StartPrice");
            listVariation.EbayAccount = ebayAccount;
            listVariation.VariationSpecifics = "";
            context.EbayListvariations.Add(listVariation);
        }

        public void ReviseListingQuantity( string ebayAccount, string itemId, string sku, int quantity)
        {
            XElement input = new XElement(ebayNs + "ReviseFixedPriceItemRequest");
            XElement itemElement = new XElement(ebayNs + "Item",
                new XElement(ebayNs + "ItemID", itemId),
                new XElement(ebayNs+"Quantity", quantity));
            input.Add(itemElement);
            AddCredentials(ebayAccount, input);
            
            //MakeCall("ReviseFixedPriceItem", input);

            m_logger.Info("EbayAccount: "+ebayAccount+", SKU: "+sku+", ItemId: "+itemId+", The quantity of item has been revised to " + quantity);
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

            //MakeCall("ReviseFixedPriceItem", input);
            m_logger.Info("EbayAccount: " + ebayAccount + ", SKU: " + sku + ", ItemId: " + itemId + ", The quantity of variant item has been revised to " + quantity);
        }

        public void SyncOrders( ERPContext context, string accountName, DateTime createdTimeFrom, DateTime createdTimeTo, List<EbayOrderdetail> orderDetails  )
        {
            if (!m_ebayTokenDictionary.ContainsKey(accountName))
            {
                m_logger.Error(accountName + " does not exist.");
                return;
            }
            m_logger.Info("Sync orders of " + accountName);
            string createdTimeFromString = createdTimeFrom.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
            string createdTimeToString = createdTimeTo.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
            int currentPage = 1;
            int totalNumberOfPages = 1;
            while (true)
            {
                XElement input = new XElement(ebayNs + "GetOrdersRequest",
                                     new XElement(ebayNs + "DetailLevel", "ReturnAll"),
                                     new XElement(ebayNs + "CreateTimeFrom", createdTimeFromString),
                                     new XElement(ebayNs + "CreateTimeTo", createdTimeToString),
                                     new XElement(ebayNs + "IncludeFinalValueFee", true),
                                     new XElement(ebayNs + "OrderRole", "Seller"),
                                     new XElement(ebayNs + "OrderStatus", "Completed"),
                                     new XElement(ebayNs + "Pagination",
                                        new XElement(ebayNs + "PageNumber", currentPage)),
                                    new XElement(ebayNs + "OutputSelector", "PaginationResult"),
                                    new XElement(ebayNs + "OutputSelector", "CreatedTime"),
                                    new XElement(ebayNs + "OutputSelector", "CheckoutStatus"),
                                    new XElement(ebayNs + "OutputSelector", "OrderID"),
                                    new XElement(ebayNs + "OutputSelector", "ExternalTransactionID"),
                                    new XElement(ebayNs + "OutputSelector", "PaidTime"),
                                    new XElement(ebayNs + "OutputSelector", "BuyerUserID"),
                                    new XElement(ebayNs + "OutputSelector", "ShippingAddress"),
                                    new XElement(ebayNs + "OutputSelector", "AmountPaid"),
                                    new XElement(ebayNs + "OutputSelector", "Total"),
                                    new XElement(ebayNs + "OutputSelector", "ShippingServiceSelected"),
                                    new XElement(ebayNs + "OutputSelector", "SellingManagerSalesRecordNumber"),
                                    new XElement(ebayNs + "OutputSelector", "BuyerCheckoutMessage"),
                                    new XElement(ebayNs + "OutputSelector", "SellingStatus"),
                                    new XElement(ebayNs + "OutputSelector", "ExternalTransaction"),
                                    new XElement(ebayNs + "OutputSelector", "TransactionPrice"),
                                    new XElement(ebayNs + "OutputSelector", "QuantityPurchased"),
                                    new XElement(ebayNs + "OutputSelector", "CreatedDate"),
                                    new XElement(ebayNs + "OutputSelector", "Variation"),
                                    new XElement(ebayNs + "OutputSelector", "Item"),
                                    new XElement(ebayNs + "OutputSelector", "ActualShippingCost"),
                                    new XElement(ebayNs + "OutputSelector", "FinalValueFee"),
                                    new XElement(ebayNs + "OutputSelector", "FeeOrCreditAmount"),
                                    new XElement(ebayNs + "OutputSelector", "OrderLineItemID"),
                                    new XElement(ebayNs + "OutputSelector", "Item.ListingDetails"),
                                    new XElement(ebayNs + "OutputSelector", "TransactionID"),
                                    new XElement(ebayNs + "OutputSelector", "PayPalEmailAddress"),
                                    new XElement(ebayNs + "OutputSelector", "ListingType"));
                AddCredentials(accountName, input);
                XElement output = MakeCall("GetOrders", input);
                totalNumberOfPages = (int)output.Element(ebayNs + "PaginationResult").Element(ebayNs + "TotalNumberOfPages");
                ProcessGetOrdersResponse(context, accountName, output, orderDetails);

                if (currentPage >= totalNumberOfPages)
                {
                    break;
                }
                currentPage++;
            }
        }

        public void GetOrder(ERPContext context, string accountName, string orderId, List<EbayOrderdetail> orderDetails)
        {
            XElement input = new XElement(ebayNs + "GetOrdersRequest",
                                new XElement(ebayNs+"DetailLevel", "ReturnAll"),
                                new XElement(ebayNs + "OrderIDArray",
                                    new XElement(ebayNs + "OrderID", orderId)));
            AddCredentials(accountName, input);
            XElement output = MakeCall("GetOrders", input);
            ProcessGetOrdersResponse(context, accountName, output, orderDetails);
        }

        private void ProcessGetOrdersResponse( ERPContext context, string accountName, XElement output, List<EbayOrderdetail> orderDetails)
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
                    ebayOrder.EbayPaystatus = (string)orderElement.Element(ebayNs + "CheckoutStatus").Element(ebayNs + "Status");
                    ebayOrder.EBayPaymentStatus = (string)orderElement.Element(ebayNs + "CheckoutStatus").Element(ebayNs + "eBayPaymentStatus");
                    ebayOrder.EbayOrdersn = orderId;
                    XElement externalTransactionElement = orderElement.Element(ebayNs + "ExternalTransaction");
                    if (externalTransactionElement != null)
                    {
                        ebayOrder.EbayPtid = (string)externalTransactionElement.Element(ebayNs + "ExternalTransactionID");
                    }
                    ebayOrder.EbayOrderid = orderId;
                    string createdTime = (string)orderElement.Element(ebayNs + "CreatedTime");
                    ebayOrder.EbayCreatedtime = DateUtils.ConvertToUnixTime(DateTime.Parse(createdTime));
                    string paidTime = (string)orderElement.Element(ebayNs + "PaidTime");
                    ebayOrder.EbayPaidtime = DateUtils.ConvertToUnixTime(DateTime.Parse(createdTime)).ToString();
                    ebayOrder.EbayAddtime = DateUtils.ConvertToUnixTime(DateTime.Now);
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
                    if(ebayOrder.EbayPaidtime != null )
                    {
                        ebayOrder.EbayStatus = 1;
                    }
                    else
                    {
                        ebayOrder.EbayStatus = 0;
                    }
                    ebayOrder.EbayUser = "vipadmin";
                    ebayOrder.EbayShipfee = (string)orderElement.Element(ebayNs + "ShippingServiceSelected").Element(ebayNs + "ShippingServiceCost");
                    ebayOrder.EbayAccount = accountName;
                    ebayOrder.EbayAccount2 = accountName;
                    ebayOrder.Recordnumber = (string)orderElement.Element(ebayNs + "ShippingDetails").Element(ebayNs + "SellingManagerSalesRecordNumber");
                    ebayOrder.EbayNote = (string)orderElement.Element(ebayNs + "BuyerCheckoutMessage");
                    double feeOrCreditAmount = Convert.ToDouble((string)orderElement.Element(ebayNs+ "MonetaryDetails").Element(ebayNs + "Payments").Element(ebayNs + "Payment").Element(ebayNs + "FeeOrCreditAmount"));

                    context.EbayOrder.Add(ebayOrder);
                    m_logger.Info("Proccess ebay order " + ebayOrder.EbayUsername);

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
                        createdTime = (string)transaction.Element(ebayNs + "CreatedDate");
                        ebayOrderdetail.EbayCreatedtime = DateUtils.ConvertToUnixTime(DateTime.Parse(createdTime));
                        XElement shippingServiceSelectedElement = transaction.Element(ebayNs + "ShippingServiceSelected");
                        if (shippingServiceSelectedElement != null)
                        {
                            ebayOrderdetail.EbayShiptype = (string)shippingServiceSelectedElement.Element(ebayNs + "ShippingService");
                        }
                        ebayOrderdetail.EbayUser = "vipadmin";

                        XElement item = transaction.Element(ebayNs + "Item");
                        ebayOrderdetail.EbayItemid = (string)item.Element(ebayNs + "ItemID");
                        EbayList listing = GetItem(context, ebayOrder.EbayAccount, ebayOrderdetail.EbayItemid);
                        XElement variation = transaction.Element(ebayNs + "Variation");
                        if (variation != null)
                        {
                            ebayOrderdetail.EbayItemtitle = (string)variation.Element(ebayNs + "VariationTitle");
                            ebayOrderdetail.Sku = (string)variation.Element(ebayNs + "SKU");
                        }
                        else
                        {
                            ebayOrderdetail.EbayItemtitle = (string)item.Element(ebayNs + "Title");
                            ebayOrderdetail.Sku = (string)item.Element(ebayNs + "SKU");
                        }
                        if(listing != null )
                        {
                            ebayOrderdetail.ListingType = listing.ListingType;
                            ebayOrderdetail.PayPalEmailAddress = listing.PayPalEmailAddress;
                            ebayOrderdetail.EbayItemurl = listing.GalleryUrl;
                        }
                        ebayOrderdetail.Shipingfee = (string)transaction.Element(ebayNs + "ActualShippingCost");
                        ebayOrderdetail.EbayAccount = ebayOrder.EbayAccount;
                        ebayOrderdetail.Addtime = DateUtils.ConvertToUnixTime(DateTime.Now).ToString();
                        ebayOrderdetail.EbayTid = (string)transaction.Element(ebayNs + "TransactionID");
                        double transactionPrice = Convert.ToDouble((string)transaction.Element(ebayNs + "TransactionPrice"));
                        double actualShippingCost = Convert.ToDouble((string)transaction.Element(ebayNs + "ActualShippingCost"));
                        ebayOrderdetail.FeeOrCreditAmount = (feeOrCreditAmount*(transactionPrice+actualShippingCost)/ebayOrder.EbayTotal).ToString();
                        ebayOrderdetail.FinalValueFee = float.Parse((string)transaction.Element(ebayNs + "FinalValueFee"));
                        context.EbayOrderdetail.Add(ebayOrderdetail);
                        orderDetails.Add(ebayOrderdetail);
                        m_logger.Info(ebayOrderdetail.Sku + "," + ebayOrderdetail.EbayAmount);
                    }
                }
            }
        }

        private EbayList GetItem( ERPContext context, string accountName, string itemId )
        {
            EbayList listing = null;
            var listingQuery = from ebayList in context.EbayList
                               where ebayList.EbayAccount == accountName
                               where ebayList.ItemId == itemId
                               select ebayList;
            if( listingQuery.Count() == 0 )
            {
                XElement input = new XElement(ebayNs + "GetItemRequest",
                        new XElement(ebayNs+"ItemID", itemId),
                    new XElement(ebayNs + "OutputSelector", "ItemID"),
                    new XElement(ebayNs + "OutputSelector", "SKU"),
                    new XElement(ebayNs + "OutputSelector", "Title"),
                    new XElement(ebayNs + "OutputSelector", "ListingType"),
                    new XElement(ebayNs + "OutputSelector", "TimeLeft"),
                    new XElement(ebayNs + "OutputSelector", "Quantity"),
                    new XElement(ebayNs + "OutputSelector", "GalleryURL"),
                    new XElement(ebayNs + "OutputSelector", "PictureDetails"),
                    new XElement(ebayNs + "OutputSelector", "Location"),
                    new XElement(ebayNs + "OutputSelector", "ViewItemURL"),
                    new XElement(ebayNs + "OutputSelector", "PayPalEmailAddress"),
                    new XElement(ebayNs + "OutputSelector", "SellingStatus"),
                    new XElement(ebayNs + "OutputSelector", "HitCount"),
                    new XElement(ebayNs + "OutputSelector", "BuyItNowPrice"),
                    new XElement(ebayNs + "OutputSelector", "StartPrice")
                    );
                AddCredentials(accountName, input);
                XElement output = MakeCall("GetItem", input);
                XElement itemElement = output.Element(ebayNs + "Item");
                listing = AddOrUpdateItem(context, itemElement, accountName, null, null);
            }
            else
            {
                listing = listingQuery.First();
            }

            return listing;
        }

        public void ProcessAuctionCheckoutComplete(XElement element)
        {
            List<EbayOrderdetail> orderDetails = new List<EbayOrderdetail>();
            using (ERPContext context = new ERPContext(m_connectionString))
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
                        GetOrder(context, accountName, orderId, orderDetails);
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
                            ebayOrder.EbayPaystatus = (string)transaction.Element(ebayNs + "Status").Element(ebayNs + "CompleteStatus");
                            ebayOrder.EBayPaymentStatus = (string)transaction.Element(ebayNs + "Status").Element(ebayNs + "eBayPaymentStatus");
                            ebayOrder.EbayOrdersn = orderId;
                            XElement externalTransactionElement = transaction.Element(ebayNs + "ExternalTransaction");
                            if (externalTransactionElement != null)
                            {
                                ebayOrder.EbayPtid = (string)externalTransactionElement.Element(ebayNs + "ExternalTransactionID");
                            }
                            ebayOrder.EbayOrderid = orderId;
                            string createdTime = (string)transaction.Element(ebayNs + "CreatedDate");
                            ebayOrder.EbayCreatedtime = DateUtils.ConvertToUnixTime(DateTime.Parse(createdTime));
                            string paidTime = (string)transaction.Element(ebayNs + "PaidTime");
                            ebayOrder.EbayPaidtime = DateUtils.ConvertToUnixTime(DateTime.Parse(paidTime)).ToString();
                            ebayOrder.EbayAddtime = DateUtils.ConvertToUnixTime(DateTime.Now);
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
                            if (ebayOrder.EbayCouny == "US")
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
                            m_logger.Info("Proccess ebay order " + ebayOrder.EbayUsername);
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
                        XElement variationElement = transaction.Element(ebayNs + "Variation");
                        if (variationElement != null)
                        {
                            ebayOrderdetail.Sku = (string)variationElement.Element(ebayNs + "SKU");
                            ebayOrderdetail.EbayItemtitle = (string)variationElement.Element(ebayNs + "VariationTitle");
                            ebayOrderdetail.EbayItemurl = (string)variationElement.Element(ebayNs + "VariationViewItemURL");
                        }
                        else
                        {
                            ebayOrderdetail.Sku = (string)item.Element(ebayNs + "SKU");
                            ebayOrderdetail.EbayItemtitle = (string)item.Element(ebayNs + "Title");
                            ebayOrderdetail.EbayItemurl = (string)item.Element(ebayNs + "ListingDetails").Element(ebayNs + "ViewItemURL");
                        }
                        if (ebayOrderdetail.Sku == null)
                        {
                            continue;
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
                        orderDetails.Add(ebayOrderdetail);
                        m_logger.Info(ebayOrderdetail.Sku + "," + ebayOrderdetail.EbayAmount);
                    }

                }

                context.SaveChanges();

                // Update listing
                m_platformServiceFactory.GetOrderService(m_company).UpdateListings(context, orderDetails);
            }
        }


        public void ProcessMessage(XElement element)
        {
            using (ERPContext context = new ERPContext(m_connectionString))
            {
                EbayMessage message = new EbayMessage();
                foreach (XElement messageElement in element.Descendants(ebayNs + "Message"))
                {
                    string sender = (string)messageElement.Element(ebayNs + "Sender");
                    message.MessageId = (string)messageElement.Element(ebayNs + "MessageID");
                    m_logger.Info("Processing message " + message.MessageId);
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
            m_logger.Info("Processing ItemListed " + itemId);
            using (ERPContext context = new ERPContext(m_connectionString))
            {
                var q = from ebayList in context.EbayList
                        where ebayList.ItemId == itemId
                        select ebayList;
                if (q.Count() == 0)
                {
                    EbayList listing = new EbayList();
                    context.EbayList.Add(listing);
                    listing.ItemId = (string)item.Element(ebayNs + "ItemID"); ;
                    listing.Sku = (string)item.Element(ebayNs + "SKU");
                    listing.Title = (string)item.Element(ebayNs + "Title");
                    listing.ListingType = (string)item.Element(ebayNs + "ListingType");
                    listing.TimeLeft = (string)item.Element(ebayNs + "TimeLeft");
                    listing.Quantity = (string)item.Element(ebayNs + "Quantity");
                    int quantity = 0;
                    bool success = int.TryParse(listing.Quantity, out quantity);
                    if (!success)
                    {
                        m_logger.Error("Invalid Quantity " + listing.Quantity + " for item " + listing.ItemId);
                    }
                    listing.QuantityAvailable = quantity;
                    listing.QuantitySold = 0;
                    listing.StartPrice = (string)item.Element(ebayNs + "StartPrice");
                    listing.GalleryUrl = (string)item.Element(ebayNs + "PictureDetails").Element(ebayNs + "GalleryURL");
                    listing.Location = (string)item.Element(ebayNs + "Location");
                    listing.ViewItemUrl = (string)item.Element(ebayNs + "ListingDetails").Element(ebayNs + "ViewItemURL");
                    XElement sellerElement = item.Element(ebayNs + "Seller");
                    if (sellerElement != null)
                    {
                        listing.EbayAccount = (string)sellerElement.Element(ebayNs + "UserID");
                    }
                    else
                    {
                        m_logger.Error("Seller element does not exist");
                    }
                    listing.EbayUser = "vipadmin";
                    listing.PayPalEmailAddress = (string)item.Element(ebayNs + "PayPalEmailAddress");
                    listing.Active = true;

                    IEnumerable<XElement> variations = item.Descendants(ebayNs + "Variation");
                    if (variations != null && variations.Count() > 0)
                    {
                        foreach (XElement variation in variations)
                        {
                            EbayListvariations listVariation = new EbayListvariations();
                            context.EbayListvariations.Add(listVariation);
                            listVariation.Sku = (string)variation.Element(ebayNs + "SKU");
                            listVariation.Quantity = (string)variation.Element(ebayNs + "Quantity");
                            quantity = 0;
                            success = int.TryParse(listing.Quantity, out quantity);
                            if (!success)
                            {
                                m_logger.Error("Invalid Quantity " + listing.Quantity + " for item " + listing.ItemId+", SKU "+listVariation.Sku);
                            }
                            listVariation.QuantityAvailable = quantity;
                            listVariation.QuantitySold = 0;
                            listVariation.Itemid = listing.ItemId;
                            listVariation.EbayAccount = listing.EbayAccount;
                            listVariation.EbayUser = "vipadmin";
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public void ProcessItemClosed(XElement element)
        {
            XElement item = element.Element(ebayNs + "Item");
            string itemId = (string)item.Element(ebayNs + "ItemID");
            m_logger.Info("Processing ItemClosed" + itemId);
            using (ERPContext context = new ERPContext(m_connectionString))
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

        public void SetNotificationPreferences(string url, bool enable, string[] eventTypes)
        {
            foreach( string accountName in m_ebayTokenDictionary.Keys)
            {
                SetNotificationPreferences(accountName, url, enable, eventTypes);
            }
        }

        public void SetNotificationPreferences(string ebayAccount, string url, bool enable, string[] eventTypes)
        {

            XElement input = new XElement(ebayNs+ "SetNotificationPreferencesRequest",
                                new XElement(ebayNs+ "ApplicationDeliveryPreferences",
                                    new XElement(ebayNs+ "ApplicationEnable", enable?"Enable":"Disable"),
                                    new XElement(ebayNs+ "ApplicationURL", url)));
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

        public void GetNotificationsUsage(string ebayAccount)
        {
            string startTime = DateTime.Now.AddHours(-9).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
            string endTime = DateTime.Now.AddHours(-1).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
            XElement input = new XElement(ebayNs + "GetNotificationsUsageRequest",
                new XElement( ebayNs + "startTime", startTime),
                new XElement( ebayNs + "endTime", endTime));
            AddCredentials(ebayAccount, input);
            XElement output = MakeCall("GetNotificationsUsage", input);
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

        private bool isUSLocation( string location )
        {
            string loc = location.ToUpper();
            return loc.Contains("MASON") || location.Contains("KENTUCKY") || location.Contains("UNITED STATES") || location.Contains("WEST CHESTER") || location.Contains("MIDDLETOWN");

        }


        public void UpdateListingQuantities(ERPContext context, string sku, int warehouseQuantity )
        {
            var listingQuery = from ebayList in context.EbayList
                               where ebayList.Sku == sku
                               where ebayList.ListingType == "FixedPriceItem"
                               select ebayList;
            if (listingQuery.Count() > 0)
            {
                foreach (EbayList listing in listingQuery)
                {
                    if (isUSLocation(listing.Location))
                    {
                        int newQuantity = 0;
                        m_logger.Info(listing.EbayAccount + ": " + listing.Sku + " listing quantity: " + listing.QuantityAvailable.GetValueOrDefault() + " warehouse quantity: " + warehouseQuantity);

                        bool update = m_platformServiceFactory.GetInventoryService(m_company).GetNewQuantity( sku, 0, listing.QuantityAvailable.GetValueOrDefault(), warehouseQuantity, out newQuantity);
                        if (update)
                        {
                            listing.QuantityAvailable = newQuantity;
                            ReviseVariationQuantity( listing.EbayAccount, listing.ItemId, sku, newQuantity);

                            m_logger.Info(listing.EbayAccount + ": Quantity of " + listing.Sku + " has been changed from " + listing.QuantityAvailable.GetValueOrDefault() + " to " + newQuantity);
                        }
                    }
                }
            }
            else
            {
                // Check if sku has variations
                var variantQ = from ebayListvariations in context.EbayListvariations
                               from ebayList in context.EbayList
                               where ebayListvariations.Sku == sku
                               where ebayListvariations.Itemid == ebayList.ItemId
                               select new { ebayList, ebayListvariations };
                if (variantQ.Count() > 0)
                {
                    foreach (var row in variantQ)
                    {
                        string location = row.ebayList.Location.ToUpper();
                        if (isUSLocation(row.ebayList.Location))
                        {
                            int newQuantity = 0;
                            m_logger.Info(row.ebayList.EbayAccount + ": " + row.ebayListvariations.Sku + " listing quantity: " + row.ebayListvariations.QuantityAvailable.GetValueOrDefault() + " warehouse quantity: " + warehouseQuantity);
                            bool update = m_platformServiceFactory.GetInventoryService(m_company).GetNewQuantity(sku, 0, row.ebayListvariations.QuantityAvailable.GetValueOrDefault(), warehouseQuantity, out newQuantity);
                            if (update)
                            {
                                ReviseVariationQuantity(row.ebayList.EbayAccount, row.ebayList.ItemId, sku, warehouseQuantity);

                                m_logger.Info(row.ebayList.EbayAccount + ": Quantity of " + row.ebayListvariations.Sku + " has been changed from " + row.ebayListvariations.QuantityAvailable.GetValueOrDefault() + " to " + newQuantity);
                            }
                        }
                    }
                }
            }
        }
        public void CompleteSale(int orderId)
        {
            using (ERPContext context = new ERPContext(m_connectionString))
            {
                bool success = true;
                var q = from ebayOrder in context.EbayOrder
                        from ebayOrderDetail in context.EbayOrderdetail
                        where ebayOrder.EbayOrdersn == ebayOrderDetail.EbayOrdersn
                        where ebayOrder.EbayId == orderId
                        select new { ebayOrder, ebayOrderDetail};
                if (q.Count() > 0)
                {
                    foreach (var row in q)
                    {
                        if (row.ebayOrder.EbayOrderid != null && row.ebayOrder.EbayOrderid.Length > 0)
                        {
                            XElement element = new XElement(ebayNs + "CompleteSaleRequest",
                                new XElement(ebayNs + "ItemID", row.ebayOrderDetail.EbayItemid),
                                new XElement(ebayNs + "TransactionID", row.ebayOrder.EbayTid),
                                new XElement(ebayNs + "OrderID", row.ebayOrder.EbayOrderid),
                                new XElement(ebayNs + "Paid", "true"),
                                new XElement(ebayNs + "Shipped", "true")
                                );
                            if (row.ebayOrder.EbayTracknumber != null && row.ebayOrder.EbayCarrier != null && row.ebayOrder.EbayTracknumber.Length > 0 && row.ebayOrder.EbayCarrier.Length > 0)
                            {
                                element.Add(new XElement(ebayNs + "Shipment",
                                                new XElement(ebayNs + "ShipmentTrackingDetails",
                                                    new XElement(ebayNs + "ShipmentTrackingNumber", row.ebayOrder.EbayTracknumber),
                                                    new XElement(ebayNs + "ShippingCarrierUsed", row.ebayOrder.EbayCarrier))));
                            }

                            AddCredentials(row.ebayOrder.EbayAccount, element);
                            XElement output = MakeCall("CompleteSale", element);
                            if (output == null)
                            {
                                success = false;
                            }
                        }
                    }

                    if(success)
                    {
                        EbayOrder order = q.First().ebayOrder;
                        order.EbayMarkettime = DateUtils.ConvertToUnixTime(DateTime.Now).ToString();
                        order.ShippedTime = order.EbayMarkettime;
                        context.SaveChanges();
                    }
                }
            }
        }


        public void ProcessPlatformNotification(string notificationEventName, XElement childElement)
        {
            if (notificationEventName == "AuctionCheckoutComplete")
            {
                ProcessAuctionCheckoutComplete(childElement);
            }
            else if (notificationEventName == "MyMessageseBayMessage" || notificationEventName == "MyMessagesM2MMessage")
            {
                ProcessMessage(childElement);
            }
            else if (notificationEventName == "ItemListed")
            {
                ProcessItemListed(childElement);
            }
            else if (notificationEventName == "ItemClosed")
            {
                ProcessItemClosed(childElement);
            }
        }

        public void UpdateListingQuantities(ERPContext context, string ebayAccount, Dictionary<string, int> inventoryDictionary, Dictionary<string, Dictionary<string, int>> productCombineDictionary)
        { 
            var variantQ = from ebayListvariations in context.EbayListvariations
                            from ebayList in context.EbayList
                            where ebayListvariations.Itemid == ebayList.ItemId
                            select new { ebayListvariations, ebayList };
            if( ebayAccount.ToUpper() != "ALL")
            {
                variantQ = from a in variantQ
                           where a.ebayList.EbayAccount == ebayAccount
                           select a;
            }
            foreach(var row in variantQ)
            {
                if( isUSLocation( row.ebayList.Location))
                {
                    int oldQuantity = row.ebayListvariations.QuantityAvailable.GetValueOrDefault();
                    int newQuantity = 0;
                    int warehouseQuantity = 0;
                    m_logger.Info(ebayAccount + ": " + row.ebayListvariations.Sku + " listing quantity: " + oldQuantity + " warehouse quantity: " + warehouseQuantity);
                    bool update = m_platformServiceFactory.GetInventoryService(m_company).GetNewQuantity(inventoryDictionary, productCombineDictionary, row.ebayListvariations.Sku, 0, oldQuantity, out warehouseQuantity, out newQuantity);
                    if ( update )
                    {
                        row.ebayListvariations.QuantityAvailable = newQuantity;
                        ReviseVariationQuantity(row.ebayList.EbayAccount, row.ebayList.ItemId, row.ebayListvariations.Sku, newQuantity);
                        m_logger.Info(ebayAccount + ": Quantity of " + row.ebayListvariations.Sku + " has been changed from " + oldQuantity + " to " + newQuantity);
                    }
                }
            }
                
            var listingQuery = from ebayList in context.EbayList
                    where ebayList.ListingType == "FixedPriceItem"
                    select ebayList;
            if (ebayAccount.ToUpper() != "ALL")
            {
                listingQuery = from a in listingQuery
                               where a.EbayAccount == ebayAccount
                               select a;
            }
            foreach (var row in listingQuery)
            {
                if (isUSLocation(row.Location))
                {
                    int oldQuantity = row.QuantityAvailable.GetValueOrDefault();
                    int newQuantity = 0;
                    int warehouseQuantity = 0;

                    m_logger.Info(ebayAccount + ": " + row.Sku + " listing quantity: " + oldQuantity + " warehouse quantity: " + warehouseQuantity);
                    bool update = m_platformServiceFactory.GetInventoryService(m_company).GetNewQuantity(inventoryDictionary, productCombineDictionary, row.Sku, 0, oldQuantity, out warehouseQuantity, out newQuantity);
                    if (update)
                    {
                        row.QuantityAvailable = newQuantity;
                        ReviseListingQuantity(row.EbayAccount, row.Sku, row.ItemId, newQuantity);

                        m_logger.Info(ebayAccount + ": Quantity of " + row.Sku + " has been changed from " + oldQuantity + " to " + newQuantity);
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
