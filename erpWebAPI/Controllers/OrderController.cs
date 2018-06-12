using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using erpcore;
using erpcore.models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace erpWebAPI.Controllers
{
    [Produces("application/json")]
    public class OrderController : Controller
    {
        private IPlatformServiceFactory m_platformServiceFactory;
        private IHostingEnvironment hostingEnvironment;
        public OrderController(IPlatformServiceFactory platformServiceFactory, IHostingEnvironment hostingEnvironment)
        {
            m_platformServiceFactory = platformServiceFactory;
            m_platformServiceFactory.ContentRootPath = hostingEnvironment.ContentRootPath;
        }

        [HttpGet("/Order/GetOrdersToShip/{company}")]
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

        [HttpGet("/Profit/{company=auto}/{filter=all}/{account=all}")]
        public IActionResult GetProfit(string company, string filter, string account)
        {
            Profit profit = null;
            IOrderService orderService = m_platformServiceFactory.GetOrderService(company);
            if (orderService != null)
            {
                profit = orderService.GetProfits(filter, account);
            }

            return Ok(profit);
        }
    }
}
