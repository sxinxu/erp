using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayListlog
    {
        public int Id { get; set; }
        public string Itemid { get; set; }
        public string Account { get; set; }
        public string Logs { get; set; }
        public string Addtime { get; set; }
        public string Currentuser { get; set; }
        public string EbayUser { get; set; }
    }
}
