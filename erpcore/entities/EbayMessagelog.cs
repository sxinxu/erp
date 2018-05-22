using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayMessagelog
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string Ordernumber { get; set; }
        public string Messagetemplate { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
    }
}
