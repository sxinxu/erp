using System;
using System.Collections.Generic;
using System.Text;

namespace erpcore.models
{
    public class OrderLog
    {
        public int Id { get; set; }

        public string Notes { get; set; }

        public string User { get; set; }

        public DateTime Time { get; set; }
    }
}
