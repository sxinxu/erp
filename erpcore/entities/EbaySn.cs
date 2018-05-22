using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbaySn
    {
        public int Id { get; set; }
        public string Sn { get; set; }
        public int Addtime { get; set; }
        public string User { get; set; }
    }
}
