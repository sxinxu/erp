using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayLog
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Time { get; set; }
    }
}
