using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace erpcore
{
    public class EbayNotificationService
    {
        private const string ebayNs = "{urn:ebay:apis:eBLBaseComponents}";

        public void Process( string content)
        {
            XNamespace soapNs = "http://schemas.xmlsoap.org/soap/envelope/";
            XElement root = XElement.Parse(content);
            IEnumerable<XElement> elements = from el in root.Descendants(soapNs + "Body")
                                select el;
            if( elements != null && elements.Count() == 1 )
            {
                XElement element = elements.First();
                IEnumerable<XElement> childElements = element.Elements();
                if( childElements.Count() == 1 )
                {
                    XElement childElement = childElements.First();
                    if( childElement.Name.LocalName == "GetItemTransactionsResponse")
                    {
                        ProcessGetItemTransactions(childElement);
                    }
                }
            }
        }

        private void ProcessGetItemTransactions( XElement element )
        {
            XElement item = element.Element(ebayNs+"Item");
            string itemId = item.Element(ebayNs + "ItemID").Value;
            string accountName = item.Element(ebayNs + "Seller").Element(ebayNs + "UserID").Value;
            IEnumerable<XElement> transactions = element.Descendants(ebayNs + "Transaction");
            foreach(XElement transaction in transactions)
            {
                string orderId = (string)transaction.Element(ebayNs + "ContainingOrder").Element(ebayNs + "OrderID");
                string orderLineItemId = (string)transaction.Element(ebayNs + "OrderLineItemID");
                string recordNumber = (string)transaction.Element(ebayNs + "ShippingDetails").Element(ebayNs + "SellingManagerSalesRecordNumber");
                string orderStatus = (string)transaction.Element(ebayNs + "ContainingOrder").Element(ebayNs + "OrderStatus");
                string createdTime = (string)element.Element(ebayNs + "Timestamp");
                string paidTime = (string)transaction.Element(ebayNs + "PaidTime");
                XElement buyer = transaction.Element(ebayNs + "Buyer");
                string userId = (string)buyer.Element(ebayNs + "UserID");
                XElement shippingAddress = buyer.Element(ebayNs + "BuyerInfo").Element(ebayNs + "ShippingAddress");
                string userName = (string)shippingAddress.Element(ebayNs + "Name");
                string email = (string)buyer.Element(ebayNs + "Email");
                string street = (string)shippingAddress.Element(ebayNs + "Street1");
                string street2 = (string)shippingAddress.Element(ebayNs + "Street2");
                string city = (string)shippingAddress.Element(ebayNs + "CityName");
                string state = (string)shippingAddress.Element(ebayNs + "StateOrProvince");
                string country = (string)shippingAddress.Element(ebayNs + "Country");
                string countryName = (string)shippingAddress.Element(ebayNs + "CountryName");
                string postCode = (string)shippingAddress.Element(ebayNs + "PostalCode");
                string phone = (string)shippingAddress.Element(ebayNs + "Phone");
                string currency = (string)item.Element(ebayNs + "Currency");
                string shipFee = (string)transaction.Element(ebayNs + "ActualShippingCost");
                string eBayPaymentStatus = (string)transaction.Element(ebayNs + "Status").Element(ebayNs + "eBayPaymentStatus");
            }
        }
    }
}
