using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayGoodshistory
    {
        public int Id { get; set; }
        public string Addtime { get; set; }
        public string Goodsid { get; set; }
        public string Goodsn { get; set; }
        public string Goodsname { get; set; }
        public string Stocktype { get; set; }
        public string Goodsprice { get; set; }
        public string Goodsnumber { get; set; }
        public string Sourceorder { get; set; }
        public string EbayUser { get; set; }
        public string EbayAccount { get; set; }
        public string GoodsCategory { get; set; }
        public string StoreId { get; set; }
        public string EbayCurrency { get; set; }
    }
}
