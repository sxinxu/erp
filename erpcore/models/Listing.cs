using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore.models
{
    public class Listing
    {
        public string ItemId { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public string AccountName { get; set; }
        public string ListingType { get; set; }
    }
}
