using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class Wuliu4pxLytpy
    {
        public string 物流公司 { get; set; }
        public int 分区代码 { get; set; }
        public string 区域名称 { get; set; }
        public string 包含国家中 { get; set; }
        public string 包含国家英 { get; set; }
        public decimal? 文件首100克 { get; set; }
        public decimal? 文件续100克 { get; set; }
        public int? 文件处理费 { get; set; }
        public decimal? 包裹首100克 { get; set; }
        public decimal? 包裹续100克 { get; set; }
        public int? 包裹处理费 { get; set; }
        public decimal 折扣 { get; set; }
        public string 备注 { get; set; }
    }
}
