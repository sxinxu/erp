using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayCarrierweight
    {
        public int Id { get; set; }
        public float? Min { get; set; }
        public float? Max { get; set; }
        public float? Weight { get; set; }
        public string ShippingId { get; set; }
        public float? Totalweight { get; set; }
    }
}
