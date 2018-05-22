using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayIostore
    {
        public int Id { get; set; }
        public string IoOrdersn { get; set; }
        public float? IoShipfee { get; set; }
        public string IoPurchaseorder { get; set; }
        public string IoUser { get; set; }
        public int IoAddtime { get; set; }
        public int? IoAudittime { get; set; }
        public string IoWarehouse { get; set; }
        public string IoStatus { get; set; }
        public string IoType { get; set; }
        public string IoNote { get; set; }
        public string IoPaymentmethod { get; set; }
        public float? IoPaidtotal { get; set; }
        public string IoPartner { get; set; }
        public string IoPurchaseuser { get; set; }
        public string Partner { get; set; }
        public string Type { get; set; }
        public string Operationuser { get; set; }
        public int? Paystatus { get; set; }
        public int? Stockstatus { get; set; }
        public string Audituser { get; set; }
        public int? Deliverytime { get; set; }
        public string EbayUser { get; set; }
        public int? Sourceorder { get; set; }
        public int? InWarehousefrom { get; set; }
        public int? InWarehouseto { get; set; }
        public string EbayAccount { get; set; }
        public string QcUser { get; set; }
        public string Reason { get; set; }
    }
}
