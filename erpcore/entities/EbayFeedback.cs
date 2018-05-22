using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayFeedback
    {
        public int Id { get; set; }
        public string CommentingUser { get; set; }
        public string Account { get; set; }
        public string CommentingUserScore { get; set; }
        public string CommentText { get; set; }
        public string CommentTime { get; set; }
        public string CommentType { get; set; }
        public string ItemId { get; set; }
        public string FeedbackId { get; set; }
        public string TransactionId { get; set; }
        public string ItemTitle { get; set; }
        public string CurrencyId { get; set; }
        public string ItemPrice { get; set; }
        public string Status { get; set; }
        public int? Buyerstatus { get; set; }
        public int? Sellerstatus { get; set; }
        public int? Feedbacktime { get; set; }
        public string EbayUser { get; set; }
    }
}
