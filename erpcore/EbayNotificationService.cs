using erpcore.entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace erpcore
{
    public class EbayNotificationService
    {
        private EbayService m_service = new EbayService();
        private const string ebayNs = "{urn:ebay:apis:eBLBaseComponents}";
        private v3_allContext m_context = new v3_allContext();
        private static Logger m_logger = NLog.LogManager.GetCurrentClassLogger();

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
                    m_logger.Info("Processing "+ notificationEventName+" event");
                    if (notificationEventName == "AuctionCheckoutComplete")
                    {
                        m_service.ProcessAuctionCheckoutComplete(childElement);
                    }
                    else if (notificationEventName == "MyMessageseBayMessage" || notificationEventName == "MyMessagesM2MMessage")
                    {
                        m_service.ProcessMessage(childElement);
                    }
                    else if (notificationEventName == "ItemListed")
                    {
                        m_service.ProcessItemListed(childElement);
                    }
                    else if (notificationEventName == "ItemClosed")
                    {
                        m_service.ProcessItemClosed(childElement);
                    }
                }
            }
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


    }
}
