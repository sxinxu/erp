using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayPandian
    {
        public uint Id { get; set; }
        public string PandianSn { get; set; }
        public int StoreId { get; set; }
        public sbyte Status { get; set; }
        public int AddTime { get; set; }
        public int ShTime { get; set; }
        public string EbayUser { get; set; }
        public string ShUser { get; set; }
        public string AddUser { get; set; }
        public string Notes { get; set; }
    }
}
