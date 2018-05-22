using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayPaypaldetail
    {
        public int Id { get; set; }
        public decimal? Gross { get; set; }
        public decimal? Fee { get; set; }
        public decimal? Net { get; set; }
        public string Tid { get; set; }
        public string Account { get; set; }
        public int? Time { get; set; }
        public string User { get; set; }
        public string Currency { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
    }
}
