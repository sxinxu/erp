using erpcore.entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace erpcore
{
    public interface IEbayService
    {
        List<string> GetAccountNames();

        void ProcessPlatformNotification(string notificationEventName, XElement childElement);

        void SyncOrders(ERPContext context, string accountName, DateTime createdTimeFrom, DateTime createdTimeTo, List<EbayOrderdetail> orderDetails);

        void RefreshListings(ERPContext context);

        void RefreshListings(ERPContext context, string ebayAccount);

        void ReviseListingQuantity(string ebayAccount, string itemId, string sku, int quantity);

        void ReviseVariationQuantity(string ebayAccount, string itemId, string sku, int quantity);

        void ProcessAuctionCheckoutComplete(XElement element);

        void ProcessMessage(XElement element);

        void ProcessItemListed(XElement element);

        void ProcessItemClosed(XElement element);

        bool IsPlatformNotificationEnabled(string ebayAccount);

        List<string> GetEnabledNotificationTypes(string ebayAccount);

        void SetNotificationPreferences(string url, bool enable, string[] eventTypes);

        void SetNotificationPreferences(string ebayAccount, string url, bool enable, string[] eventTypes);

        void GetNotificationsUsage(string ebayAccount);

        Dictionary<string, Object> GetUserPreferences(string ebayAccount, List<string> preferenceNames);

        void SetUserPreferences(string ebayAccount, Dictionary<string, Object> preferences);
        
        void UpdateListingQuantities(ERPContext context, string accountName, Dictionary<string, int> inventoryDictionary, Dictionary<string, Dictionary<string, int>> productCombineDictionary);

        void UpdateListingQuantities(ERPContext context, string sku, int warehouseQuantity);

        void CompleteSale(int orderId);
    }
}
