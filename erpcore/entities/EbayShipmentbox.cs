using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayShipmentbox
    {
        public int Id { get; set; }
        public string WarehouseId { get; set; }
        public string ShipmentId { get; set; }
        public string BoxId { get; set; }
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}
