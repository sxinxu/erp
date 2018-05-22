using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayConfig
    {
        public int Id { get; set; }
        public int? Storeid { get; set; }
        public int? Notesorderstatus { get; set; }
        public int? Auditcompleteorderstatus { get; set; }
        public float? Days30 { get; set; }
        public float? Days15 { get; set; }
        public float? Days7 { get; set; }
        public int? Overweightstatus { get; set; }
        public int? Overtock { get; set; }
        public int? Hackorer { get; set; }
        public string Totalprofitstatus { get; set; }
        public float? Systemprofit { get; set; }
        public string Feedbackstring { get; set; }
        public string EbayUser { get; set; }
        public int? Onstock { get; set; }
        public int? Scaningorderstatus { get; set; }
        public string Ywuserid { get; set; }
        public string Paypalstatus { get; set; }
        public string Ywpassword { get; set; }
        public int? Allowauditorderstatus { get; set; }
        public int? Distrubitestock { get; set; }
        public string Token4px { get; set; }
    }
}
