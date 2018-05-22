using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayOrdernote
    {
        public int Id { get; set; }
        public string Addtime { get; set; }
        public string Content { get; set; }
        public string User { get; set; }
        public string Ordersn { get; set; }
    }
}
