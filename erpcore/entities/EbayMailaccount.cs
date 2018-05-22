using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayMailaccount
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Pid { get; set; }
    }
}
