using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayRand
    {
        public int Id { get; set; }
        public string Ordersn { get; set; }
        public string Time { get; set; }
        public string Value { get; set; }
        public string EbayAccount { get; set; }
    }
}
