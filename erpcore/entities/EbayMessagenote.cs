using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayMessagenote
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public string Messageid { get; set; }
        public string Addtime { get; set; }
        public string EbayUser { get; set; }
        public string EbayAccount { get; set; }
        public string EbayUserid { get; set; }
    }
}
