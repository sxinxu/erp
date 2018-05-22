using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayScanning
    {
        public int ScanningId { get; set; }
        public string OrderNumber { get; set; }
        public string NowOrder { get; set; }
        public int? OrderNum { get; set; }
        public int? CheckNum { get; set; }
        public string State { get; set; }
        public string EbayUser { get; set; }
        public string GoodsName { get; set; }
    }
}
