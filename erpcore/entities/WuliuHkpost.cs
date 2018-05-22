using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class WuliuHkpost
    {
        public string 物流公司 { get; set; }
        public string 通达国家 { get; set; }
        public int? 运费Kg { get; set; }
        public int? 挂号费票 { get; set; }
        public string 折扣 { get; set; }
        public string 备注 { get; set; }
    }
}
