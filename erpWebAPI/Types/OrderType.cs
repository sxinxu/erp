using erpcore.models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpWebAPI.Types
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType()
        {
            Name = "Order";
            Description = "Order";

            Field(o => o.OrderId);
            Field(o => o.OrderSn);
            Field(o => o.UserId);
            Field(o => o.UserName);
            Field(o => o.PhoneNo);
            Field(o => o.Email);
            Field(o => o.Address1);
            Field(o => o.Address2);
            Field(o => o.City);
            Field(o => o.State);
            Field(o => o.PostCode);
            Field(o => o.Country);
            Field(o => o.WarehouseId);
            Field(o => o.Status);
            Field(o => o.StatusId);
            Field(o => o.AccountName);
            Field(o => o.Carrier);
            Field(o => o.TrackingNumber);
            Field(o => o.ShippingFee);
            Field(o => o.RecordNumber);
            Field(o => o.CreatedTime);
            Field(o => o.MarketTime, nullable: true);
            Field<ListGraphType<OrderDetailType>>("orderDetails", "OrderDetails");
        }
    }
}
