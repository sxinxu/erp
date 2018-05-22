using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayMessagecategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string EbayNote { get; set; }
        public string Rules { get; set; }
        public string EbayAccount { get; set; }
        public string EbayUser { get; set; }
    }
}
