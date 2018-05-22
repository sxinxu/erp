using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayFee
    {
        public int Id { get; set; }
        public string Feetype { get; set; }
        public string Feetdescription { get; set; }
        public string Feedate { get; set; }
        public int? Feeddate1 { get; set; }
        public string Feeamount { get; set; }
        public string Title { get; set; }
        public string EbayProductsSn { get; set; }
        public string Itemid { get; set; }
        public string Account { get; set; }
        public string User { get; set; }
    }
}
