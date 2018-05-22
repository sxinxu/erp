using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayCurrency
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public string Rates { get; set; }
        public string User { get; set; }
    }
}
