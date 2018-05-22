using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayParcel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Recordnumber { get; set; }
        public string Tracknumber { get; set; }
        public string Weight { get; set; }
        public string Details { get; set; }
        public string Country { get; set; }
        public string Orderstaus { get; set; }
        public string Note { get; set; }
        public int Addtime { get; set; }
    }
}
