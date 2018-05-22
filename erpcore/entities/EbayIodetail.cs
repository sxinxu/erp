using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayIodetail
    {
        public int Id { get; set; }
        public int Ioid { get; set; }
        public int Qty { get; set; }
        public int Addtime { get; set; }
        public string EbayUser { get; set; }
    }
}
