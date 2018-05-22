using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayLishicalcfee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public int Shippingid { get; set; }
        public int Orderid { get; set; }
        public float? Totalweight { get; set; }
    }
}
