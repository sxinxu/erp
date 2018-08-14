using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore.models
{
    public class ShipmentBox
    {
        public string WarehouseId { get; set; }

        public string ShipmentId { get; set; }

        public string BoxId { get; set; }

        public int Quantity { get; set; }

        public string Type { get; set; }
    }
}
