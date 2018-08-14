using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using erpcore;
using erpcore.models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace erpWebAPI.Controllers
{
    [Produces("application/json")]
    public class OrderController : Controller
    {
        private IPlatformServiceFactory m_platformServiceFactory;


        public OrderController(IPlatformServiceFactory platformServiceFactory, IHostingEnvironment hostingEnvironment)
        {
            m_platformServiceFactory = platformServiceFactory;
            m_platformServiceFactory.ContentRootPath = hostingEnvironment.ContentRootPath;
        }

        [HttpGet("/SearchOrders/{company}/{searchType}/{searchText}")]
        public IActionResult SearchOrder(string company, string searchType, string searchText )
        {
            List<Order> orders = null;
            IOrderService orderService = m_platformServiceFactory.GetOrderService(company);
            if (orderService != null)
            {
                orders = orderService.SearchOrders(searchType, searchText);
            }

            return Ok(orders);
        }

        [HttpGet("/GetOrdersToShip/{company}")]
        public IActionResult GetOrdersToShip(string company)
        {
            List<Order> orders = null;
            IOrderService orderService = m_platformServiceFactory.GetOrderService(company);
            if (orderService != null)
            {
                orders = orderService.GetOrdersToShip();
            }

            return Ok(orders);
        }

        [HttpGet("/Profit/{company=auto}/{dateFilter=all}/{skuFilter=all}/{account=all}")]
        public IActionResult GetProfit(string company, string dateFilter, string skuFilter, string account )
        {
            Profit profit = null;
            IOrderService orderService = m_platformServiceFactory.GetOrderService(company);
            if (orderService != null)
            {
                profit = orderService.GetProfits(dateFilter, skuFilter, account );
            }
            return Ok(profit);
        }

        [HttpGet("UpdateAccountListingQuantities/{company}/{accountName}/{refresh}")]
        public IActionResult UpdateAccountListingQuantities(string company, string accountName, bool refresh)
        {
            IOrderService orderService = m_platformServiceFactory.GetOrderService(company);
            orderService.UpdateAccountListingQuantities(accountName, refresh);

            return Ok();
        }

        [HttpGet("UpdateSKUListingQuantities/{company}/{sku}")]
        public IActionResult UpdateSKUListingQuantities(string company, string sku)
        {
            IOrderService orderService = m_platformServiceFactory.GetOrderService(company);
            orderService.UpdateSKUListingQuantities(sku);

            return Ok();
        }

        [HttpGet("SyncOrders/{company}/{accountName}/{createdTimeFrom}/{createdTimeTo}")]
        public IActionResult SyncOrders(string company, string accountName, string createdTimeFrom, string createdTimeTo )
        {
            IOrderService orderService = m_platformServiceFactory.GetOrderService(company);
            List<string> accountNames = accountName.Split(',').ToList();
            DateTime from;
            bool success = DateTime.TryParse(createdTimeFrom, out from);
            if( success )
            {
                DateTime to;
                success = DateTime.TryParse(createdTimeTo, out to);
                if( success )
                {
                    orderService.SyncOrders(accountNames, from, to);
                }
            }
            return Ok();
        }
    }
}
