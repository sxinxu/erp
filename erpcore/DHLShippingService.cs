using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using NLog;
using erpcore.models;

namespace erpcore
{
    public class DHLShippingService : IShippingService
    {
        private Dictionary<string, string> zoneMap;
        private Dictionary<double, double> smallRateMap;
        private Dictionary<double, double[]> largeRateMap;
        private Dictionary<double, double> smallExpressRateMap;
        private Dictionary<double, double[]> largeExpressRateMap;
        private Dictionary<double, double[]> expressMaxRateMap;
        private static Logger m_logger = NLog.LogManager.GetCurrentClassLogger();

        public DHLShippingService()
        {
            zoneMap = buildZoneMap();
            smallRateMap = buildSmallRateMap();
            largeRateMap = buildLargeRateMap();
            smallExpressRateMap = buildSmallExpressRateMap();
            largeExpressRateMap = buildLargeExpressRateMap();
            expressMaxRateMap = buildExpressMaxRateMap();
        }

        public string authenticateDHL()
        {
            string accessToken = null;
            WebRequest webRequest = WebRequest.Create("https://api.dhlglobalmail.com/v1/auth/access_token.xml?username=sunrise.track&password=jnvcgojd&state=sunrise");
            webRequest.ContentType = "application/xml;charset=UTF-8";
            WebResponse response = webRequest.GetResponse();
            XElement root = XElement.Load(response.GetResponseStream());
            IEnumerable<XElement> tokens = root.Descendants("AccessToken");
            if( tokens.Count() == 1)
            {
                accessToken = (string)tokens.ElementAt(0);
            }

            return accessToken;
        }

        public Dictionary<string, double> getRate(Order order)
        {
            if (order.Country == "US")
            {
                bool invalid = false;
                foreach (OrderDetail orderDetail in order.OrderDetails)
                {
                    if( orderDetail.Length < 27 )
                    {
                        invalid = true;
                        break;
                    }
                }
            }
            return null;
        }

        private Dictionary<string, string> buildZoneMap()
        {
            Dictionary<string, string> zoneMap = new Dictionary<string, string>();

            StreamReader reader = new StreamReader("dhlzone.csv");
            String s = null;
            while ((s = reader.ReadLine()) != null)
            {
                String[] values = s.Split(',');
                string zipCodeString = values[0].Trim();
                string zoneString = values[1].Trim();
                if (zipCodeString.Contains("---"))
                {
                    int index = zipCodeString.IndexOf("---");
                    int startZipCode = Convert.ToInt32(zipCodeString.Substring(0, index).Trim());
                    int endZipCode = Convert.ToInt32(zipCodeString.Substring(index + 3));
                    for (int zipCode = startZipCode; zipCode <= endZipCode; zipCode++)
                    {
                        zoneMap[zipCode.ToString("D3")] = zoneString;
                    }
                }
                else
                {
                    zoneMap[zipCodeString] = zoneString;
                }
            }

            return zoneMap;
        }

        public Dictionary<double, double> buildSmallRateMap()
        {
            Dictionary<double, double> rateMap = new Dictionary<double, double>();

            StreamReader reader = new StreamReader("dhlgroundsmall.csv");
            String s = null;
            while ((s = reader.ReadLine()) != null)
            {
                String[] values = s.Split(',');
                rateMap[Convert.ToDouble(values[0].Trim())] = Convert.ToDouble(values[1].Trim());
            }

            return rateMap;
        }

        public Dictionary<double, double> buildSmallExpressRateMap()
        {
            Dictionary<double, double> rateMap = new Dictionary<double, double>();

            StreamReader reader = new StreamReader("dhlexpresssmall.csv");
            String s = null;
            while ((s = reader.ReadLine()) != null)
            {
                String[] values = s.Split(',');
                rateMap[Convert.ToDouble(values[0].Trim())] = Convert.ToDouble(values[1].Trim());
            }

            return rateMap;
        }

        public Dictionary<double, double[]> buildLargeRateMap()
        {
            Dictionary<double, double[]> rateMap = new Dictionary<double, double[]>();
            StreamReader reader = new StreamReader("dhlground.csv");
            String s = null;
            while ((s = reader.ReadLine()) != null)
            {
                String[] values = s.Split(',');
                double[] rates = new double[values.Length - 1];
                for (int i = 1; i < values.Length; i++)
                {
                    rates[i - 1] = Convert.ToDouble(values[i].Trim());
                }
                rateMap[Convert.ToDouble(values[0].Trim())] = rates;
            }

            return rateMap;
        }

        public Dictionary<double, double[]> buildLargeExpressRateMap()
        {
            Dictionary<double, double[]> rateMap = new Dictionary<double, double[]>();
            StreamReader reader = new StreamReader("dhlexpress.csv");
            String s = null;
            while ((s = reader.ReadLine()) != null)
            {
                String[] values = s.Split(',');
                double[] rates = new double[values.Length - 1];
                for (int i = 1; i < values.Length; i++)
                {
                    rates[i - 1] = Convert.ToDouble(values[i].Trim());
                }
                rateMap[Convert.ToDouble(values[0].Trim())] = rates;
            }

            return rateMap;
        }

        public Dictionary<double, double[]> buildExpressMaxRateMap()
        {
            Dictionary<double, double[]> rateMap = new Dictionary<double, double[]>();
            StreamReader reader = new StreamReader("dhlexpressmax.csv");
            String s = null;
            while ((s = reader.ReadLine()) != null)
            {
                String[] values = s.Split(',');
                double[] rates = new double[values.Length - 1];
                for (int i = 1; i < values.Length; i++)
                {
                    rates[i - 1] = Convert.ToDouble(values[i].Trim());
                }
                rateMap[Convert.ToDouble(values[0].Trim())] = rates;
            }

            return rateMap;
        }

    }
}
