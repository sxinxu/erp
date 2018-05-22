using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayOrderdetail
    {
        public int EbayId { get; set; }
        public string Recordnumber { get; set; }
        public string EbayOrdersn { get; set; }
        public string EbayItemid { get; set; }
        public string EbayItemtitle { get; set; }
        public string EbayItemurl { get; set; }
        public string Sku { get; set; }
        public string EbayItemprice { get; set; }
        public string EbayAmount { get; set; }
        public int? EbayCreatedtime { get; set; }
        public string EbayShiptype { get; set; }
        public string EbayUser { get; set; }
        public string Shipingfee { get; set; }
        public string EbayAccount { get; set; }
        public string EbaySite { get; set; }
        public string Addtime { get; set; }
        public string Storeid { get; set; }
        public float? FinalValueFee { get; set; }
        public string FeeOrCreditAmount { get; set; }
        public string Attribute { get; set; }
        public string Sourceorder { get; set; }
        public string ListingType { get; set; }
        public int? Istrue { get; set; }
        public string EbayTid { get; set; }
        public string Notes { get; set; }
        public string GoodsLocation { get; set; }
        public string OrderLineItemId { get; set; }
        public string PayPalEmailAddress { get; set; }
        public int? CombineOrderid { get; set; }
    }
}
