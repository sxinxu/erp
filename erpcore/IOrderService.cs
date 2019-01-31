using erpcore.entities;
using erpcore.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore
{
    public interface IOrderService
    {
        List<Order> SearchOrders(string searchType, string searchText);

        List<Order> GetOrdersToShip();

        Profit GetProfits(string dateFilter, string skuFilter, string account);

        void UpdateListings(ERPContext context, List<EbayOrderdetail> orderDetails);

        void UpdateAccountListingQuantities(string accountName, bool refresh);

        void UpdateSKUListingQuantities(string sku);

        void UpdateSKUListingQuantities(ERPContext context, string sku);

        void SyncOrders(List<string> accountNames, DateTime createdTimeFrom, DateTime createdTimeTo);

        void UploadTrackings(List<Tracking> trackings);
    }
}
