using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayRma
    {
        public int Id { get; set; }
        public string RmaOsn { get; set; }
        public int EbayId { get; set; }
        public int EbayPid { get; set; }
        public string Addtime { get; set; }
        public string Sku { get; set; }
        public string SerialNumber { get; set; }
        public string OpenDate { get; set; }
        public string Rtatype { get; set; }
        public string AreaOwner { get; set; }
        public string DueDate { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Ordernumber { get; set; }
        public string Rastatus { get; set; }
        public string Countrys { get; set; }
        public string Userid { get; set; }
        public string EbayAccount { get; set; }
        public string EbayRefundamount { get; set; }
        public int? Nexthandletime { get; set; }
        public string EbayStatus { get; set; }
        public string EbayCurrency { get; set; }
        public string EbayUser { get; set; }
        public string Nexthandleuser { get; set; }
    }
}
