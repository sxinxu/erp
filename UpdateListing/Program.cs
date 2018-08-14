using erpcore;
using System;

namespace UpdateListing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Start Updating amazon");
            bool refresh = false;
            if( args.Length == 1 && args[0].ToUpper() == "REFRESHLISTING")
            {
                refresh = true;
            }
            PlatformServiceFactory factory = new PlatformServiceFactory();
            factory.AddCompany("auto", "server=localhost;port=3306;user=root;password=EFDnpz8PeJ758VeN;database=v3-all", new int[] { 101, 108 });

            factory.GetOrderService("auto").UpdateAccountListingQuantities("gplusmotor2014@gmail.com", refresh);
            factory.GetOrderService("auto").UpdateAccountListingQuantities("amazonmotor@163.com", refresh);
            factory.GetOrderService("auto").UpdateAccountListingQuantities("Amazogplusperformance@outlook.com", refresh);
        }
    }
}
