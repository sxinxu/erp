using erpcore.entities;
using erpcore.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore
{
    public interface IInventoryService
    {
        List<Inventory> GetInventories(string sku);

        void UpdateInventory(int warehouseId, string sku, int quantity);

        bool GetNewQuantity(string sku, int hideQuantity, int oldQuantity, int warehouseQuantity, out int newQuantity);

        bool GetNewQuantity(Dictionary<string, int> inventoryDictionary, Dictionary<string, Dictionary<string, int>> productCombineDictionary, string sku, int hideQuantity, int oldQuantity, out int warehouseQuantity, out int newQuantity);

        bool GetWarehouseQuantity(ERPContext context, string sku, out int quantity);

        List<ShipmentBox> GetShipmentBoxes(string warehouseId, string sku);

        List<Shelve> GetShelves(string warehouseId, string sku);
    }
}
