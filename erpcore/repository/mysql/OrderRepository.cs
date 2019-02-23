using erpcore.entities;
using erpcore.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace erpcore.repository.mysql
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ERPContext m_context;

        public OrderRepository(ERPContext context)
        {
            m_context = context;
        }

        public Order GetOrdersById(int orderId)
        {
            List<Order> orders = GetOrders(a => a.ebayOrder.EbayId == orderId);
            if (orders.Count > 0)
            {
                return orders[0];
            }
            else
            {
                return null;
            }
        }

        public List<Order> GetOrdersByTrackingNumber(string trackingNumber)
        {
            return GetOrders(a => a.ebayOrder.EbayTracknumber == trackingNumber);
        }

        public List<Order> GetOrdersByUserId(string userId)
        {
            return GetOrders(a => a.ebayOrder.EbayUserid == userId);
        }

        public List<Order> GetOrdersByUserName(string userName)
        {
            return GetOrders(a => a.ebayOrder.EbayUsername == userName);
        }

        public List<Order> GetOrdersBySku(string sku)
        {
            return GetOrders(a => a.ebayOrderDetail.Sku == sku);
        }

        private class OrderResult
        {
            public EbayOrder ebayOrder;
            public EbayOrderdetail ebayOrderDetail;
            public EbayTopmenu ebayTopMenu;
            public EbayOrderslog log;
        }

        private List<Order> GetOrders(params Func<OrderResult, bool>[] filters)
        {
            List<Order> orders = new List<Order>();
            Dictionary<int, Order> orderDictionary = new Dictionary<int, Order>();

            var q = from ebayOrder in m_context.EbayOrder
                    join ebayOrdersLog in m_context.EbayOrderslog
                    on ebayOrder.EbayId equals ebayOrdersLog.EbayId
                    into logs
                    from log in logs.DefaultIfEmpty()
                    from ebayOrderDetail in m_context.EbayOrderdetail
                    from ebayTopMenu in m_context.EbayTopmenu
                    where ebayOrder.EbayOrdersn == ebayOrderDetail.EbayOrdersn
                    where ebayTopMenu.Id == ebayOrder.EbayStatus
                    orderby ebayOrder.EbayId, ebayOrderDetail.Sku, log.Operationtime descending
                    select new OrderResult
                    {
                        ebayOrder = ebayOrder,
                        ebayOrderDetail = ebayOrderDetail,
                        ebayTopMenu = ebayTopMenu,
                        log = log
                    };

            IEnumerable<OrderResult> q1 = q;
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    q1 = q1.Where(filter);
                }
            }

            var q2 = from a in q1
                     select new
                     {
                         OrderId = a.ebayOrder.EbayId,
                         OrderSn = a.ebayOrder.EbayOrdersn,
                         UserId = a.ebayOrder.EbayUserid,
                         UserName = a.ebayOrder.EbayUsername,
                         PhoneNo = a.ebayOrder.EbayPhone,
                         Email = a.ebayOrder.EbayUsermail,
                         Address1 = a.ebayOrder.EbayStreet,
                         Address2 = a.ebayOrder.EbayStreet1,
                         City = a.ebayOrder.EbayCity,
                         State = a.ebayOrder.EbayState,
                         PostCode = a.ebayOrder.EbayPostcode,
                         Country = a.ebayOrder.EbayCountryname,
                         WarehouseId = a.ebayOrder.EbayWarehouse,
                         AccountName = a.ebayOrder.EbayAccount,
                         Carrier = a.ebayOrder.EbayCarrier,
                         TrackingNumber = a.ebayOrder.EbayTracknumber,
                         Status = a.ebayTopMenu.Name,
                         StatusId = a.ebayOrder.EbayStatus.GetValueOrDefault(),
                         OrderShipFee = a.ebayOrder.Ordershipfee.GetValueOrDefault(),
                         CreatedTime = a.ebayOrder.EbayCreatedtime.GetValueOrDefault(),
                         PaidTime = a.ebayOrder.EbayPaidtime,
                         ShippedTime = a.ebayOrder.ShippedTime,
                         MarketTime = a.ebayOrder.EbayMarkettime,
                         RecordNumber = a.ebayOrder.Recordnumber,
                         OrderDetailId = a.ebayOrderDetail.EbayId,
                         SKU = a.ebayOrderDetail.Sku,
                         Quantity = a.ebayOrderDetail.EbayAmount,
                         ItemPrice = a.ebayOrderDetail.EbayItemprice,
                         ItemId = a.ebayOrderDetail.EbayItemid,
                         ItemName = a.ebayOrderDetail.EbayItemtitle,
                         ShippingFee = a.ebayOrderDetail.Shipingfee,
                         Log = a.log
                     };
            foreach (var row in q2)
            {
                Order order = null;
                if (orderDictionary.ContainsKey(row.OrderId))
                {
                    order = orderDictionary[row.OrderId];
                }
                else
                {
                    order = new Order();
                    order.OrderId = row.OrderId;
                    order.OrderSn = row.OrderSn;
                    order.UserId = row.UserId;
                    order.UserName = row.UserName;
                    order.PhoneNo = row.PhoneNo;
                    order.Email = row.Email;
                    order.Address1 = row.Address1;
                    order.Address2 = row.Address2;
                    order.City = row.City;
                    order.State = row.State;
                    order.PostCode = row.PostCode;
                    order.Country = row.Country;
                    order.WarehouseId = row.WarehouseId;
                    order.AccountName = row.AccountName;
                    order.Carrier = row.Carrier;
                    order.TrackingNumber = row.TrackingNumber;
                    order.Status = row.Status;
                    order.StatusId = row.StatusId;
                    order.ShippingFee = row.OrderShipFee;
                    order.CreatedTime = DateUtils.ConvertUnixTimeToDateTime(row.CreatedTime);
                    if (row.PaidTime != null)
                    {
                        int paidTime = 0;
                        bool success = int.TryParse(row.PaidTime, out paidTime);
                        if (success)
                        {
                            order.PaidTime = DateUtils.ConvertUnixTimeToDateTime(paidTime);
                        }

                    }
                    if (row.ShippedTime != null)
                    {
                        int shippedTime = 0;
                        bool success = int.TryParse(row.ShippedTime, out shippedTime);
                        if (success)
                        {
                            order.ShippedTime = DateUtils.ConvertUnixTimeToDateTime(shippedTime);
                        }

                    }
                    if (row.MarketTime != null)
                    {
                        int marketTime = 0;
                        bool success = int.TryParse(row.ShippedTime, out marketTime);
                        if (success)
                        {
                            order.MarketTime = DateUtils.ConvertUnixTimeToDateTime(marketTime);
                        }

                    }
                    order.RecordNumber = row.RecordNumber;
                    orderDictionary[order.OrderId] = order;
                    orders.Add(order);
                }

                bool exist = false;
                foreach (OrderDetail detail in order.OrderDetails)
                {
                    if (detail.Id == row.OrderDetailId)
                    {
                        exist = true;
                        break;
                    }
                }

                if (!exist)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.Id = row.OrderDetailId;
                    orderDetail.SKU = row.SKU;
                    int quantity = 0;
                    bool success = int.TryParse(row.Quantity, out quantity);
                    if (!success || quantity < 1)
                    {
                        continue;
                    }
                    orderDetail.Quantity = quantity;

                    double price = 0.0;
                    success = double.TryParse(row.ItemPrice, out price);
                    if (!success)
                    {
                        continue;
                    }
                    orderDetail.Price = price;

                    double shippingFee = 0.0;
                    if (row.ShippingFee != null && row.ShippingFee.Trim().Length > 0)
                    {
                        success = double.TryParse(row.ShippingFee, out shippingFee);
                        if (!success)
                        {
                            continue;
                        }
                    }
                    orderDetail.ShippingFee = shippingFee;

                    orderDetail.ItemId = row.ItemId;
                    orderDetail.ItemName = row.ItemName;

                    order.OrderDetails.Add(orderDetail);
                }

                if (row.Log != null)
                {
                    exist = false;
                    foreach (OrderLog orderLog in order.OrderLogs)
                    {
                        if (orderLog.Id == row.Log.Id)
                        {
                            exist = true;
                            break;
                        }
                    }

                    if (!exist)
                    {
                        OrderLog orderLog = new OrderLog();
                        orderLog.Id = row.Log.Id;
                        orderLog.Notes = row.Log.Notes;
                        orderLog.User = row.Log.Operationuser;
                        orderLog.Time = DateUtils.ConvertUnixTimeToDateTime(row.Log.Operationtime);
                        order.OrderLogs.Add(orderLog);
                    }
                }
            }
            return orders;
        }
        
        public List<OrderSummary> GetOrderSummary()
        {
            List<OrderSummary> summaries = new List<OrderSummary>();
            var q = from ebayTopMenu in m_context.EbayTopmenu
                    join ebayOrder in m_context.EbayOrder
                    on ebayTopMenu.Id.ToString() equals ebayOrder.Status
                    group new { ebayTopMenu, ebayOrder } by new { ebayTopMenu.Id, ebayTopMenu.Name } into g
                    select new OrderSummary { CategoryId = g.Key.Id, CategoryName = g.Key.Name, Count = g.Count() };

            summaries = q.ToList();

            return summaries;
        }
    }
}
