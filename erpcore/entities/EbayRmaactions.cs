using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayRmaactions
    {
        public int Id { get; set; }
        public int? State { get; set; }
        public string Psas { get; set; }
        public string EbayId { get; set; }
        public string Stype { get; set; }
        public string EbayPid { get; set; }
        public string Sku { get; set; }
        public string Content { get; set; }
        public string Wuser { get; set; }
        public string Hxculiren { get; set; }
        public string Noticeuser { get; set; }
        public int? Odate { get; set; }
        public int? Tdate { get; set; }
        public int? Edate { get; set; }
        public decimal? Refund { get; set; }
        public string Currency { get; set; }
        public string Isread { get; set; }
    }
}
