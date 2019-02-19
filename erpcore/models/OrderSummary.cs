using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore.models
{
    public class OrderSummary
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int Count { get; set; }
    }
}
