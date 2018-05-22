using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayGoodspic
    {
        public uint Id { get; set; }
        public int GoodsId { get; set; }
        public string EbayUser { get; set; }
        public string Picurl { get; set; }
    }
}
