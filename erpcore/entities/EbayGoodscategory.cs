using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayGoodscategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Pid { get; set; }
        public string EbayUser { get; set; }
    }
}
