using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore
{
    public class PlatformServiceFactory : IPlatformServiceFactory
    {
        private Dictionary<string, IEbayService> m_ebayServiceDictionary = new Dictionary<string, IEbayService>();
        private Dictionary<string, IAmazonService> m_amazonServiceDictionary = new Dictionary<string, IAmazonService>();
        private Dictionary<string, IOrderService> m_orderServiceDictionary = new Dictionary<string, IOrderService>();
        private Dictionary<string, IInventoryService> m_inventoryServiceDictionary = new Dictionary<string, IInventoryService>();
        private Dictionary<string, string> m_connectionStringDictionary = new Dictionary<string, string>();

        public string ContentRootPath {get;set;}

        public PlatformServiceFactory(IOptions<ConnectionStringSettings> options)
        {
            foreach(ConnectionStringSetting setting in options.Value.Settings)
            {
                m_connectionStringDictionary[setting.Company] = setting.ConnectionString;
            }
            //m_connectionStringDictionary["auto"] = "server=localhost;port=3306;user=root;password=EFDnpz8PeJ758VeN;database=auto";
            //m_connectionStringDictionary["boshen"] = "server=localhost;port=3306;user=root;password=EFDnpz8PeJ758VeN;database=cai";
        }

        public IEbayService GetEbayService(string company)
        {
            IEbayService service = null;
            if(m_ebayServiceDictionary.ContainsKey(company))
            {
                service = m_ebayServiceDictionary[company];
            }
            else if(m_connectionStringDictionary.ContainsKey(company))
            {
                service = new EbayService(m_connectionStringDictionary[company]);
                m_ebayServiceDictionary[company] = service;
            }

            return service;
        }


        public IAmazonService GetAmazonService(string company)
        {
            IAmazonService service = null;
            if (m_amazonServiceDictionary.ContainsKey(company))
            {
                service = m_amazonServiceDictionary[company];
            }
            else if (m_connectionStringDictionary.ContainsKey(company))
            {
                service = new AmazonService(m_connectionStringDictionary[company]);
                m_amazonServiceDictionary[company] = service;
            }

            return service;
        }

        public IOrderService GetOrderService(string company)
        {
            IOrderService service = null;
            if (m_orderServiceDictionary.ContainsKey(company))
            {
                service = m_orderServiceDictionary[company];
            }
            else if (m_connectionStringDictionary.ContainsKey(company))
            {
                service = new OrderService(this, company, m_connectionStringDictionary[company]);
                m_orderServiceDictionary[company] = service;
            }

            return service;
        }

        public IInventoryService GetInventoryService(string company)
        {
            IInventoryService service = null;
            if (m_inventoryServiceDictionary.ContainsKey(company))
            {
                service = m_inventoryServiceDictionary[company];
            }
            else if (m_connectionStringDictionary.ContainsKey(company))
            {
                service = new InventoryService(this, company, m_connectionStringDictionary[company]);
                m_inventoryServiceDictionary[company] = service;
            }

            return service;
        }
    }
}
