using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayOrderpaypal
    {
        public int Id { get; set; }
        public string ExternalTransactionId { get; set; }
        public string ExternalTransactionTime { get; set; }
        public string CurrencyId { get; set; }
        public string FeeOrCreditAmount { get; set; }
        public string PaymentOrRefundAmount { get; set; }
        public string EbayOrdersn { get; set; }
    }
}
