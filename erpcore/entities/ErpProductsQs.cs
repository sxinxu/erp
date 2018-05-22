using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class ErpProductsQs
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Addtime { get; set; }
        public int Adder { get; set; }
        public string Sku { get; set; }
        public int Cok { get; set; }
    }
}
