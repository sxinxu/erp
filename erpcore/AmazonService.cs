using Claytondus.AmazonMWS.Orders;
using Claytondus.AmazonMWS.Orders.Model;
using erpcore.entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MarketplaceWebService;
using MarketplaceWebService.Model;

namespace erpcore
{
    public class AmazonService
    {
        // Developer AWS access key
        string accessKey = "AKIAI4WI6RBTNXZXI6NQ";

        // Developer AWS secret key
        string secretKey = "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";

        // The client application name
        string appName = "AmazonSync";

        // The client application version
        string appVersion = "1.0";

        // The endpoint for region service and version (see developer guide)
        // ex: https://mws.amazonservices.com
        string serviceURL = "https://mws.amazonservices.com";

        Dictionary<string, string> sellerIdDictionary = new Dictionary<string, string>();
        Dictionary<string, string> mwsAuthTokenDictionary = new Dictionary<string, string>();
        string marketplaceId = "ATVPDKIKX0DER";
        MarketplaceWebServiceOrders client = null;
        MarketplaceWebServiceClient mwsClient = null;
        List<string> accountNames = new List<string>();

        private v3_allContext m_context = new v3_allContext();
        private static Logger m_logger = NLog.LogManager.GetCurrentClassLogger();

        public AmazonService()
        {
            string accountName = "Amazon-Boshen";
            accountNames.Add(accountName);
            sellerIdDictionary[accountName] = "A35SHV3IZJRAHC";
            mwsAuthTokenDictionary[accountName] = "amzn.mws.c4adcfb3-3335-3677-374f-cf35a85dc01d";

            accountName = "gplusmotor2014@gmail.com";
            accountNames.Add(accountName);
            sellerIdDictionary[accountName] = "ASST1J92GEKSP";
            mwsAuthTokenDictionary[accountName] = "amzn.mws.3cae6454-6002-3b7d-8d38-92856dbdca08";

            accountName = "amazonmotor@163.com";
            accountNames.Add(accountName);
            sellerIdDictionary[accountName] = "A3QK68XH4BGO5V";
            mwsAuthTokenDictionary[accountName] = "amzn.mws.90ae645b-83df-75f1-401e-c948ba8edd9e";

            MarketplaceWebServiceOrdersConfig config = new MarketplaceWebServiceOrdersConfig();
            config.ServiceURL = serviceURL;
            client = new MarketplaceWebServiceOrdersClient(accessKey, secretKey, appName, appVersion, config);

            MarketplaceWebServiceConfig mwsConfig = new MarketplaceWebServiceConfig();
            config.ServiceURL = serviceURL;
            mwsClient = new MarketplaceWebServiceClient(accessKey, secretKey, appName, appVersion, mwsConfig);
        }

        public void ListOrders( string accountName, DateTime createdAfter, DateTime createdBefore )
        {
            try
            {
                ListOrdersRequest request = new ListOrdersRequest();
                request.SellerId = sellerIdDictionary[accountName];
                request.MWSAuthToken = mwsAuthTokenDictionary[accountName];
                request.LastUpdatedAfter = createdAfter;
                request.LastUpdatedBefore = createdBefore;
                request.OrderStatus = new List<string>();
                request.OrderStatus.Add("Unshipped");
                request.OrderStatus.Add("PartiallyShipped");
                List<string> marketplaceIds = new List<string>();
                marketplaceIds.Add(marketplaceId);
                request.MarketplaceId = marketplaceIds;
                ListOrdersResponse response = client.ListOrders(request);

                foreach(Order order in response.ListOrdersResult.Orders)
                {
                    try
                    {
                        if( order.OrderStatus == "Unshipped")
                        {
                            var q = from ebayOrder in m_context.EbayOrder
                                    where ebayOrder.EbayOrdersn == order.AmazonOrderId
                                    select ebayOrder;
                            if( q.Count() == 0)
                            {

                                EbayOrder ebayOrder = new EbayOrder();
                                ebayOrder.EbayOrdersn = order.AmazonOrderId;
                                ebayOrder.Recordnumber = order.AmazonOrderId;
                                ebayOrder.EbayCreatedtime = Convert.ToInt32(order.PurchaseDate.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
                                ebayOrder.EbayPaidtime = ebayOrder.EbayCreatedtime.ToString();
                                ebayOrder.EbayUserid = order.BuyerName;
                                ebayOrder.EbayUsername = order.BuyerName;
                                ebayOrder.EbayUsermail = order.BuyerEmail;
                                ebayOrder.EbayPhone = order.ShippingAddress.Phone;
                                ebayOrder.EbayStreet = order.ShippingAddress.AddressLine1;
                                ebayOrder.EbayStreet1 = order.ShippingAddress.AddressLine2;
                                ebayOrder.EbayCity = order.ShippingAddress.City;
                                ebayOrder.EbayState = order.ShippingAddress.StateOrRegion;
                                ebayOrder.EbayCouny = order.ShippingAddress.CountryCode;
                                if (ebayOrder.EbayCouny == "US")
                                {
                                    ebayOrder.EbayCountryname = "United States";
                                }
                                ebayOrder.EbayPostcode = order.ShippingAddress.PostalCode;
                                ebayOrder.EbayCurrency = order.OrderTotal.CurrencyCode;
                                ebayOrder.EbayTotal = Convert.ToDouble(order.OrderTotal.Amount);
                                ebayOrder.EbayStatus = 1;
                                ebayOrder.EbayUser = "vipadmin";
                                ebayOrder.EbayAccount = accountName;
                                ebayOrder.Status = "0";
                                ebayOrder.EbayCarrier2 = "";
                                ebayOrder.EbayTracknumber2 = "";
                                ebayOrder.IsYichang = "0";
                                ebayOrder.Ishide = 0;
                                ebayOrder.EbayCombine = "0";
                                m_context.EbayOrder.Add(ebayOrder);

                                ListOrderItemsRequest listOrderItemsRequest = new ListOrderItemsRequest();
                                listOrderItemsRequest.SellerId = sellerIdDictionary[accountName];
                                listOrderItemsRequest.MWSAuthToken = mwsAuthTokenDictionary[accountName];
                                listOrderItemsRequest.AmazonOrderId = order.AmazonOrderId;
                                ListOrderItemsResponse itemResponse = client.ListOrderItems(listOrderItemsRequest);
                                int i = 0;
                                foreach (OrderItem orderItem in itemResponse.ListOrderItemsResult.OrderItems)
                                {
                                    EbayOrderdetail orderDetail = new EbayOrderdetail();
                                    orderDetail.EbayOrdersn = order.AmazonOrderId;
                                    if (i > 0)
                                    {
                                        orderDetail.Recordnumber = order.AmazonOrderId + i.ToString();
                                    }
                                    else
                                    {
                                        orderDetail.Recordnumber = order.AmazonOrderId;
                                    }
                                    orderDetail.EbayItemid = orderItem.OrderItemId;
                                    orderDetail.EbayItemtitle = orderItem.Title;
                                    orderDetail.Sku = orderItem.SellerSKU;
                                    if (orderItem.ItemPrice != null)
                                    {
                                        orderDetail.EbayItemprice = (Convert.ToDouble(orderItem.ItemPrice.Amount) / Convert.ToInt32(orderItem.QuantityOrdered)).ToString();
                                    }
                                    else
                                    {
                                        orderDetail.EbayItemprice = "0.0";
                                    }
                                    orderDetail.EbayAmount = orderItem.QuantityOrdered.ToString();
                                    orderDetail.EbayUser = "vipadmin";
                                    orderDetail.Shipingfee = orderItem.ShippingPrice.Amount;
                                    orderDetail.EbayAccount = accountName;
                                    orderDetail.Istrue = 1;
                                    m_context.EbayOrderdetail.Add(orderDetail);
                                    Console.Out.Write(orderItem.SellerSKU);
                                    Console.Out.Write(";");
                                    Console.Out.Write(orderItem.QuantityOrdered.ToString());
                                    Console.Out.Write(",");
                                    i++;
                                }
                            }
                        }
                    }
                    catch(Exception e)
                    {

                    }
                }
            }
            catch(Exception e)
            {

            }
        }

        public Dictionary<string, int> GetInventory( string accountName)
        {
            Dictionary<string, int> inventoryDictionary = new Dictionary<string, int>();
            try
            {
                RequestReportRequest request = new RequestReportRequest();
                request.MWSAuthToken = mwsAuthTokenDictionary[accountName];
                request.Merchant = sellerIdDictionary[accountName];
                request.ReportType = "_GET_FLAT_FILE_OPEN_LISTINGS_DATA_";

                RequestReportResponse response = mwsClient.RequestReport(request);
                string requestId = response.RequestReportResult.ReportRequestInfo.ReportRequestId;

                GetReportListRequest reportListRequest = new GetReportListRequest();
                reportListRequest.MWSAuthToken = mwsAuthTokenDictionary[accountName];
                reportListRequest.Merchant = sellerIdDictionary[accountName];
                reportListRequest.ReportRequestIdList = new IdList();
                reportListRequest.ReportRequestIdList.Id.Add(requestId);

            }
            catch(Exception e)
            {

            }

            return inventoryDictionary;
        }
    }
}
