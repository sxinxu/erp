using erpcore.entities;
using erpcore.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace erpcore
{
    public class InventoryService :IInventoryService
    {
        private IPlatformServiceFactory m_platformServiceFactory;
        private string m_company;
        private string m_connectionString;
        private int[] m_warehouseIds = { 101, 108 };

        public InventoryService(IPlatformServiceFactory platformServiceFactory, string company, string connectionString)
        {
            m_platformServiceFactory = platformServiceFactory;
            m_company = company;
            m_connectionString = connectionString;
        }

        public void UpdateListingQuantities(string sku, int quantity)
        {
            m_platformServiceFactory.GetEbayService(m_company).UpdateListingQuantities(sku, quantity);
        }

        public List<Inventory> GetInventories(string sku)
        {
            List<Inventory> inventories = new List<Inventory>();

            using (ERPContext context = new ERPContext(m_connectionString))
            {
                var q = from ebayOnHandle in context.EbayOnhandle
                        from ebayStore in context.EbayStore
                        where ebayOnHandle.GoodsSn.ToUpper().StartsWith(sku.ToUpper())
                        where ebayStore.Id == ebayOnHandle.StoreId
                        where m_warehouseIds.Contains(ebayOnHandle.Id)
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
    }
}
