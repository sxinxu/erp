using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Truename { get; set; }
        public string Country { get; set; }
        public string Provience { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public int? Paypal { get; set; }
        public int? Record { get; set; }
        public string Message { get; set; }
        public string Regdate { get; set; }
        public string Logtime { get; set; }
        public string Ip { get; set; }
        public int? Active { get; set; }
        public string User { get; set; }
        public string Power { get; set; }
        public string Ebayaccounts { get; set; }
        public string Orderscountry { get; set; }
    }
}
