using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpWebAPI.Models
{
    public class ERPSchema : Schema
    {
        public ERPSchema( IDependencyResolver resolver):base(resolver)
        {
            Query = resolver.Resolve<ERPQuery>();
            Mutation = resolver.Resolve<ERPMutation>();
        }
    }
}
