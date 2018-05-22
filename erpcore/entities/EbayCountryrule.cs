using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayCountryrule
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Value { get; set; }
        public string Value2 { get; set; }
        public string EbayUser { get; set; }
    }
}
