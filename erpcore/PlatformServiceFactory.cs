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
        private Dictionary<string, int[]> m_storeIdsDictionary = new Dictionary<string, int[]>();

        public string ContentRootPath {get;set;}

        public PlatformServiceFactory(IOptions<ConnectionStringSettings> options)
        {
            foreach (ConnectionStringSetting setting in options.Value.Settings)
            {
                m_connectionStringDictionary[setting.Company] = setting.ConnectionString;
                m_storeIdsDictionary[setting.Company] = setting.StoreIds;
                IEbayService service = new EbayService(this, setting.Company, m_connectionStringDictionary[setting.Company], m_storeIdsDictionary[setting.Company]);
                m_ebayServiceDictionary[setting.Company] = service;
            }
        }

        public PlatformServiceFactory()
        {
        }

        public List<string> GetCompanies()
        {
            List<string> companies = new List<string>();
            companies.AddRange(m_connectionStringDictionary.Keys);
            return companies;
        }

        public void AddCompany(string company, string connectionString, int[] storeIds)
        {
            m_connectionStringDictionary[company] = connectionString;
            m_storeIdsDictionary[company] = storeIds;
        }

        public IEbayService GetEbayService(string company)
        {
            IEbayService service = null;
            if(m_ebayServiceDictionary.ContainsKey(company))
            {
                service = m_ebayServiceDictionary[company];
            }

            return service;
        }

        public IEbayService GetEbayServiceByAccount(string accountName)
        {
            IEbayService service = null;
            foreach( IEbayService ebayService in m_ebayServiceDictionary.Values)
            {
                if( ebayService.GetAccountNames().Contains(accountName))
                {
                    service = ebayService;
                    break;
                }
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
                service = new AmazonService(this, company, m_connectionStringDictionary[company]);
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
                service = new OrderService(this, company, m_connectionStringDictionary[company], m_storeIdsDictionary[company]);
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
