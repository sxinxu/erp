using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class AmazonList
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ASIN { get; set; }
    }
}
