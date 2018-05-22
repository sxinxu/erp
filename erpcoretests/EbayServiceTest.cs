using System;
using System.Collections.Generic;
using System.Text;
using erpcore;
using Xunit;

namespace erpcoretests
{
    public class EbayServiceTest
    {
        [Fact]
        public void TestGetMyEbaySelling()
        {
            EbayService service = new EbayService();
            service.GetSellerList("notesonboard");
        }

        [Fact]
        public void TestEnabledNotificationTypes()
        {
            EbayService service = new EbayService();
            service.GetEnabledNotificationTypes("notesonboard");
        }

        [Fact]
        public void TestSetNotificationPreferences()
        {
            EbayService service = new EbayService();
            string[] eventTypes = { "AskSellerQuestion", "MyMessageseBayMessage", "MyMessagesM2MMessage" };
            service.SetNotificationPreferences("notesonboard", true, eventTypes);
        }
    }
}
