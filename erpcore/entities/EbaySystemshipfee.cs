using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbaySystemshipfee
    {
        public int Id { get; set; }
        public int? Type { get; set; }
        public float? Aweightstart { get; set; }
        public float? Aweightend { get; set; }
        public float? Ashipfee { get; set; }
        public float? Ahandlefee { get; set; }
        public float? Ahandelfee2 { get; set; }
        public float? Adiscount { get; set; }
        public string Acountrys { get; set; }
        public float? Bfirstweight { get; set; }
        public float? Bnextweight { get; set; }
        public float? Bfirstweightamount { get; set; }
        public float? Bnextweightamount { get; set; }
        public float? Bhandlefee { get; set; }
        public float? Bdiscount { get; set; }
        public string Bcountrys { get; set; }
        public string Name { get; set; }
        public int? Shippingid { get; set; }
    }
}
