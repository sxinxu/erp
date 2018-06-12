using erpcore.entities;
using erpcore.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Globalization;

namespace erpcore
{
    public class OrderService : IOrderService
    {
        private IPlatformServiceFactory m_platformServiceFactory;
        private string m_company;
        private string m_connectionString;

        public OrderService(IPlatformServiceFactory platformServiceFactory, string company, string connectionString)
        {
            m_platformServiceFactory = platformServiceFactory;
            m_company = company;
            m_connectionString = connectionString;
        }

        public List<Order> GetOrdersToShip()
        {
            int[] statusList = new int[]{ 848, 849, 924, 926 };
            return GetOrders(statusList);
        }

        private List<Order> GetOrders( int[] statusList)
        {
            List<Order> orders = new List<Order>();
            Dictionary<int, Order> orderDictionary = new Dictionary<int, Order>();

            using (ERPContext context = new ERPContext(m_connectionString))
            {
                var q = from ebayOrder in context.EbayOrder
                        join ebayOrdersLog in context.EbayOrderslog
                        on ebayOrder.EbayId equals ebayOrdersLog.EbayId
                        into logs
                        from log in logs.DefaultIfEmpty()
                        from ebayOrderDetail in context.EbayOrderdetail
                        from ebayTopMenu in context.EbayTopmenu
                        where ebayOrder.EbayOrdersn == ebayOrderDetail.EbayOrdersn
                        where statusList.Contains(ebayOrder.EbayStatus.GetValueOrDefault())
                        where ebayTopMenu.Id == ebayOrder.EbayStatus
                        orderby ebayOrder.EbayId, ebayOrderDetail.Sku, log.Operationtime descending
                        select new
                        {
                            OrderId = ebayOrder.EbayId,
                            OrderSn = ebayOrder.EbayOrdersn,
                            UserId = ebayOrder.EbayUserid,
                            UserName = ebayOrder.EbayUsername,
                            PhoneNo = ebayOrder.EbayPhone,
                            Email = ebayOrder.EbayUsermail,
                            Address1 = ebayOrder.EbayStreet,
                            Address2 = ebayOrder.EbayStreet1,
                            City = ebayOrder.EbayCity,
                            State = ebayOrder.EbayState,
                            PostCode = ebayOrder.EbayPostcode,
                            Country = ebayOrder.EbayCountryname,
                            WarehouseId = ebayOrder.EbayWarehouse,
                            AccountName = ebayOrder.EbayAccount,
                            Carrier = ebayOrder.EbayCarrier,
                            Status = ebayTopMenu.Name,
                            StatusId = ebayOrder.EbayStatus.GetValueOrDefault(),
                            OrderShipFee = ebayOrder.Ordershipfee.GetValueOrDefault(),
                            CreatedTime = ebayOrder.EbayCreatedtime.GetValueOrDefault(),
                            PaidTime = ebayOrder.EbayPaidtime,
                            ShippedTime = ebayOrder.ShippedTime,
                            MarketTime = ebayOrder.EbayMarkettime,
                            RecordNumber = ebayOrder.Recordnumber,
                            OrderDetailId = ebayOrderDetail.EbayId,
                            SKU = ebayOrderDetail.Sku,
                            Quantity = ebayOrderDetail.EbayAmount,
                            ItemPrice = ebayOrderDetail.EbayItemprice,
                            ItemId = ebayOrderDetail.EbayItemid,
                            ItemName = ebayOrderDetail.EbayItemtitle,
                            ShippingFee = ebayOrderDetail.Shipingfee,
                            Log = log
                        };
                foreach (var row in q)
                {
                    Order order = null;
                    if( orderDictionary.ContainsKey(row.OrderId))
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
                        order.Status = row.Status;
                        order.StatusId = row.StatusId;
                        order.ShippingFee = row.OrderShipFee;
                        order.CreatedTime = DateUtils.ConvertUnixTimeToDateTime(row.CreatedTime);
                        if(row.PaidTime != null)
                        {
                            int paidTime = 0;
                            bool success = int.TryParse(row.PaidTime, out paidTime);
                            if( success)
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
                    foreach(OrderDetail detail in order.OrderDetails)
                    {
                        if(detail.Id == row.OrderDetailId)
                        {
                            exist = true;
                            break;
                        }
                    }

                    if(!exist)
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

                    if(row.Log != null)
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
            }
            
            return orders;
        }

        //public void UpdateOrder()

        public Profit GetProfits( string filter, string account )
        {
            Profit profit = new Profit();

            // Read cost
            Dictionary<string, double> costDictionary = new Dictionary<string, double>();
            StreamReader reader = new StreamReader(m_platformServiceFactory.ContentRootPath+"\\cost.csv");
            string s = null;
            while((s=reader.ReadLine()) != null)
            {
                string[] values = s.Split(',');
                if( values.Length > 1 && values[1].Trim().Length > 0)
                {
                    costDictionary[values[0].Trim().ToUpper()] = Convert.ToDouble(values[1].Trim());
                }
            }
            reader.Close();

            // Read dimension to calculate international shipping
            double defaultInternationalShippingFee = 5000 * 30.0 * 20.0 * 10.0 * 0.01 * 0.01 * 0.01 / 62;
            Dictionary<string, double> internationalShippingDictionary = new Dictionary<string, double>();
            reader = new StreamReader(m_platformServiceFactory.ContentRootPath + "\\sizes.csv");
            while ((s = reader.ReadLine()) != null)
            {
                string[] values = s.Split(',');
                string sku = values[0].Trim().ToUpper();
                double length = 30.0;
                double width = 20.0;
                double height = 10.0;
                if(values.Length == 5 && values[2].Trim().Length>0 && values[3].Trim().Length > 0 && values[4].Trim().Length > 0)
                {
                    length = Convert.ToDouble(values[2].Trim());
                    width = Convert.ToDouble(values[3].Trim());
                    height = Convert.ToDouble(values[4].Trim());
                }
                double internationalShipping = 5000*length*width*height*0.01*0.01*0.01/62;
                costDictionary[sku] = internationalShipping; 
            }
            reader.Close();


            CultureInfo cultureInfo = new CultureInfo("en-US");
            bool hasFilter = false;
            bool isMonthFilter = false;
            bool isDayFilter = false;
            int startTime = 0;
            int endTime = 0;
            if (filter.Length == 7)
            {
                hasFilter = true;
                isMonthFilter = true;
                DateTime startDate;
                bool success = DateTime.TryParseExact(filter + "-01", "yyyy-M-d", cultureInfo, DateTimeStyles.None, out startDate);
                if (!success)
                {
                    throw new Exception("Invalid start date.");
                }
                startTime = DateUtils.ConvertToUnixTime(startDate);
                endTime = DateUtils.ConvertToUnixTime(startDate.AddMonths(1));
            }
            else if(filter.Length == 10)
            {
                hasFilter = true;
                isDayFilter = true;
                DateTime startDate;
                bool success = DateTime.TryParseExact(filter, "yyyy-M-d", cultureInfo, DateTimeStyles.None, out startDate);
                if (!success)
                {
                    throw new Exception("Invalid start date.");
                }
                startTime = DateUtils.ConvertToUnixTime(startDate);
                endTime = DateUtils.ConvertToUnixTime(startDate.AddDays(1));
            }

            using (ERPContext context = new ERPContext(m_connectionString))
            {
                var q = from ebayOrder in context.EbayOrder
                        from ebayOrderdetail in context.EbayOrderdetail
                        join ebayProductsCombine in context.EbayProductscombine
                        on ebayOrderdetail.Sku equals ebayProductsCombine.GoodsSn
                        into pb
                        from productsCombine in pb.DefaultIfEmpty()
                        where ebayOrder.EbayOrdersn == ebayOrderdetail.EbayOrdersn
                        where ebayOrder.EbayCreatedtime.GetValueOrDefault() >= startTime
                        where ebayOrder.EbayCreatedtime.GetValueOrDefault() >= endTime
                        where ebayOrder.EbayWarehouse == "101" || ebayOrder.EbayWarehouse == "108" 
                        orderby ebayOrder.EbayCreatedtime
                        select new
                        {
                            Order = ebayOrder,
                            SKU = ebayOrderdetail.Sku,
                            Quantity = ebayOrderdetail.EbayAmount,
                            ItemPrice = ebayOrderdetail.EbayItemprice,
                            ShippingFee = ebayOrderdetail.Shipingfee,
                            FinalValueFee = ebayOrderdetail.FinalValueFee,
                            FeeOrCreditAmount = ebayOrderdetail.FeeOrCreditAmount,
                            ProductsCombineSku = productsCombine != null ? productsCombine.GoodsSncombine:""
                        };
                if( hasFilter)
                {
                    q.Where(a => a.Order.EbayCreatedtime != null && a.Order.EbayCreatedtime >= startTime && a.Order.EbayCreatedtime < endTime);
                }
                else
                {
                    DateTime dateTime = DateTime.Now.AddYears(-1);
                    int time = DateUtils.ConvertToUnixTime(dateTime);
                    q.Where(a => a.Order.EbayCreatedtime != null && a.Order.EbayCreatedtime >= time);
                }
                if( account != "all")
                {
                    q.Where(a => a.Order.EbayAccount == account);
                }

                List<OrderProfit> orderProfitList = new List<OrderProfit>();
                OrderProfit totalProfit = new OrderProfit();
                SortedDictionary<string, OrderProfit> totalDictionary = new SortedDictionary<string, OrderProfit>();
                foreach(var row in q)
                {
                    OrderProfit orderProfit = new OrderProfit();
                    orderProfit.ebay_id = row.Order.EbayId;
                    if( row.ProductsCombineSku.Length > 0 )
                    {
                        string[] values = row.ProductsCombineSku.Split(',');
                        foreach(string value in values)
                        {
                            string[] skus = value.Trim().Split('*');
                            string sku = skus[0].Trim().ToUpper();
                            int quantity = 0;
                            bool success = int.TryParse(skus[1], out quantity);
                            if( success)
                            {
                                if( costDictionary.ContainsKey(sku))
                                {
                                    orderProfit.cost += costDictionary[sku] * quantity;
                                }

                                if (internationalShippingDictionary.ContainsKey(sku))
                                {
                                    orderProfit.internationalShippingFee += internationalShippingDictionary[sku] * quantity;
                                }
                                else
                                {
                                    orderProfit.internationalShippingFee += defaultInternationalShippingFee * quantity;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (costDictionary.ContainsKey(row.SKU))
                        {
                            int quantity = 0;
                            bool success = int.TryParse(row.Quantity, out quantity);
                            if (success)
                            {
                                orderProfit.cost += costDictionary[row.SKU] * quantity;
                            }
                            if (internationalShippingDictionary.ContainsKey(row.SKU))
                            {
                                orderProfit.internationalShippingFee += internationalShippingDictionary[row.SKU] * quantity;
                            }
                            else
                            {
                                orderProfit.internationalShippingFee += defaultInternationalShippingFee * quantity;
                            }
                        }
                    }
                    orderProfit.sku = row.SKU;
                    int quantity1 = 1;
                    bool success1 = int.TryParse(row.Quantity, out quantity1);
                    orderProfit.quantity = quantity1;
                    double itemPrice = 0.0;
                    success1 = double.TryParse(row.ItemPrice, out itemPrice);
                    double shippingFee = 0.0;
                    success1 = double.TryParse(row.ShippingFee, out shippingFee);
                    orderProfit.sales = itemPrice * quantity1 + shippingFee;
                    if (m_platformServiceFactory.GetAmazonService(m_company).isAmazonAccount(row.Order.EbayAccount))
                    {
                        orderProfit.ebayFee = orderProfit.sales * 0.15;
                    }
                    else
                    {
                        orderProfit.ebayFee = row.FinalValueFee.GetValueOrDefault();
                    }
                    double feeOrCreditAmount = 0.0;
                    success1 = double.TryParse(row.FeeOrCreditAmount, out feeOrCreditAmount);
                    orderProfit.paypalFee = feeOrCreditAmount;
                    orderProfit.discount = row.Order.Discount.GetValueOrDefault();
                    orderProfit.shippingFee = row.Order.Ordershipfee.GetValueOrDefault();
                    DateTime date = DateUtils.ConvertUnixTimeToDateTime(row.Order.EbayCreatedtime.GetValueOrDefault());
                    orderProfit.date = date.ToString("yyyy-MM-dd");
                    orderProfit.profit = orderProfit.sales - orderProfit.ebayFee - orderProfit.paypalFee - orderProfit.shippingFee - orderProfit.internationalShippingFee - orderProfit.discount;

                    if( isMonthFilter )
                    {
                        string day = orderProfit.date;
                        OrderProfit dayTotal = null;
                        if( totalDictionary.ContainsKey(day))
                        {
                            dayTotal = totalDictionary[day];
                        }
                        else
                        {
                            dayTotal = new OrderProfit();
                            dayTotal.date = day;
                            totalDictionary[day] = dayTotal;
                        }
                        dayTotal.sales += orderProfit.sales;
                        dayTotal.ebayFee += orderProfit.ebayFee;
                        dayTotal.paypalFee += orderProfit.paypalFee;
                        dayTotal.shippingFee += orderProfit.shippingFee;
                        dayTotal.profit += orderProfit.profit;
                        dayTotal.cost += orderProfit.cost;
                        dayTotal.internationalShippingFee += orderProfit.internationalShippingFee;
                        dayTotal.discount += orderProfit.discount;
                        dayTotal.pieces++;
                    }
                    else if(isDayFilter)
                    {
                        orderProfitList.Add(orderProfit);
                    }
                    else
                    {
                        string month = date.ToString("yyyy-MM");
                        OrderProfit monthTotal = null;
                        if (totalDictionary.ContainsKey(month))
                        {
                            monthTotal = totalDictionary[month];
                            monthTotal.date = month;
                        }
                        else
                        {
                            monthTotal = new OrderProfit();
                            totalDictionary[month] = monthTotal;
                        }
                        monthTotal.sales += orderProfit.sales;
                        monthTotal.ebayFee += orderProfit.ebayFee;
                        monthTotal.paypalFee += orderProfit.paypalFee;
                        monthTotal.shippingFee += orderProfit.shippingFee;
                        monthTotal.profit += orderProfit.profit;
                        monthTotal.cost += orderProfit.cost;
                        monthTotal.internationalShippingFee += orderProfit.internationalShippingFee;
                        monthTotal.discount += orderProfit.discount;
                        monthTotal.pieces++;
                    }

                    totalProfit.sales += orderProfit.sales;
                    totalProfit.ebayFee += orderProfit.ebayFee;
                    totalProfit.paypalFee += orderProfit.paypalFee;
                    totalProfit.shippingFee += orderProfit.shippingFee;
                    totalProfit.profit += orderProfit.profit;
                    totalProfit.cost += orderProfit.cost;
                    totalProfit.internationalShippingFee += orderProfit.internationalShippingFee;
                    totalProfit.discount += orderProfit.discount;
                    totalProfit.pieces++;
                }

                if( isMonthFilter )
                {
                    profit.filterType = "monthFilter";
                    profit.orders = totalDictionary.Values.ToList();
                }
                else if( isDayFilter)
                {
                    profit.filterType = "dayFilter";
                    profit.orders = orderProfitList.ToList();
                }
                else
                {
                    profit.filterType = "noFilter";
                    profit.orders = totalDictionary.Values.ToList();
                }
                profit.total = totalProfit;
            }

            return profit;
        }
    }
}
