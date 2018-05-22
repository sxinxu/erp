using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayStoragebox
    {
        public int Id { get; set; }
        public string WarehouseId { get; set; }
        public string ShipmentId { get; set; }
        public string BoxId { get; set; }
        public string StorageLocationId { get; set; }
        public string Scannedtime { get; set; }
        public string Active { get; set; }
        public string Type { get; set; }
        public string Modifieddate { get; set; }
    }
}
