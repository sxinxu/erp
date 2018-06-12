using System;
using System.Collections.Generic;
using System.Text;
using erpcore;
using Xunit;

namespace erpcoretests
{
    public class AmazonServiceTest
    {
        [Fact]
        public void TestGetInventory()
        {
            AmazonService service = new AmazonService("server=localhost;port=3306;user=root;password=EFDnpz8PeJ758VeN;database=v3-all");
            service.GetInventory("gplusmotor2014@gmail.com");
        }

        [Fact]
        public void TestUpdateInventory()
        {
            Dictionary<string, int> quantities = new Dictionary<string, int>();
            quantities["01SHC1004CBL"] = 11;
            AmazonService service = new AmazonService("server=localhost;port=3306;user=root;password=EFDnpz8PeJ758VeN;database=v3-all");
            service.UpdateInventory("gplusmotor2014@gmail.com", quantities);
        }
    }
}
