using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayCarrier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Track { get; set; }
        public float? Kg { get; set; }
        public float Discount { get; set; }
        public float? Handlefee { get; set; }
        public string EbayUser { get; set; }
        public string EbayCountry { get; set; }
        public string PrintBg { get; set; }
        public string ConfigLable { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Username { get; set; }
        public string Tel { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public string Max { get; set; }
        public string Min { get; set; }
        public string Teshu { get; set; }
        public string Default04 { get; set; }
        public string Default03 { get; set; }
        public string Default02 { get; set; }
        public string Default01 { get; set; }
        public string CarrierSn { get; set; }
        public string Signature { get; set; }
        public string Note { get; set; }
        public string Firstweight { get; set; }
        public string EbayAccount { get; set; }
        public float? Weightmin { get; set; }
        public float? Weightmax { get; set; }
        public string WeighebayCountry { get; set; }
        public int? Priority { get; set; }
        public string Encounts { get; set; }
        public string Skus { get; set; }
        public int? Orderstatus { get; set; }
        public int? EbayWarehouse { get; set; }
        public float? Rate { get; set; }
        public string StampPic { get; set; }
        public string FromEbaycarrier { get; set; }
        public int? Tjsku { get; set; }
        public int? Tjcountry { get; set; }
        public int? Tjcarrier { get; set; }
        public string Safetype { get; set; }
        public string Backtype { get; set; }
    }
}
