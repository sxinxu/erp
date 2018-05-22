using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class SystemLog
    {
        public int LogId { get; set; }
        public string LogName { get; set; }
        public int LogOperationtime { get; set; }
        public int LogOrderid { get; set; }
        public string LogNotes { get; set; }
        public string Currentime { get; set; }
        public string LogEbayAccount { get; set; }
        public string EbayUser { get; set; }
        public string EbayAccount { get; set; }
        public string Starttime { get; set; }
        public string Endtime { get; set; }
        public int? Type { get; set; }
        public int? Currentpage { get; set; }
    }
}
