using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayHackpeoles
    {
        public int Id { get; set; }
        public string Userid { get; set; }
        public string Mail { get; set; }
        public string EbayUsername { get; set; }
        public string EbayStreet { get; set; }
        public string EbayStreet1 { get; set; }
        public string EbayCity { get; set; }
        public string EbayState { get; set; }
        public string EbayCountryname { get; set; }
        public string EbayPostcode { get; set; }
        public string EbayPhone { get; set; }
        public int? Status { get; set; }
        public string PaypalAccount { get; set; }
        public string Notes { get; set; }
        public string Adduser { get; set; }
        public string Addtim { get; set; }
        public string EbayUser { get; set; }
    }
}
