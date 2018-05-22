using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayPartner
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Code { get; set; }
        public string Username { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public string City { get; set; }
        public string Url { get; set; }
        public string Bankaccountaddress { get; set; }
        public string Bankaccountname { get; set; }
        public string Bankaccountnumber { get; set; }
        public int? Status { get; set; }
        public string EbayUser { get; set; }
        public string Audituser { get; set; }
        public string Audittime { get; set; }
        public string Qq { get; set; }
    }
}
