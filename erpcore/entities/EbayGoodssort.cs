using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayGoodssort
    {
        public int Id { get; set; }
        public string GoodsSn { get; set; }
        public int Qty { get; set; }
        public float Totalprice { get; set; }
        public float? Totalprofit { get; set; }
        public string EbayUser { get; set; }
        public string GoodsName { get; set; }
        public string GoodsCost { get; set; }
    }
}
