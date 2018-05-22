using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class ErpProductsOp
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public double Price { get; set; }
        public string Link { get; set; }
        public string Remark { get; set; }
        public DateTime Addtime { get; set; }
        public int Adder { get; set; }
        public int Status { get; set; }
        public DateTime Passtime { get; set; }
        public string Reb { get; set; }
        public double Opprice { get; set; }
        public DateTime Optime { get; set; }
        public int Oper { get; set; }
        public string Opreb { get; set; }
        public double Dprice { get; set; }
        public double Aprice { get; set; }
        public double Price1 { get; set; }
        public double Price2 { get; set; }
        public double Profit { get; set; }
        public string Keywords { get; set; }
        public double Paypal { get; set; }
        public double Dl { get; set; }
        public double Category { get; set; }
    }
}
