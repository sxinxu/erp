using erpcore.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore
{
    public interface IInventoryService
    {
        void UpdateListingQuantities(string sku, int quantity);

        List<Inventory> GetInventories(string sku);

        void UpdateInventory(int warehouseId, string sku, int quantity);
    }
}
