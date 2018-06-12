using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore
{
    public interface IAmazonService
    {
        bool isAmazonAccount(string accountName);

        void ListOrders(string accountName, DateTime createdAfter, DateTime createdBefore);
    }
}
