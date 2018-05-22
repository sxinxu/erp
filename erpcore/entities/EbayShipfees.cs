using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayShipfees
    {
        public int Id { get; set; }
        public string ShipCountry { get; set; }
        public string ShipType { get; set; }
        public string ShipGg { get; set; }
        public string ShipWeightsx { get; set; }
        public string ShipWeightxx { get; set; }
        public string ShipFee { get; set; }
    }
}
