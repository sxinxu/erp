using erpcore.models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpWebAPI.Types
{
    public class OrderSummaryType : ObjectGraphType<OrderSummary>
    {
        public OrderSummaryType()
        {
            Name = "OrderSummary";
            Description = "OrderSummary";

            Field(o => o.CategoryId);
            Field(o => o.CategoryName);
            Field(o => o.Count);
        }
    }
}
