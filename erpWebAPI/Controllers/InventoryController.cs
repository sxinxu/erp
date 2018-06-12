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
    public class InventoryController : ControllerBase
    {
        private IPlatformServiceFactory m_platformServiceFactory;
        public InventoryController(IPlatformServiceFactory platformServiceFactory)
        {
            m_platformServiceFactory = platformServiceFactory;
        }

        [HttpGet("Inventory/GetInventories/{company}/{sku}")]
        public IActionResult GetInventories(string company, string sku)
        {
            List<Inventory> inventories = null;
            IInventoryService inventoryService = m_platformServiceFactory.GetInventoryService(company);
            if (inventoryService != null)
            {
                inventories = inventoryService.GetInventories(sku);
            }

            return Ok(inventories);
        }

        [HttpGet("Inventory/UpdateInventory/{company}/{warehouseId}/{sku}/{quantity}")]
        public IActionResult UpdateInventory(string company, int warehouseId, string sku, int quantity)
        {
            IInventoryService inventoryService = m_platformServiceFactory.GetInventoryService(company);
            if (inventoryService != null)
            {
                inventoryService.UpdateInventory(warehouseId, sku, quantity);
            }

            return Ok();
        }
    }
}
