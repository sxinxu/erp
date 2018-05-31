using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore
{
    public class InventoryService
    {
        private IEbayService m_ebayService;
        private IAmazonService m_amazonService;

        public InventoryService(IEbayService ebayService, IAmazonService amazonService)
        {
            m_ebayService = ebayService;
            m_amazonService = amazonService;
        }

        public void UpdateListingQuantities(string sku, int quantity)
        {
            m_ebayService.UpdateListingQuantities(sku, quantity);
        }
    }
}
