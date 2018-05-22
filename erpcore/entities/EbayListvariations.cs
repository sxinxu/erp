using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayListvariations
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Quantity { get; set; }
        public int? QuantitySold { get; set; }
        public int? QuantityAvailable { get; set; }
        public string StartPrice { get; set; }
        public string Itemid { get; set; }
        public string EbayAccount { get; set; }
        public string VariationSpecifics { get; set; }
        public string EbayUser { get; set; }
    }
}
