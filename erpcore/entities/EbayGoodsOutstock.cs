using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayGoodsOutstock
    {
        public int Id { get; set; }
        public int EbayId { get; set; }
        public int EbayOrderinfoId { get; set; }
        public string Sku { get; set; }
        public string GoodsName { get; set; }
        public int GoodsCount { get; set; }
        public string GoodsNote { get; set; }
        public float? LastPurchaseprice { get; set; }
        public string Kfuser { get; set; }
        public string Cguser { get; set; }
        public int EbayWarehouse { get; set; }
        public int? GoodsId { get; set; }
        public string EbayUser { get; set; }
    }
}
