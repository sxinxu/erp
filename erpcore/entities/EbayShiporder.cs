using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayShiporder
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string TrackingNumber { get; set; }
        public string Shipped { get; set; }
        public string OrderIds { get; set; }
        public string ShipDate { get; set; }
        public string Printed { get; set; }
        public string ScannedTime { get; set; }
        public int? StoreId { get; set; }
        public int Id { get; set; }
    }
}
