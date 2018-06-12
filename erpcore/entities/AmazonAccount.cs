using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class AmazonAccount
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string SellerId { get; set; }
        public string MWSAuthToken { get; set; }
    }
}
