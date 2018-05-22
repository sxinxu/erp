using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayRmatype
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string EbayUser { get; set; }
    }
}
