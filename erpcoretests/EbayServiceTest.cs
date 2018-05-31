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
            string[] eventTypes = { "ItemListed", "ItemClosed" };
            service.SetNotificationPreferences("notesonboard", true, eventTypes);
        }

        [Fact]
        public void TestGetOrder()
        {
            EbayService service = new EbayService();
            service.GetOrder("notesonboard", "282668265143-1839681112018");
        }

        [Fact]
        public void TestGetItemWithVariation()
        {
            EbayService service = new EbayService();
            service.GetItem("mei_ebuy", "292344652997");
        }

        [Fact]
        public void TestReviseVariationQuantity()
        {
            EbayService service = new EbayService();
            service.ReviseVariationQuantity("mei_ebuy", "292344652997", "04ODA0003ABK", 0);
        }

        [Fact]
        public void TestGetUserPreferences()
        {
            EbayService service = new EbayService();
            List<string> preferenceNames = new List<string>();
            preferenceNames.Add("ShowOutOfStockControlPreference");
            Dictionary<string, object> preferences = service.GetUserPreferences("mei_ebuy", preferenceNames);
        }
    }
}
