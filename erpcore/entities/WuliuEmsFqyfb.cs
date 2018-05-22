using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class WuliuEmsFqyfb
    {
        public string 物流公司 { get; set; }
        public string 分区代码 { get; set; }
        public string 分区 { get; set; }
        public string 包含国家中 { get; set; }
        public string 包含国家英 { get; set; }
        public decimal? 起重500克文件 { get; set; }
        public int? 起重500克物品 { get; set; }
        public decimal? 续重500克 { get; set; }
        public decimal 报关费 { get; set; }
        public decimal? 折扣 { get; set; }
        public string 备注 { get; set; }
        public string User { get; set; }
        public int Id { get; set; }
    }
}
