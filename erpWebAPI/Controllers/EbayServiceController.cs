using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using erpcore;
using erpcore.models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace erp.Controllers
{
    [Produces("application/json")]
    public class EbayServiceController : ControllerBase
    {
        private IPlatformServiceFactory m_platformServiceFactory;
        public EbayServiceController(IPlatformServiceFactory platformServiceFactory)
        {
            m_platformServiceFactory = platformServiceFactory;
        }

        [HttpGet("ebay/CompleteSale/{company}/{orderId}")]
        public IActionResult CompleteSale(string company, string ebayAccountName, int orderId)
        {
            IEbayService ebayService = m_platformServiceFactory.GetEbayService(company);
            ebayService.CompleteSale(orderId);

            return Ok();
        }


        [HttpPost("/ebay/EbayNotification/{company}")]
        public async Task<IActionResult> ProcessPlatformNotification(string company)
        {
            IEbayService ebayService = m_platformServiceFactory.GetEbayService(company);
            if (ebayService != null)
            {
                string body = null;
                using (var reader = new StreamReader(Request.Body))
                {
                    body = await reader.ReadToEndAsync();
                    ebayService.ProcessPlatformNotification(body);
                }
            }
            return Ok();
        }

    }
}
