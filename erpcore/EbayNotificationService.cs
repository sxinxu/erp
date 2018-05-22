using erpcore.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace erpcore
{
    public class EbayNotificationService
    {
        private const string ebayNs = "{urn:ebay:apis:eBLBaseComponents}";
        private v3_allContext m_context = new v3_allContext();

        public void Process(string content)
        {
            XNamespace soapNs = "http://schemas.xmlsoap.org/soap/envelope/";
            XElement root = XElement.Parse(content);
            IEnumerable<XElement> elements = from el in root.Descendants(soapNs + "Body")
                                             select el;
            if (elements != null && elements.Count() == 1)
            {
                XElement element = elements.First();
                IEnumerable<XElement> childElements = element.Elements();
                if (childElements.Count() == 1)
                {
                    XElement childElement = childElements.First();
                    string notificationEventName = (string)childElement.Element(ebayNs+"NotificationEventName");
                    if (notificationEventName == "FixedPriceTransaction")
                    {
                        FixedPriceTransaction(childElement);
                    }
                    else if (notificationEventName == "AskSellerQuestion")
                    {

                    }
                    else if (notificationEventName == "ItemListed")
                    {

                    }
                }
            }
        }

        private void FixedPriceTransaction(XElement element)
        {
            XElement item = element.Element(ebayNs + "Item");
            string accountName = item.Element(ebayNs + "Seller").Element(ebayNs + "UserID").Value;
            IEnumerable<XElement> transactions = element.Descendants(ebayNs + "Transaction");
            foreach (XElement transaction in transactions)
            {
                string orderId = (string)transaction.Element(ebayNs + "ContainingOrder").Element(ebayNs + "OrderID");
                string recordNumber = (string)transaction.Element(ebayNs + "ShippingDetails").Element(ebayNs + "SellingManagerSalesRecordNumber");
                EbayOrder ebayOrder = null;
                var query = from order in m_context.EbayOrder
                            where order.EbayOrdersn == orderId
                            select order;
                if (query.Count() == 0)
                {
                    ebayOrder = new EbayOrder();
                    ebayOrder.EbayPaystatus = (string)transaction.Element(ebayNs + "Status").Element(ebayNs + "eBayPaymentStatus");
                    ebayOrder.EbayOrdersn = orderId;
                    XElement externalTransactionElement = transaction.Element(ebayNs + "ExternalTransaction");
                    if(externalTransactionElement != null)
                    {
                        ebayOrder.EbayPtid = (string)externalTransactionElement.Element(ebayNs + "ExternalTransactionID");
                    }
                    ebayOrder.EbayOrderid = orderId;
                    ebayOrder.EbayCreatedtime = convertToUnixTime(DateTime.Now);
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

                    m_context.EbayOrder.Add(ebayOrder);
                }

                EbayOrderdetail ebayOrderdetail = null;
                var orderDetailQuery = from orderDetail in m_context.EbayOrderdetail
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
                ebayOrderdetail.OrderLineItemId = (string)transaction.Element(ebayNs + "OrderLineItemID");
                ebayOrderdetail.EbayOrdersn = orderId;
                ebayOrderdetail.Recordnumber = recordNumber;
                ebayOrderdetail.EbayItemprice = (string)transaction.Element(ebayNs + "TransactionPrice");
                ebayOrderdetail.EbayAmount = (string)transaction.Element(ebayNs + "QuantityPurchased");
                ebayOrderdetail.EbayCreatedtime = convertToUnixTime(DateTime.Now);
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
                ebayOrderdetail.Addtime = convertToUnixTime(DateTime.Now).ToString();
                ebayOrderdetail.EbayTid = (string)transaction.Element(ebayNs + "TransactionID");
                ebayOrderdetail.FeeOrCreditAmount = (string)transaction.Element(ebayNs + "MonetaryDetails").Element(ebayNs + "Payments").Element(ebayNs + "Payment").Element(ebayNs + "FeeOrCreditAmount");
                ebayOrderdetail.FinalValueFee = float.Parse((string)transaction.Element(ebayNs + "FinalValueFee"));
                ebayOrderdetail.PayPalEmailAddress = (string)transaction.Element(ebayNs + "PayPalEmailAddress");
                ebayOrderdetail.ListingType = (string)item.Element(ebayNs + "ListingType");
                m_context.EbayOrderdetail.Add(ebayOrderdetail);
            }

            m_context.SaveChanges();
        }

        private void AskSellerQuestion(XElement element)
        {
            EbayMessage message = new EbayMessage();
            XElement question = element.Element(ebayNs + "Question");
            XElement item = element.Element(ebayNs + "Item");
            message.ExternalMessageId = (string)question.Element(ebayNs + "MessageID");
            message.MessageType = "AskSellerQuestion";
            message.Recipientid = (string)question.Element(ebayNs + "RecipientID");
            var q = from messageCategory in m_context.EbayMessagecategory
                    where messageCategory.CategoryName == message.Recipientid
                    select messageCategory;
            int classId = 0;
            if( q.Count() == 0)
            {
                EbayMessagecategory ebayMessageCategory = new EbayMessagecategory();
                ebayMessageCategory.CategoryName = message.Recipientid;
                ebayMessageCategory.EbayNote = message.Recipientid;
                ebayMessageCategory.EbayUser = "vipadmin";
                m_context.SaveChanges();
                var q1 = from messageCategory in m_context.EbayMessagecategory
                        where messageCategory.CategoryName == message.Recipientid
                        select messageCategory;
                classId = q1.First().Id;
            }
            else
            {
                classId = q.First().Id;
            }

            message.Sendid = (string)question.Element(ebayNs + "SenderID");
            message.Sendmail = (string)question.Element(ebayNs + "SenderEmail");
            message.QuestionType = (string)question.Element(ebayNs + "QuestionType");
            message.Subject = (string)question.Element(ebayNs + "Subject");
            message.Body = (string)question.Element(ebayNs + "Body");
            message.Itemid = (string)item.Element(ebayNs + "ItemID");
            message.Title = (string)item.Element(ebayNs + "Title");
            message.Createtime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            message.Createtime1 = convertToUnixTime(DateTime.Now);
            message.AddTime = convertToUnixTime(DateTime.Now);
            message.EbayUser = "vipadmin";
            message.Classid = classId;

            m_context.SaveChanges();
        }

        private void Itemlisted(XElement element)
        {
            XElement item = element.Element(ebayNs + "Item");
            string itemId = (string)item.Element(ebayNs + "ItemID");
            var q = from ebayList in m_context.EbayList
                    where ebayList.ItemId == itemId
                    select ebayList;
            if (q.Count() == 0)
            {
                EbayList listing = new EbayList();
                listing.ItemId = itemId;
                listing.Sku = (string)item.Element(ebayNs + "SKU");
                listing.Title = (string)item.Element(ebayNs + "Title");
                listing.ListingType = (string)item.Element(ebayNs + "ListingType");
                listing.TimeLeft = (string)item.Element(ebayNs + "TimeLeft");
                listing.Quantity = (string)item.Element(ebayNs + "Quantity");
                listing.GalleryUrl = (string)item.Element(ebayNs + "PictureDetails").Element(ebayNs + "GalleryURL");
                listing.Location = (string)item.Element(ebayNs + "Location");
                listing.ViewItemUrl = (string)item.Element(ebayNs + "ListingDetails").Element(ebayNs + "ViewItemURL");
                listing.EbayAccount = (string)item.Element(ebayNs+"Seller").Element(ebayNs+"UserID");
                listing.EbayUser = "vipadmin";
                listing.PayPalEmailAddress = (string)item.Element(ebayNs + "PayPalEmailAddress");
                listing.Active = true;
                m_context.EbayList.Add(listing);
                m_context.SaveChanges();
            }
        }

        private int convertToUnixTime(DateTime dateTime)
        {
            int t = 0;
            DateTime earliestTime = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
            try
            {
                t = Convert.ToInt32((dateTime - earliestTime).TotalSeconds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return t;
        }

    }
}
