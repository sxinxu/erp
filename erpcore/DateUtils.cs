using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore
{
    public class DateUtils
    {
        public static int ConvertToUnixTime(DateTime dateTime)
        {
            int t = 0;
            DateTime earliestTime = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
            try
            {
                t = Convert.ToInt32((dateTime - earliestTime).TotalSeconds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return t;
        }
    }
}
