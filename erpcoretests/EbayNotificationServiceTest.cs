using System;
using Xunit;
using erpcore;
using System.IO;

namespace erpcoretests
{
    public class EbayNotificationServiceTest
    {
        [Fact]
        public void TestGetItemTransaction()
        {
            StreamReader reader = new StreamReader("TestData\\GetItemTransactions.xml");
            string contents = reader.ReadToEnd();
            reader.Close();
            EbayNotificationService service = new EbayNotificationService();

            service.Process(contents);
        }
    }
}
