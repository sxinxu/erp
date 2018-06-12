using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore.models
{
    public class Inventory
    {
        public string SKU { get; set; }

        public int Quantity { get; set; }

        public string Warehouse { get; set; }

        public int WarehouseId { get; set; }
    }
}
