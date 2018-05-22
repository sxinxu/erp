using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayOrdertype
    {
        public int Id { get; set; }
        public string Typename { get; set; }
        public string EbayUser { get; set; }
    }
}
