using erpcore;
using erpcore.models;
using erpWebAPI.Types;
using GraphQL.Conventions;
using GraphQL.Conventions.Relay;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpWebAPI.Models
{
    [ImplementViewer(OperationType.Query)]
    public class ERPQuery : ObjectGraphType
    {
        public ERPQuery(IPlatformServiceFactory platformServiceFactory)
        {
            Field<ListGraphType<OrderType>>("searchOrders",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<SearchOrderInputType>> { Name = "searchOrderInput", Description = "Search Order Input" }),
                resolve: context =>
                {
                    SearchOrderInput searchOrderInput = context.GetArgument<SearchOrderInput>("searchOrderInput");
                    return platformServiceFactory.GetOrderService(searchOrderInput.Company).SearchOrders(searchOrderInput.SearchType, searchOrderInput.SearchText);
                }
                );
        }
    }
}
