using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayIostorepay
    {
        public int Id { get; set; }
        public string IoOrdersn { get; set; }
        public int PayTime { get; set; }
        public float PayMoney { get; set; }
        public string Payer { get; set; }
        public string PayMethod { get; set; }
        public string Remark { get; set; }
    }
}
