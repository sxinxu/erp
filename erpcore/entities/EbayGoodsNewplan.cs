using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayGoodsNewplan
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string GoodsName { get; set; }
        public string Unit { get; set; }
        public string Partner { get; set; }
        public string EbayId { get; set; }
        public string EbayOrderinfoId { get; set; }
        public int? EbayWarehouse { get; set; }
        public string Kfuser { get; set; }
        public string Cguser { get; set; }
        public int? GoodsCount { get; set; }
        public float? Purchaseprice { get; set; }
        public string Notes { get; set; }
        public string EbayUser { get; set; }
        public int Type { get; set; }
    }
}
