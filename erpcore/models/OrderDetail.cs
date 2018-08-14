using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore.models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public string SKU { get; set; }

        public int Quantity { get; set; }

        public string ItemId { get; set; }

        public string ItemName { get; set; }

        public double Price { get; set; }

        public double ShippingFee { get; set; }

        public double Weight { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }
    }
}
