using erpcore.entities;
using erpcore.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Globalization;
using NLog;

namespace erpcore
{
    public class OrderService : IOrderService
    {
        private IPlatformServiceFactory m_platformServiceFactory;
        private string m_company;
        private string m_connectionString;
        private int[] m_storeIds;
        private static Logger m_logger = NLog.LogManager.GetCurrentClassLogger();

        public OrderService(IPlatformServiceFactory platformServiceFactory, string company, string connectionString, int[] storeIds)
        {
            m_platformServiceFactory = platformServiceFactory;
            m_company = company;
            m_connectionString = connectionString;
            m_storeIds = storeIds;
        }

        public List<Order> SearchOrders( string searchType, string searchText )
        {
            m_logger.Info("Search Type: " + searchType + ", Search Text: " + searchText);
            List<Order> orders = null;
            if( searchType == "OrderId" )
            {
                int orderId = 0;
                bool success = int.TryParse(searchText, out orderId);
                if( success )
                {
                    orders = GetOrders((a => a.ebayOrder.EbayId == orderId));
                }
            }
            else if( searchType == "UserId")
            {
                orders = GetOrders((a => a.ebayOrder.EbayUserid.Contains(searchText)));
            }
            else if (searchType == "UserName")
            {
                orders = GetOrders((a => a.ebayOrder.EbayUsername.Contains(searchText)));
            }
            else if (searchType == "SKU")
            {
                orders = GetOrders((a => a.ebayOrderDetail.Sku.Contains(searchText)));
            }
            else if (searchType == "TrackingNumber")
            {
                orders = GetOrders((a => a.ebayOrder.EbayTracknumber == searchText));
            }
            return orders;
        }

        public List<Order> GetOrdersToShip()
        {
            int[] statusList = new int[]{ 848, 849, 924, 926 };
            return GetOrders(a => statusList.Contains(a.ebayOrder.EbayStatus.GetValueOrDefault()));
        }

        private class OrderResult
        {
            public EbayOrder ebayOrder;
            public EbayOrderdetail ebayOrderDetail;
            public EbayTopmenu ebayTopMenu;
            public EbayOrderslog log;
        }

        private List<Order> GetOrders( params Func<OrderResult, bool>[] filters )
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
                    foreach( var filter in filters)
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
                        order.TrackingNumber = row.TrackingNumber;
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
        

        public Profit GetProfits( string dateFilter, string skuFilter, string account )
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
                internationalShippingDictionary[sku] = internationalShipping; 
            }
            reader.Close();


            CultureInfo cultureInfo = new CultureInfo("en-US");
            bool isMonthFilter = false;
            bool isDayFilter = false;
            int startTime = 0;
            int endTime = 0;
            if(dateFilter.Contains("to"))
            {
                string[] dates = dateFilter.Split("to");
                if( dates.Length != 2)
                {
                    throw new Exception("Invalid dates");
                }
                isDayFilter = true;
                DateTime startDate;
                bool success = DateTime.TryParseExact(dates[0], "yyyy-M-d", cultureInfo, DateTimeStyles.None, out startDate);
                if (!success)
                {
                    throw new Exception("Invalid start date.");
                }
                DateTime endDate;
                success = DateTime.TryParseExact(dates[1], "yyyy-M-d", cultureInfo, DateTimeStyles.None, out endDate);
                if (!success)
                {
                    throw new Exception("Invalid end date.");
                }
                startTime = DateUtils.ConvertToUnixTime(startDate);
                endTime = DateUtils.ConvertToUnixTime(endDate);
            }
            else if (dateFilter.Length == 7)
            {
                isMonthFilter = true;
                DateTime startDate;
                bool success = DateTime.TryParseExact(dateFilter + "-01", "yyyy-M-d", cultureInfo, DateTimeStyles.None, out startDate);
                if (!success)
                {
                    throw new Exception("Invalid start date.");
                }
                startTime = DateUtils.ConvertToUnixTime(startDate);
                endTime = DateUtils.ConvertToUnixTime(startDate.AddMonths(1));
            }
            else if(dateFilter.Length == 10)
            {
                isDayFilter = true;
                DateTime startDate;
                bool success = DateTime.TryParseExact(dateFilter, "yyyy-M-d", cultureInfo, DateTimeStyles.None, out startDate);
                if (!success)
                {
                    throw new Exception("Invalid start date.");
                }
                startTime = DateUtils.ConvertToUnixTime(startDate);
                endTime = DateUtils.ConvertToUnixTime(startDate.AddDays(1));
            }
            else
            {
                DateTime dateTime = DateTime.Now.AddYears(-1);
                startTime = DateUtils.ConvertToUnixTime(dateTime);
                endTime = DateUtils.ConvertToUnixTime(DateTime.Now);
            }

            using (ERPContext context = new ERPContext(m_connectionString))
            {
                string[] storeIdStrings = new string[m_storeIds.Length];
                for(int i = 0; i < m_storeIds.Length; i++)
                {
                    storeIdStrings[i] = m_storeIds[i].ToString();
                }
                var q = from ebayOrder in context.EbayOrder
                        from ebayOrderdetail in context.EbayOrderdetail
                        join ebayProductsCombine in context.EbayProductscombine
                        on ebayOrderdetail.Sku equals ebayProductsCombine.GoodsSn
                        into pb
                        from productsCombine in pb.DefaultIfEmpty()
                        where ebayOrder.EbayOrdersn == ebayOrderdetail.EbayOrdersn
                        where storeIdStrings.Contains(ebayOrder.EbayWarehouse)
                        where ebayOrder.EbayStatus == 851
                        where ebayOrder.EbayCreatedtime != null && ebayOrder.EbayCreatedtime >= startTime && ebayOrder.EbayCreatedtime < endTime
                        orderby ebayOrder.EbayCreatedtime
                        select new
                        {
                            Order = ebayOrder,
                            SKU = ebayOrderdetail.Sku,
                            Quantity = ebayOrderdetail.EbayAmount,
                            ItemPrice = ebayOrderdetail.EbayItemprice,
                            ItemTitle = ebayOrderdetail.EbayItemtitle,
                            ShippingFee = ebayOrderdetail.Shipingfee,
                            FinalValueFee = ebayOrderdetail.FinalValueFee,
                            FeeOrCreditAmount = ebayOrderdetail.FeeOrCreditAmount,
                            ProductsCombineSku = productsCombine != null ? productsCombine.GoodsSncombine:""
                        };
                if( account.ToUpper() != "ALL")
                {
                    q = from a in q
                        where a.Order.EbayAccount == account
                        select a;
                }
                if( skuFilter.ToUpper() != "ALL")
                {
                    q = from a in q
                        where a.SKU == skuFilter
                        select a;
                }

                List < OrderProfit > orderProfitList = new List<OrderProfit>();
                OrderProfit totalProfit = new OrderProfit();
                SortedDictionary<string, OrderProfit> totalDictionary = new SortedDictionary<string, OrderProfit>();
                int count = q.Count();
                foreach(var row in q)
                {
                    OrderProfit orderProfit = new OrderProfit();
                    orderProfit.ebay_id = row.Order.EbayId;
                    orderProfit.account = row.Order.EbayAccount;
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
                    orderProfit.title = row.ItemTitle;
                    int quantity1 = 1;
                    bool success1 = int.TryParse(row.Quantity, out quantity1);
                    orderProfit.quantity = quantity1;
                    double itemPrice = 0.0;
                    success1 = double.TryParse(row.ItemPrice, out itemPrice);
                    double shippingFee = 0.0;
                    success1 = double.TryParse(row.ShippingFee, out shippingFee);
                    orderProfit.sales = itemPrice * quantity1 + shippingFee;
                    if (m_platformServiceFactory.GetAmazonService(m_company).GetAccountNames().Contains(row.Order.EbayAccount))
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
                    orderProfit.profit = orderProfit.sales - orderProfit.cost - orderProfit.ebayFee - orderProfit.paypalFee - orderProfit.shippingFee - orderProfit.internationalShippingFee - orderProfit.discount;

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
                        orderProfit.name = row.Order.EbayUsername;
                        orderProfit.postCode = row.Order.EbayPostcode;
                        orderProfit.state = row.Order.EbayState;
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
                profit.account = account;
                profit.sku = skuFilter;
            }

            return profit;
        }

        public void UpdateAccountListingQuantities( string accountName, bool refresh )
        {
            bool allAccounts = accountName.ToUpper() == "ALL";
            bool isAmazonAccount = false;
            IAmazonService amazonService = m_platformServiceFactory.GetAmazonService(m_company);
            if ( !allAccounts)
            {
                isAmazonAccount = amazonService.GetAccountNames().Contains(accountName);
            }
            using (ERPContext context = new ERPContext(m_connectionString))
            {
                IEbayService ebayService = m_platformServiceFactory.GetEbayService(m_company);
                if ( refresh )
                {
                    if (allAccounts)
                    {
                        ebayService.RefreshListings(context);
                        amazonService.RefreshListings(context);
                    }
                    else if( !isAmazonAccount)
                    {
                        ebayService.RefreshListings(context, accountName);
                        amazonService.RefreshListings(context, accountName);
                    }
                }
                
                // Get inventory
                Dictionary<string, int> inventoryDictionary = new Dictionary<string, int>();
                var inventoryQuery = from ebayOnHandle in context.EbayOnhandle
                                     where m_storeIds.Contains(ebayOnHandle.StoreId)
                                     select new { sku = ebayOnHandle.GoodsSn, quantity = ebayOnHandle.GoodsCount.GetValueOrDefault() };
                foreach (var row in inventoryQuery)
                {
                    if (inventoryDictionary.ContainsKey(row.sku))
                    {
                        inventoryDictionary[row.sku] += row.quantity;
                    }
                    else
                    {
                        inventoryDictionary[row.sku] = row.quantity;
                    }
                }

                var orderQuery = from ebayOrder in context.EbayOrder
                                 from ebayOrderDetail in context.EbayOrderdetail
                                 where ebayOrder.EbayOrdersn == ebayOrderDetail.EbayOrdersn
                                 where ebayOrder.EbayCouny == "US"
                                 where ebayOrder.EbayStatus == 1 || ebayOrder.EbayStatus == 848 || ebayOrder.EbayStatus == 924 || ebayOrder.EbayStatus == 850
                                 select new { sku = ebayOrderDetail.Sku, ebayAmount = ebayOrderDetail.EbayAmount };
                foreach( var row in orderQuery)
                {
                    if (inventoryDictionary.ContainsKey(row.sku))
                    {
                        int quantity = 0;
                        int.TryParse(row.ebayAmount, out quantity);
                        inventoryDictionary[row.sku] -= quantity;
                    }
                }

                // Get product combine
                Dictionary<string, Dictionary<string, int>> productCombineDictionary = new Dictionary<string, Dictionary<string, int>>();
                var productsCombineQuery = from productsCombine in context.EbayProductscombine
                                           select productsCombine;
                foreach (var row in productsCombineQuery)
                {
                    string sku = row.GoodsSn;
                    Dictionary<string, int> subSkus = new Dictionary<string, int>();
                    string[] skuStrings = row.GoodsSncombine.Split(',');
                    foreach (string skuString in skuStrings)
                    {
                        if (skuString.Trim().Length > 0)
                        {
                            string[] values = skuString.Trim().Split('*');
                            if (values.Length == 2)
                            {
                                int quantity1 = 0;
                                bool success = Int32.TryParse(values[1].Trim(), out quantity1);
                                if (success)
                                {
                                    subSkus[values[0].ToUpper().Trim()] = quantity1;
                                }
                                else
                                {
                                    m_logger.Error("Combined Sku Error: " + row.GoodsSn);
                                    continue;
                                }
                            }
                            else
                            {
                                m_logger.Error("Combined Sku Error: " + row.GoodsSn);
                                continue;
                            }
                        }
                    }
                    productCombineDictionary[sku] = subSkus;
                }

                if (allAccounts || !isAmazonAccount)
                {
                    ebayService.UpdateListingQuantities(context, accountName, inventoryDictionary, productCombineDictionary);
                }

                if( allAccounts || isAmazonAccount)
                {
                    amazonService.UpdateListingQuantities(context, accountName, inventoryDictionary, productCombineDictionary);
                }
            }
        }

        public void UpdateSKUListingQuantities(string sku)
        {
            using (ERPContext context = new ERPContext(m_connectionString))
            {
                UpdateSKUListingQuantities(context, sku);
            }
        }

        public void UpdateSKUListingQuantities(ERPContext context, string sku)
        {
            IEbayService ebayService = m_platformServiceFactory.GetEbayService(m_company);
            IAmazonService amazonService = m_platformServiceFactory.GetAmazonService(m_company);
            IInventoryService inventoryService = m_platformServiceFactory.GetInventoryService(m_company);
            int quantity = 0;
            bool found = inventoryService.GetWarehouseQuantity(context, sku, out quantity);
            if (found)
            {
                ebayService.UpdateListingQuantities(context, sku, quantity);
                amazonService.UpdateListingQuantities(context, sku, quantity);
            }

            // Handle productsCombine
            var productsCombineQuery = from productsCombine in context.EbayProductscombine
                                        where productsCombine.GoodsSncombine.Contains(sku)
                                        select productsCombine;
            foreach (var row in productsCombineQuery)
            {
                found = false;
                string productCombineSku = row.GoodsSn;
                int warehouseQuantity = -1;
                string[] skuStrings = row.GoodsSncombine.Split(',');
                foreach (string skuString in skuStrings)
                {
                    if (skuString.Trim().Length > 0)
                    {
                        string[] values = skuString.Trim().Split('*');
                        if (values.Length == 2)
                        {
                            string sku1 = values[0].Trim();
                            int quantity1 = 0;
                            bool success = Int32.TryParse(values[1].Trim(), out quantity1);
                            if (success)
                            {
                                int quantity2 = 0;
                                found = m_platformServiceFactory.GetInventoryService(m_company).GetWarehouseQuantity(context, sku1, out quantity2);
                                if (found)
                                {
                                    quantity2 = quantity2 / quantity1;
                                    if (warehouseQuantity < 0 || quantity2 < warehouseQuantity)
                                    {
                                        warehouseQuantity = quantity2;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                m_logger.Error("Combined Sku Error: " + row.GoodsSn+", "+row.GoodsSncombine);
                            }
                        }
                        else
                        {
                            m_logger.Error("Combined Sku Error: " + row.GoodsSn + ", " + row.GoodsSncombine);
                        }
                    }
                }

                if (found)
                {
                    ebayService.UpdateListingQuantities(context, sku, quantity);
                    amazonService.UpdateListingQuantities(context, sku, quantity);
                }
            }
        }

        public void SyncOrders(List<string> accountNames, DateTime createdTimeFrom, DateTime createdTimeTo)
        {
            using (ERPContext context = new ERPContext(m_connectionString))
            {
                IEbayService ebayService = m_platformServiceFactory.GetEbayService(m_company);
                IAmazonService amazonService = m_platformServiceFactory.GetAmazonService(m_company);
                List<string> allAmazonAccountNames = amazonService.GetAccountNames();
                List<EbayOrderdetail> orderDetails = new List<EbayOrderdetail>();
                foreach (string accountName in accountNames)
                {
                    if (allAmazonAccountNames.Contains(accountName))
                    {
                        amazonService.SyncOrders( context, accountName, createdTimeFrom, createdTimeTo, orderDetails);
                    }
                    else
                    {
                        ebayService.SyncOrders( context, accountName, createdTimeFrom, createdTimeTo, orderDetails);
                    }
                }

                UpdateListings(context, orderDetails);
            }
        }

        public void UpdateListings(ERPContext context, List<EbayOrderdetail> orderDetails)
        {
            IAmazonService amazonService = m_platformServiceFactory.GetAmazonService(m_company);
            List<string> amazonAccountNames = amazonService.GetAccountNames();
            HashSet<string> skus = new HashSet<string>();
            foreach (EbayOrderdetail orderDetail in orderDetails)
            {
                skus.Add(orderDetail.Sku);

                int quantity = 0;
                bool success = int.TryParse(orderDetail.EbayAmount, out quantity);
                if (success)
                {
                    if ( amazonAccountNames.Contains(orderDetail.EbayAccount))
                    {
                        var q = from amazonList in context.AmazonList
                                where amazonList.SKU == orderDetail.Sku
                                where amazonList.AccountName == orderDetail.EbayAccount
                                select amazonList;
                        if( q.Count() > 0 )
                        {
                            AmazonList listing = q.First();
                            listing.Quantity = listing.Quantity - quantity;
                        }
                    }
                    else
                    {
                        var q = from ebayList in context.EbayList
                                where ebayList.ItemId == orderDetail.EbayItemid
                                where ebayList.EbayAccount == orderDetail.EbayAccount
                                where ebayList.Sku == orderDetail.Sku
                                select ebayList;
                        if (q.Count() > 0)
                        {
                            EbayList listing = q.First();
                            listing.QuantityAvailable = listing.QuantityAvailable.GetValueOrDefault() - quantity;
                        }
                        else
                        {
                            var q1 = from ebayList in context.EbayList
                                     from ebayListVariations in context.EbayListvariations
                                     where ebayList.ItemId == ebayListVariations.Itemid
                                     where ebayList.ItemId == orderDetail.EbayItemid
                                     where ebayList.EbayAccount == orderDetail.EbayAccount
                                     where ebayListVariations.Sku == orderDetail.Sku
                                     select ebayListVariations;
                            if (q1.Count() > 0)
                            {
                                EbayListvariations listingVariations = q1.First();
                                listingVariations.QuantityAvailable = listingVariations.QuantityAvailable - quantity;
                            }
                        }
                    }
                }
            }
            context.SaveChanges();

            // Check product combines
            List<string> skuList = skus.ToList();
            var productsCombineQuery = from productsCombine in context.EbayProductscombine
                                       where skuList.Contains(productsCombine.GoodsSn)
                                       select productsCombine;
            foreach (var row in productsCombineQuery)
            {
                skus.Remove(row.GoodsSn);
                string[] skuStrings = row.GoodsSncombine.Split(',');
                foreach (string skuString in skuStrings)
                {
                    if (skuString.Trim().Length > 0)
                    {
                        string[] values = skuString.Trim().Split('*');
                        if (values.Length == 2)
                        {
                            string sku = values[0].Trim();
                            UpdateSKUListingQuantities(sku);
                        }
                        else
                        {
                            m_logger.Error("Combined Sku Error: " + row.GoodsSn + ", " + row.GoodsSncombine);
                        }
                    }
                }
            }

            foreach (string sku in skus)
            {
                UpdateSKUListingQuantities(sku);
            }
        }


        public void ExportUPS()
        {
            using (ERPContext context = new ERPContext(m_connectionString))
            {

            }
        }

        public void UploadTrackings( List<Tracking> trackings)
        {
            using (ERPContext context = new ERPContext(m_connectionString))
            {
                foreach( Tracking tracking in trackings )
                {
                    var q = from ebayOrder in context.EbayOrder
                            where ebayOrder.EbayId == tracking.OrderId
                            select ebayOrder;
                    if( q.Count() > 0 )
                    {
                        EbayOrder order = q.First();
                        order.EbayTracknumber = tracking.TrackingNumber;
                        order.Ordershipfee = (float)tracking.ShippingFee;
                        order.EbayCarrier = tracking.Carrier.ToString();
                    }
                }
                context.SaveChanges();
            }
        }


        public void MarkShipped( List<int> orderIds )
        {

        }
        public List<OrderSummary> GetOrderSummary()
        {
            List<OrderSummary> summaries = new List<OrderSummary>();

            using (ERPContext context = new ERPContext(m_connectionString))
            {
                var q = from ebayTopMenu in context.EbayTopmenu
                        join ebayOrder in context.EbayOrder
                        on ebayTopMenu.Id.ToString() equals ebayOrder.Status
                        group new { ebayTopMenu, ebayOrder } by new { ebayTopMenu.Id, ebayTopMenu.Name } into g
                        select new OrderSummary { CategoryId = g.Key.Id, CategoryName = g.Key.Name, Count = g.Count()};

                summaries = q.ToList();
            }

            return summaries;
        }
    }

}
