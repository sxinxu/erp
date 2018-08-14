using erpcore.entities;
using erpcore.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NLog;

namespace erpcore
{
    public class InventoryService :IInventoryService
    {
        private IPlatformServiceFactory m_platformServiceFactory;
        private string m_company;
        private string m_connectionString;
        private int[] m_warehouseIds = { 101, 108 };
        private static Logger m_logger = NLog.LogManager.GetCurrentClassLogger();

        public InventoryService(IPlatformServiceFactory platformServiceFactory, string company, string connectionString)
        {
            m_platformServiceFactory = platformServiceFactory;
            m_company = company;
            m_connectionString = connectionString;
        }

        public List<Inventory> GetInventories(string sku)
        {
            m_logger.Info("Get inventory of " + sku);
            List<Inventory> inventories = new List<Inventory>();

            using (ERPContext context = new ERPContext(m_connectionString))
            {
                var q = from ebayOnHandle in context.EbayOnhandle
                        from ebayStore in context.EbayStore
                        where ebayOnHandle.GoodsSn.ToUpper().StartsWith(sku.ToUpper())
                        where ebayStore.Id == ebayOnHandle.StoreId
                        where m_warehouseIds.Contains(ebayOnHandle.StoreId)
                        orderby ebayOnHandle.GoodsSn, ebayStore.StoreName
                        select new Inventory
                        {
                            SKU = ebayOnHandle.GoodsSn,
                            Quantity = ebayOnHandle.GoodsCount.GetValueOrDefault(),
                            Warehouse = ebayStore.StoreName,
                            WarehouseId = ebayOnHandle.StoreId
                        };
                inventories.AddRange(q);
            }

            return inventories;
        }

        public void UpdateInventory(int warehouseId, string sku, int quantity )
        {
            using (ERPContext context = new ERPContext(m_connectionString))
            {
                var q = from ebayOnHandle in context.EbayOnhandle
                        where ebayOnHandle.GoodsSn == sku
                        where ebayOnHandle.StoreId == warehouseId
                        select ebayOnHandle;
                if(q.Count() == 1)
                {
                    q.First().GoodsCount = quantity;
                    context.SaveChanges();
                }
            }
        }


        public bool GetNewQuantity(Dictionary<string, int> inventoryDictionary, Dictionary<string, Dictionary<string, int>> productCombineDictionary, string sku, int hideQuantity, int oldQuantity, out int warehouseQuantity, out int newQuantity)
        {
            bool update = false;
            newQuantity = 0;
            warehouseQuantity = 0;
            if (productCombineDictionary.ContainsKey(sku))
            {
                Dictionary<string, int> subSkus = productCombineDictionary[sku];
                warehouseQuantity = 9999;
                foreach (string subSku in subSkus.Keys)
                {
                    int subSkuQuantity = subSkus[subSku];
                    if (inventoryDictionary.ContainsKey(subSku))
                    {
                        int quantity = inventoryDictionary[subSku] / subSkuQuantity;
                        if (quantity < warehouseQuantity)
                        {
                            warehouseQuantity = quantity;
                        }
                    }
                }
            }
            else
            {
                if (inventoryDictionary.ContainsKey(sku))
                {
                    warehouseQuantity = inventoryDictionary[sku];
                }
            }

            if (oldQuantity > hideQuantity && warehouseQuantity <= hideQuantity)
            {
                update = true;
                newQuantity = 0;
            }
            else if (oldQuantity <= hideQuantity && warehouseQuantity > hideQuantity)
            {
                update = true;
                newQuantity = warehouseQuantity;
            }

            if( newQuantity > 20 )
            {
                newQuantity = 20;
            }
            else if (newQuantity > 10)
            {
                newQuantity = 10;
            }

            return update;
        }


        public bool GetNewQuantity(string sku, int hideQuantity, int oldQuantity, int warehouseQuantity, out int newQuantity)
        {
            bool update = false;
            newQuantity = 0;

            if (oldQuantity > hideQuantity && warehouseQuantity <= hideQuantity)
            {
                update = true;
                newQuantity = 0;
            }
            else if (oldQuantity <= hideQuantity && warehouseQuantity > hideQuantity)
            {
                update = true;
                newQuantity = warehouseQuantity;
            }

            if (newQuantity > 20)
            {
                newQuantity = 20;
            }
            else if (newQuantity > 10)
            {
                newQuantity = 10;
            }

            return update;
        }


        public bool GetWarehouseQuantity(ERPContext context, string sku, out int quantity)
        {
            bool found = false;
            quantity = 0;
            var q = from ebayOnHandle in context.EbayOnhandle
                    where ebayOnHandle.GoodsSn == sku
                    where m_warehouseIds.Contains(ebayOnHandle.StoreId)
                    select new { sku = ebayOnHandle.GoodsSn, quantity = ebayOnHandle.GoodsCount.GetValueOrDefault() };
            foreach (var row in q)
            {
                found = true;
                quantity += row.quantity;
            }

            if (found)
            {
                var orderQuery = from ebayOrder in context.EbayOrder
                                 from ebayOrderDetail in context.EbayOrderdetail
                                 where ebayOrder.EbayOrdersn == ebayOrderDetail.EbayOrdersn
                                 where ebayOrder.EbayCouny == "US"
                                 where ebayOrder.EbayStatus == 1 || ebayOrder.EbayStatus == 848 || ebayOrder.EbayStatus == 924 || ebayOrder.EbayStatus == 850
                                 where ebayOrderDetail.Sku == sku
                                 select new { sku = ebayOrderDetail.Sku, ebayAmount = ebayOrderDetail.EbayAmount };
                foreach (var row in orderQuery)
                {
                    int orderQuantity = 0;
                    int.TryParse(row.ebayAmount, out orderQuantity);
                    quantity -= orderQuantity;
                }
            }

            return found;
        }

        public List<ShipmentBox> GetShipmentBoxes(string warehouseId, string sku)
        {
            List<ShipmentBox> shipmentBoxes = new List<ShipmentBox>();
            using (ERPContext context = new ERPContext(m_connectionString))
            {
                var q = from ebayShipmentBox in context.EbayShipmentbox
                        where ebayShipmentBox.WarehouseId == warehouseId
                        where ebayShipmentBox.Sku == sku
                        orderby ebayShipmentBox.ShipmentId, ebayShipmentBox.BoxId
                        select ebayShipmentBox;
                foreach(var row in q)
                {
                    ShipmentBox shipmentBox = new ShipmentBox();
                    shipmentBox.WarehouseId = row.WarehouseId;
                    shipmentBox.ShipmentId = row.ShipmentId;
                    shipmentBox.BoxId = row.BoxId;
                    shipmentBox.Quantity = row.Quantity;
                    shipmentBox.Type = row.Type;
                    shipmentBoxes.Add(shipmentBox);
                }
            }

            return shipmentBoxes;
        }

        public List<Shelve> GetShelves(string warehouseId, string sku)
        {
            List<Shelve> shelves = new List<Shelve>();

            using (ERPContext context = new ERPContext(m_connectionString))
            {
                var q = from ebayShelve in context.EbayShelve
                        where ebayShelve.Sku.StartsWith(sku)
                        where ebayShelve.WarehouseId == warehouseId
                        where ebayShelve.Active == "Y"
                        orderby ebayShelve.Sku, ebayShelve.ShelveId, ebayShelve.ShipmentId, ebayShelve.BoxId
                        select ebayShelve;
                foreach(var row in q)
                {
                    Shelve shelve = new Shelve();
                    shelve.SKU = row.Sku;
                    shelve.ShelveId = row.ShelveId;
                    shelve.ShipmentId = row.ShipmentId;
                    shelve.BoxId = row.BoxId;
                    shelves.Add(shelve);
                }
            }

            return shelves;
        }
    }
}
