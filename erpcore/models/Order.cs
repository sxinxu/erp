using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore.models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
            OrderLogs = new List<OrderLog>();
        }

        public int OrderId { get; set; }

        public string OrderSn { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostCode { get; set; }

        public string Country { get; set; }

        public string WarehouseId { get; set; }

        public string Status { get; set; }

        public int StatusId { get; set; }

        public string AccountName { get; set; }

        public string Carrier { get; set; }

        public string TrackingNumber { get; set; }

        public double ShippingFee { get; set; }

        public string RecordNumber { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime? PaidTime { get; set; }

        public DateTime? ShippedTime { get; set; }

        public DateTime? MarketTime { get; set; }

        public List<OrderDetail> OrderDetails {get;set;}

        public List<OrderLog> OrderLogs { get; set; }
    }
}
