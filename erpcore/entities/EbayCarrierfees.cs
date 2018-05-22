using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayCarrierfees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pricestart { get; set; }
        public string Priceend { get; set; }
        public string Carrierid { get; set; }
        public string Status { get; set; }
        public string EbayUser { get; set; }
    }
}
