using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayPackingmaterial
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Rules { get; set; }
        public decimal Tjweight { get; set; }
        public string Notes { get; set; }
        public string Weight { get; set; }
        public float? Price { get; set; }
        public string EbayUser { get; set; }
    }
}
