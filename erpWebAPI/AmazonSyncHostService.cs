using erpcore;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace erpWebAPI
{
    public class AmazonSyncHostService : IHostedService, IDisposable
    {
        private Timer m_timer;
        private static Logger m_logger = NLog.LogManager.GetCurrentClassLogger();
        private IPlatformServiceFactory m_platformServiceFactory;
        private DateTime? m_lastSyncTime;
        private int m_counter;
        
        public AmazonSyncHostService( IPlatformServiceFactory platformServiceFactory)
        {
            m_platformServiceFactory = platformServiceFactory;
        }

        void IDisposable.Dispose()
        {
            if( m_timer != null )
            {
                m_timer.Dispose();
                m_timer = null;
            }
        }

        Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            m_logger.Info("Start Amazon sync background service.");
            m_timer = new Timer(Sync, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));

            return Task.CompletedTask;
        }

        private void Sync(Object state)
        {
            DateTime createdBefore;
            DateTime createdAfter;
            if ( m_lastSyncTime != null && m_counter%50 != 0 )
            {
                createdAfter = m_lastSyncTime.GetValueOrDefault();
            }
            else
            {
                createdAfter = DateTime.Now.AddDays(-7);
            }
            createdBefore = DateTime.Now.AddMinutes(-2);
            m_logger.Info("Start to sync Amazon orders created after " + createdAfter.ToLongTimeString() + " and created before " + createdBefore.ToLongTimeString());
            List<string> companies = m_platformServiceFactory.GetCompanies();
            foreach(string company in companies)
            {
                IAmazonService amazonService = m_platformServiceFactory.GetAmazonService(company);
                IOrderService orderService = m_platformServiceFactory.GetOrderService(company);
                orderService.SyncOrders(amazonService.GetAccountNames(), createdAfter, createdBefore);
            }

            m_lastSyncTime = createdBefore;
            m_counter++;
        }

        Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            m_logger.Info("Stop Amazon sync background service.");
            if( m_timer != null )
            {
                m_timer.Change(Timeout.Infinite, 0);
            }
            return Task.CompletedTask;
        }
    }
}
