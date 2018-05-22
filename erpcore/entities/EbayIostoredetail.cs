using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayIostoredetail
    {
        public int Id { get; set; }
        public string IoOrdersn { get; set; }
        public string GoodsId { get; set; }
        public string GoodsSn { get; set; }
        public string GoodsName { get; set; }
        public string GoodsPrice { get; set; }
        public float? GoodsCost { get; set; }
        public int? GoodsCount { get; set; }
        public int? Qty01 { get; set; }
        public string Qty02 { get; set; }
        public string Qty03 { get; set; }
        public string GoodsUnit { get; set; }
        public string Partnersn { get; set; }
        public string Partnerprice { get; set; }
        public string Status { get; set; }
        public int? Pid { get; set; }
        public int Stockqty { get; set; }
        public int? GoodsCount0 { get; set; }
        public int? GoodsCount1 { get; set; }
        public int? GoodsCount2 { get; set; }
        public string Transactioncurrncy { get; set; }
        public string EbayShipfee { get; set; }
        public string Notes { get; set; }
    }
}
