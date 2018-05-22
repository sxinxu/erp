using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class WuliuUps
    {
        public string 物流公司 { get; set; }
        public string 分区代码 { get; set; }
        public string 分区 { get; set; }
        public string 包含国家中 { get; set; }
        public string 包含国家英 { get; set; }
        public int? 起重G { get; set; }
        public decimal? 起重价 { get; set; }
        public decimal? 续重价 { get; set; }
        public int? 处理费1 { get; set; }
        public int? 处理费2 { get; set; }
        public decimal? 折扣 { get; set; }
        public string 备注 { get; set; }
    }
}
