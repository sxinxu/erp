using erpcore.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore
{
    public interface IOrderService
    {
        List<Order> GetOrdersToShip();

        Profit GetProfits(string filter, string account);
    }
}
