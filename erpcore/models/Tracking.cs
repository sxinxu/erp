using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore.models
{
    public enum Carrier
    {
        Fedex,
        UPS,
        USPS,
        DHL_ECOMMERCE
    }

    public class Tracking
    {
        public int OrderId { get; set; }

        public string TrackingNumber { get; set; }

        public string Carrier { get; set; }

        public double ShippingFee { get; set; }
    }
}
