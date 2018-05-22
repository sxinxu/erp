using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayOnhandle1
    {
        public int Id { get; set; }
        public int? GoodsId { get; set; }
        public string GoodsSn { get; set; }
        public string GoodsName { get; set; }
        public int? GoodsCount { get; set; }
        public string GoodsSku { get; set; }
        public int? GoodsSx { get; set; }
        public int? GoodsXx { get; set; }
        public int? GoodsDays { get; set; }
        public string GoodsDelivery { get; set; }
        public int? Purchasedays { get; set; }
        public int StoreId { get; set; }
        public string EbayUser { get; set; }
    }
}
