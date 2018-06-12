using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore.models
{
    public class Profit
    {
        public string filterType { get; set; }

        public List<OrderProfit> orders {get;set;}

        public OrderProfit total { get; set; }
    }

    public class OrderProfit
    {
        public int ebay_id { get; set; }

        public string sku { get; set; }

        public string title { get; set; }

        public int quantity { get; set; }

        public double cost { get; set; }

        public double sales { get; set; }

        public double ebayFee { get; set; }

        public double paypalFee { get; set; }

        public double shippingFee { get; set; }

        public double internationalShippingFee { get; set; }

        public string date { get; set; }

        public double profit { get; set; }

        public int pieces { get; set; }

        public double discount { get; set; }
    }
}
