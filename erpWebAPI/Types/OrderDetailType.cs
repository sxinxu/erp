using erpcore.models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpWebAPI.Types
{
    public class OrderDetailType : ObjectGraphType<OrderDetail>
    {
        public OrderDetailType()
        {
            Name = "OrderDetail";
            Description = "OrderDetail";

            Field(o => o.SKU);
            Field(o => o.Quantity);
            Field(o => o.ItemId);
            Field(o => o.ItemName);
            Field(o => o.Price);
            Field(o => o.ShippingFee);
            Field(o => o.Weight);
            Field(o => o.Length);
            Field(o => o.Width);
            Field(o => o.Height);
        }
    }
}
