using System;
using System.Collections.Generic;
using System.Text;
using erpcore;
using Xunit;

namespace erpcoretests
{
    public class EbayServiceTest
    {
        private EbayService service = new EbayService("server=localhost;port=3306;user=root;password=EFDnpz8PeJ758VeN;database=v3-all");

        [Fact]
        public void TestGetMyEbaySelling()
        {
            service.GetSellerList("notesonboard");
        }

        [Fact]
        public void TestEnabledNotificationTypes()
        {
            service.GetEnabledNotificationTypes("notesonboard");
        }

        [Fact]
        public void TestSetNotificationPreferences()
        {
            string[] eventTypes = { "ItemListed", "ItemClosed" };
            service.SetNotificationPreferences("notesonboard", true, eventTypes);
        }

        [Fact]
        public void TestGetOrder()
        {
            service.GetOrder("notesonboard", "282668265143-1839681112018");
        }

        [Fact]
        public void TestGetItemWithVariation()
        {
            service.GetItem("mei_ebuy", "292344652997");
        }

        [Fact]
        public void TestReviseVariationQuantity()
        {
            service.ReviseVariationQuantity("mei_ebuy", "292344652997", "04ODA0003ABK", 0);
        }

        [Fact]
        public void TestGetUserPreferences()
        {
            List<string> preferenceNames = new List<string>();
            preferenceNames.Add("ShowOutOfStockControlPreference");
            Dictionary<string, object> preferences = service.GetUserPreferences("mei_ebuy", preferenceNames);
        }
    }
}
