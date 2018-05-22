using erpcore.entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;
using System.Xml.Linq;

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
        private v3_allContext m_context = new v3_allContext();

        public EbayService()
        {
        }

        public void GetSellerList( string ebayAccount )
        {
            DateTime startTimeTo = DateTime.Now;
            DateTime startTimeFrom = DateTime.Now.AddDays(-120);
            Dictionary<string, EbayList> ebayListDictionary = new Dictionary<string, EbayList>();
            
            var q = from ebayList in m_context.EbayList
                    where ebayList.EbayAccount == ebayAccount
                    select ebayList;
            foreach(var listing in q)
            {
                ebayListDictionary[listing.ItemId] = listing;
            }

            for( int i = 0; i < 6; i++ )
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
                        }
                        else
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
                            listing.EbayAccount = ebayAccount;
                            listing.EbayUser = "vipadmin";
                            listing.PayPalEmailAddress = (string)item.Element(ebayNs + "PayPalEmailAddress");
                            listing.Active = true;
                            m_context.EbayList.Add(listing);
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

            foreach(string itemId in ebayListDictionary.Keys)
            {
                m_context.EbayList.Remove(ebayListDictionary[itemId]);
            }

            m_context.SaveChanges();
        }

        public bool isPlatformNotificationEnabled(string ebayAccount)
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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Headers.Add("X-EBAY-API-DEV-NAME", devId);
            request.Headers.Add("X-EBAY-API-APP-NAME", appId);
            request.Headers.Add("X-EBAY-API-CERT-NAME", certId);
            request.Headers.Add("X-EBAY-API-CALL-NAME", method);
            request.Headers.Add("X-EBAY-API-COMPATIBILITY-LEVEL", "967");
            request.Headers.Add("X-EBAY-API-SITEID", "0");
            input.Save(request.GetRequestStream());

            for (int i = 0; i < retryCount; i++)
            {
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
            else
            {
                var q = from account in m_context.EbayAccount
                        where account.EbayAccount1 == ebayAccount
                        select account;
                if( q.Count() > 0)
                {
                    ebayToken = q.First().EbayToken2;
                    m_ebayTokenDictionary[ebayAccount] = ebayToken;
                }
            }
            return ebayToken;
        }

        public void updateListingQuantities( string sku, int quantity )
        {

        }
    }
}
