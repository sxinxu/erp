using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbaySkucountrynote
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Country { get; set; }
        public string Note { get; set; }
        public string EbayUser { get; set; }
    }
}
