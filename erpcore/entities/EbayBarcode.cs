using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayBarcode
    {
        public int BId { get; set; }
        public string Code { get; set; }
        public sbyte? Exist { get; set; }
        public string EbayUser { get; set; }
    }
}
