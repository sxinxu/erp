using erpcore.models;
using System.Collections.Generic;

namespace erpcore.repository
{
    public interface IOrderRepository
    {
        Order GetOrdersById( int orderId );

        List<Order> GetOrdersByTrackingNumber(string trackingNumber);
        List<Order> GetOrdersByUserId(string userId);
        List<Order> GetOrdersByUserName(string userName);
        List<Order> GetOrdersBySku(string sku);
        List<OrderSummary> GetOrderSummary();
    }
}
