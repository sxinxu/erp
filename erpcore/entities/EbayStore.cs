using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayStore
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StoreSn { get; set; }
        public string StoreLocation { get; set; }
        public string StoreNote { get; set; }
        public string EbayUser { get; set; }
    }
}
