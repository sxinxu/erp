using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore
{
    public class ConnectionStringSettings
    {
        public List<ConnectionStringSetting> Settings { get; set; }
    }

    public class ConnectionStringSetting
    {
        public String Company { get; set; }
        public String ConnectionString { get; set; }
    }
}
