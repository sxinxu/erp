using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayZen
    {
        public int Id { get; set; }
        public string ZenName { get; set; }
        public string ZenServer { get; set; }
        public string ZenUsername { get; set; }
        public string ZenPassword { get; set; }
        public string ZenDatabase { get; set; }
        public string User { get; set; }
    }
}
