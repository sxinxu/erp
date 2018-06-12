using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore
{
    public interface IPlatformServiceFactory
    {
        IEbayService GetEbayService(string company);

        IAmazonService GetAmazonService(string company);

        IOrderService GetOrderService(string company);

        IInventoryService GetInventoryService(string company);

        string ContentRootPath { get; set; }
    }
}
