using erpcore.models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpWebAPI.Types
{
    public class SearchOrderInputType : InputObjectGraphType<SearchOrderInput>
    {
        public SearchOrderInputType(SearchOrderInput searchOrderInput)
        {
            Name = "SearchOrderInput";
            Description = "SearchOrderInput";

            Field(o => o.Company);
            Field(o => o.SearchType);
            Field(o => o.SearchText);
        }
    }
}
