using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore
{
    interface IInventoryService
    {
        void UpdateListingQuantities(string sku, int quantity);
    }
}
