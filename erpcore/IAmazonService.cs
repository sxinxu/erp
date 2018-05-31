using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore
{
    public interface IAmazonService
    {
        void ListOrders(string accountName, DateTime createdAfter, DateTime createdBefore);
    }
}
