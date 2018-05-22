using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayTopmenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ordernumber { get; set; }
        public string EbayUser { get; set; }
    }
}
