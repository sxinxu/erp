using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayPaypalview
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public string Sku { get; set; }
        public string EbayUser { get; set; }
        public string Cpuser { get; set; }
        public string Addtime { get; set; }
    }
}
