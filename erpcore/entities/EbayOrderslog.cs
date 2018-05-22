using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayOrderslog
    {
        public int Id { get; set; }
        public string Operationuser { get; set; }
        public int Operationtime { get; set; }
        public string Notes { get; set; }
        public int EbayId { get; set; }
        public int Types { get; set; }
    }
}
