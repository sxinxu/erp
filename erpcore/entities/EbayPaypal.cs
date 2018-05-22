using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayPaypal
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public string Signature { get; set; }
        public string Ebayaccount { get; set; }
        public decimal? Fees { get; set; }
        public string User { get; set; }
    }
}
