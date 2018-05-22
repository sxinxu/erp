using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class PartnerSkuprice
    {
        public int PartnerId { get; set; }
        public string Sku { get; set; }
        public int? PartnerSku { get; set; }
        public string GoodsName { get; set; }
        public float? GoodsCost { get; set; }
        public string GoodsNote { get; set; }
        public string Addtime { get; set; }
        public string Adduser { get; set; }
        public string EbayUser { get; set; }
        public int Partnerid { get; set; }
    }
}
