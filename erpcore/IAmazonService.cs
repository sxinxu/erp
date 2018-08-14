using erpcore.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore
{
    public interface IAmazonService
    {
        List<string> GetAccountNames();

        void SyncOrders(ERPContext context, string accountName, DateTime createdAfter, DateTime createdBefore, List<EbayOrderdetail> orderDetails);

        void RefreshListings(ERPContext context);

        void RefreshListings(ERPContext context, string ebayAccount);

        void UpdateInventory(string accountName, Dictionary<string, int> quantities);

        void UpdateListingQuantities(ERPContext context, string accountName, Dictionary<string, int> inventoryDictionary, Dictionary<string, Dictionary<string, int>> productCombineDictionary);

        void UpdateListingQuantities(ERPContext context, string sku, int warehouseQuantity );
    }
}
