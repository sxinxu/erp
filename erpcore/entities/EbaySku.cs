using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbaySku
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Note { get; set; }
    }
}
