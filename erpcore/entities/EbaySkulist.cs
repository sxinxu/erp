using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbaySkulist
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Namecn { get; set; }
        public string Nameen { get; set; }
        public string Account { get; set; }
        public string EbayUser { get; set; }
    }
}
