using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayMessagetemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string EbayUser { get; set; }
        public string Subject { get; set; }
        public string Category { get; set; }
        public int? Ordersn { get; set; }
    }
}
