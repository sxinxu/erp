using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayShipping
    {
        public byte ShippingId { get; set; }
        public string ShippingCode { get; set; }
        public string ShippingName { get; set; }
        public string ShippingDesc { get; set; }
        public string Insure { get; set; }
        public byte SupportCod { get; set; }
        public byte Enabled { get; set; }
        public string ShippingPrint { get; set; }
        public string PrintBg { get; set; }
        public string ConfigLable { get; set; }
        public sbyte? PrintModel { get; set; }
    }
}
