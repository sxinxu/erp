using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using erpcore;
using erpcore.models;
using Microsoft.AspNetCore.Mvc;
using NLog;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace erp.Controllers
{
    [Produces("application/json")]
    public class EbayServiceController : ControllerBase
    {
        private IPlatformServiceFactory m_platformServiceFactory;
        private static Logger m_logger = NLog.LogManager.GetCurrentClassLogger();
        private const string ebayNs = "{urn:ebay:apis:eBLBaseComponents}";

        public EbayServiceController(IPlatformServiceFactory platformServiceFactory)
        {
            m_platformServiceFactory = platformServiceFactory;
        }

        [HttpGet("CompleteSale/{company}/{orderId}")]
        public IActionResult CompleteSale(string company, string ebayAccountName, int orderId)
        {
            IEbayService ebayService = m_platformServiceFactory.GetEbayService(company);
            ebayService.CompleteSale(orderId);

            return Ok();
        }


        [HttpPost("EbayNotification")]
        public async Task<IActionResult> ProcessPlatformNotification()
        {
            string body = null;
            using (var reader = new StreamReader(Request.Body))
            {
                body = await reader.ReadToEndAsync();
                XNamespace soapNs = "http://schemas.xmlsoap.org/soap/envelope/";
                XElement root = XElement.Parse(body);
                IEnumerable<XElement> elements = from el in root.Descendants(soapNs + "Body")
                                                    select el;
                if (elements != null && elements.Count() == 1)
                {
                    XElement element = elements.First();
                    IEnumerable<XElement> childElements = element.Elements();
                    if (childElements.Count() == 1)
                    {
                        XElement childElement = childElements.First();
                        string notificationEventName = (string)childElement.Element(ebayNs + "NotificationEventName");
                        string accountName = (string)childElement.Element(ebayNs + "RecipientUserID");
                        m_logger.Info("Processing "+accountName+" " + notificationEventName + " event");
                        IEbayService ebayService = m_platformServiceFactory.GetEbayServiceByAccount(accountName);
                        if( ebayService != null )
                        {
                            ebayService.ProcessPlatformNotification(notificationEventName, childElement);
                        }
                    }
                }
            }

            return Ok();
        }

        [HttpGet("SetNotificationPreferences/{company}/{account}/{enable}")]
        public IActionResult SetNotificationPreferences(string company, string account, bool enable)
        {
            string baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
            string url = baseUrl+"/EbayNotification";
            string[] eventTypes = { "AuctionCheckoutComplete", "MyMessageseBayMessage", "MyMessagesM2MMessage", "ItemListed", "ItemClosed" };
            IEbayService ebayService = m_platformServiceFactory.GetEbayService(company);
            if( ebayService != null )
            {
                if( account.ToUpper() == "ALL")
                {
                    ebayService.SetNotificationPreferences(url, enable, eventTypes);
                }
                else
                {
                    ebayService.SetNotificationPreferences(account, url, enable, eventTypes);
                }
            }

            return Ok();
        }

        [HttpGet("GetNotificationPreferences/{company}/{account}")]
        public IActionResult GetNotificationPreferences( string company, string account )
        {
            List<string> enabledNotificationTypes = new List<string>();
            IEbayService ebayService = m_platformServiceFactory.GetEbayService(company);
            if (ebayService != null)
            {
                enabledNotificationTypes = ebayService.GetEnabledNotificationTypes(account);
            }

            return Ok( enabledNotificationTypes);
        }

        [HttpGet("GetNotificationsUsage/{company}/{account}")]
        public IActionResult GetNotificationsUsage(string company, string account)
        {
            IEbayService ebayService = m_platformServiceFactory.GetEbayService(company);
            if (ebayService != null)
            {
                ebayService.GetNotificationsUsage(account);
            }

            return Ok();
        }
    }
}
