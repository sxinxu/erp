using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace erpcore
{
    public interface IEbayService
    {
        void GetSellerList(string ebayAccount);

        void GetItem(string ebayAccount, string itemId);

        void AddItem(XElement item);

        void ReviseListingQuantity(string ebayAccount, string itemId, int quantity);

        void ReviseVariationQuantity(string ebayAccount, string itemId, string sku, int quantity);

        void GetOrder(string ebayAccount, string orderId);

        void ProcessGetOrdersResponse(XElement output);

        void ProcessAuctionCheckoutComplete(XElement element);

        void ProcessMessage(XElement element);

        void ProcessItemListed(XElement element);

        void ProcessItemClosed(XElement element);

        bool IsPlatformNotificationEnabled(string ebayAccount);

        List<string> GetEnabledNotificationTypes(string ebayAccount);

        void SetNotificationPreferences(string ebayAccount, bool enable, string[] eventTypes);

        Dictionary<string, Object> GetUserPreferences(string ebayAccount, List<string> preferenceNames);

        void SetUserPreferences(string ebayAccount, Dictionary<string, Object> preferences);

        void UpdateListingQuantities(string sku, int quantity);
    }
}
