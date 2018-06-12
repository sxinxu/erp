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
using System.Threading;
using System.IO;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace erpcore
{
    public class AmazonService : IAmazonService
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
        
        private static Logger m_logger = NLog.LogManager.GetCurrentClassLogger();

        private string m_connectionString;

        public AmazonService( string connectionString)
        {
            m_connectionString = connectionString;
            using (ERPContext context = new ERPContext(m_connectionString))
            {
                var q = from amazonAccount in context.AmazonAccount
                        select amazonAccount;
                foreach (var row in q)
                {
                    sellerIdDictionary[row.AccountName] = row.SellerId;
                    mwsAuthTokenDictionary[row.AccountName] = row.MWSAuthToken;
                }
            }

            MarketplaceWebServiceOrdersConfig config = new MarketplaceWebServiceOrdersConfig();
            config.ServiceURL = serviceURL;
            client = new MarketplaceWebServiceOrdersClient(accessKey, secretKey, appName, appVersion, config);

            MarketplaceWebServiceConfig mwsConfig = new MarketplaceWebServiceConfig();
            mwsConfig.ServiceURL = serviceURL;
            mwsClient = new MarketplaceWebServiceClient(accessKey, secretKey, appName, appVersion, mwsConfig);
        }

        public bool isAmazonAccount(string accountName)
        {
            if( sellerIdDictionary.ContainsKey(accountName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ListOrders( string accountName, DateTime createdAfter, DateTime createdBefore )
        {
            using (ERPContext context = new ERPContext(m_connectionString))
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

                    foreach (Order order in response.ListOrdersResult.Orders)
                    {
                        try
                        {
                            if (order.OrderStatus == "Unshipped")
                            {
                                var q = from ebayOrder in context.EbayOrder
                                        where ebayOrder.EbayOrdersn == order.AmazonOrderId
                                        select ebayOrder;
                                if (q.Count() == 0)
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
                                    context.EbayOrder.Add(ebayOrder);

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
                                        context.EbayOrderdetail.Add(orderDetail);
                                        Console.Out.Write(orderItem.SellerSKU);
                                        Console.Out.Write(";");
                                        Console.Out.Write(orderItem.QuantityOrdered.ToString());
                                        Console.Out.Write(",");
                                        i++;
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                catch (Exception e)
                {
                    m_logger.Error(e.Message);
                }
            }
        }

        public async void UpdateInventory(string accountName, Dictionary<string,int> quantities)
        {
            XNamespace xsi = XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance");
            XElement root = new XElement("AmazonEnvelope",
                new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                new XAttribute(xsi+"noNamespaceSchemaLocation", "amzn-envelope.xsd"),
                new XElement("Header",
                    new XElement("DocumentVersion", "1.01"),
                    new XElement("MerchantIdentifier", sellerIdDictionary[accountName])),
                    new XElement("MessageType", "Inventory"));
            int messageId = 1;
            foreach( KeyValuePair<string,int> pair in quantities)
            {
                root.Add(new XElement("Message",
                            new XElement("MessageID", messageId),
                            new XElement("OperationType", "Update"),
                            new XElement("Inventory", 
                                new XElement("SKU", pair.Key),
                                new XElement("Quantity", pair.Value),
                                new XElement("FulfillmentLatency",1))));
                messageId++;
            }
            SubmitFeed(accountName, root);
        }
        
        public List<XElement> SubmitFeed( string accountName, XElement feed)
        {
            List<XElement> errors = new List<XElement>();
            SubmitFeedRequest request = new SubmitFeedRequest();
            request.FeedType = "_POST_INVENTORY_AVAILABILITY_DATA_";
            request.MWSAuthToken = mwsAuthTokenDictionary[accountName];
            request.Merchant = sellerIdDictionary[accountName];
            request.MarketplaceIdList = new IdList();
            request.MarketplaceIdList.Id = new List<string>();
            request.MarketplaceIdList.Id.Add(marketplaceId);
            MemoryStream memoryStream = new MemoryStream();
            feed.Save(memoryStream);
            request.FeedContent = memoryStream;
            request.FeedContent.Position = 0;
            request.ContentMD5 = MarketplaceWebServiceClient.CalculateContentMD5(request.FeedContent);
            request.FeedContent.Position = 0;
            SubmitFeedResponse response = mwsClient.SubmitFeed(request);
            memoryStream.Close();
            string feedSubmissionId = response.SubmitFeedResult.FeedSubmissionInfo.FeedSubmissionId;

            int count = 0;
            bool done = false;
            while (count < 100 && !done)
            {
                Thread.Sleep(60000);
                GetFeedSubmissionListRequest feedSubmissionListRequest = new GetFeedSubmissionListRequest();
                feedSubmissionListRequest.MWSAuthToken = mwsAuthTokenDictionary[accountName];
                feedSubmissionListRequest.Merchant = sellerIdDictionary[accountName];
                feedSubmissionListRequest.FeedSubmissionIdList = new IdList();
                feedSubmissionListRequest.FeedSubmissionIdList.Id.Add(feedSubmissionId);
                GetFeedSubmissionListResponse feedSubmissionResponse = mwsClient.GetFeedSubmissionList(feedSubmissionListRequest);
                foreach( FeedSubmissionInfo info in feedSubmissionResponse.GetFeedSubmissionListResult.FeedSubmissionInfo)
                {
                    if(info.FeedSubmissionId == feedSubmissionId )
                    {
                        if( info.FeedProcessingStatus == "_DONE_")
                        {
                            done = true;
                            GetFeedSubmissionResultRequest feedSubmissionResultRequest = new GetFeedSubmissionResultRequest();
                            feedSubmissionResultRequest.MWSAuthToken = mwsAuthTokenDictionary[accountName];
                            feedSubmissionResultRequest.Merchant = sellerIdDictionary[accountName];
                            feedSubmissionResultRequest.FeedSubmissionId = feedSubmissionId;

                            MemoryStream stream = new MemoryStream();
                            feedSubmissionResultRequest.FeedSubmissionResult = stream;
                            GetFeedSubmissionResultResponse feedSubmissionResultResponse = mwsClient.GetFeedSubmissionResult(feedSubmissionResultRequest);

                            XElement responseElement = XElement.Load(stream);
                            IEnumerable<XElement> messages = responseElement.Descendants("Message");
                            foreach(XElement message in messages)
                            {
                                XElement processingReportElement = message.Element("ProcessingReport");
                                int nError = (int)processingReportElement.Element("ProcessingSummary").Element("MessagesWithError");
                                if( nError > 0)
                                {
                                    int messageId = (int)message.Element("MessageID");

                                }
                            }
                        }
                    }
                }
                count++;
            }

            return errors;
        }

        public void GetInventory( string accountName)
        {
            try
            {
                RequestReportRequest request = new RequestReportRequest();
                request.MWSAuthToken = mwsAuthTokenDictionary[accountName];
                request.Merchant = sellerIdDictionary[accountName];
                request.ReportType = "_GET_FLAT_FILE_OPEN_LISTINGS_DATA_";

                RequestReportResponse response = mwsClient.RequestReport(request);
                string requestId = response.RequestReportResult.ReportRequestInfo.ReportRequestId;

                int count = 0;
                bool done = false;
                while( count < 100 && !done)
                {
                    Thread.Sleep(60000);
                    GetReportRequestListRequest reportListRequest = new GetReportRequestListRequest();
                    reportListRequest.MWSAuthToken = mwsAuthTokenDictionary[accountName];
                    reportListRequest.Merchant = sellerIdDictionary[accountName];
                    reportListRequest.ReportRequestIdList = new IdList();
                    reportListRequest.ReportRequestIdList.Id.Add(requestId);
                    GetReportRequestListResponse reportListResponse = mwsClient.GetReportRequestList(reportListRequest);
                    foreach (ReportRequestInfo info in reportListResponse.GetReportRequestListResult.ReportRequestInfo)
                    {
                        if (info.ReportRequestId == requestId)
                        {
                            if (info.ReportProcessingStatus == "_DONE_")
                            {
                                done = true;
                                GetInventoryReport(accountName, info.GeneratedReportId);
                            }
                        }
                    }
                    count++;
                }
            }
            catch(Exception e)
            {
                m_logger.Error(e.Message);
            }
        }

        private void GetInventoryReport( string accountName, string reportId )
        {
            GetReportRequest request = new GetReportRequest();
            request.MWSAuthToken = mwsAuthTokenDictionary[accountName];
            request.Merchant = sellerIdDictionary[accountName];
            request.ReportId = reportId;
            MemoryStream stream = new MemoryStream();
            request.Report = stream;
            GetReportResponse response = mwsClient.GetReport(request);
            ParseInventoryReport(accountName, stream);
        }

        private void ParseInventoryReport( string accountName, Stream stream )
        {
            using (ERPContext context = new ERPContext(m_connectionString))
            {
                Dictionary<string, AmazonList> skuDictionary = new Dictionary<string, AmazonList>();
                var q = from amazonList in context.AmazonList
                        where amazonList.AccountName == accountName
                        select amazonList;
                foreach(var row in q)
                {
                    skuDictionary[row.SKU] = row;
                }
                StreamReader reader = new StreamReader(stream);
                string s = null;
                reader.ReadLine();
                while ((s = reader.ReadLine()) != null)
                {
                    string[] values = s.Split('\t');
                    if (values.Length == 4)
                    {
                        string sku = values[0];
                        string asin = values[1];
                        decimal price = 0;
                        bool success = decimal.TryParse(values[2], out price);
                        if( !success)
                        {
                            m_logger.Error("Wrong price. " + s);
                            continue;
                        }
                        int quantity = 0;
                        success = int.TryParse(values[3], out quantity);
                        if (!success)
                        {
                            m_logger.Error("Wrong quantity. " + s);
                            continue;
                        }
                        
                        AmazonList list = null;
                        if( skuDictionary.ContainsKey(sku) )
                        {
                            list = skuDictionary[sku];
                            list.ASIN = asin;
                            list.Price = price;
                            list.Quantity = quantity;
                            skuDictionary.Remove(sku);
                        }
                        else
                        {
                            list = new AmazonList();
                            list.AccountName = accountName;
                            list.SKU = sku;
                            list.ASIN = asin;
                            list.Price = price;
                            list.Quantity = quantity;
                            context.AmazonList.Add(list);
                        }
                    }
                }
                reader.Close();

                foreach( KeyValuePair<string, AmazonList> pair in skuDictionary)
                {
                    context.AmazonList.Remove(pair.Value);
                }
                context.SaveChanges();
            }
        }
    }
}
