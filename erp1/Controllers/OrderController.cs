using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using erpcore;
using erpcore.models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace erp.Controllers
{
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private IPlatformServiceFactory m_platformServiceFactory;
        public OrderController(IPlatformServiceFactory platformServiceFactory)
        {
            m_platformServiceFactory = platformServiceFactory;
        }

        [HttpGet("/Order/GetOrdersToShip/{company}")]
        public ActionResult<List<Order>> GetOrdersToShip(string company)
        {
            List<Order> orders = null;
            IOrderService orderService = m_platformServiceFactory.GetOrderService(company);
            if (orderService != null)
            {
                orders = orderService.GetOrdersToShip();
            }

            return orders;
        }

    }
}
