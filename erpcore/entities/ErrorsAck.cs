using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class ErrorsAck
    {
        public int Id { get; set; }
        public string EbayAccount { get; set; }
        public string Starttime { get; set; }
        public string Endtime { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
        public int? Currentpage { get; set; }
    }
}
