using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayMessage
    {
        public int Id { get; set; }
        public string MessageId { get; set; }
        public string ExternalMessageId { get; set; }
        public string MessageType { get; set; }
        public string QuestionType { get; set; }
        public string Recipientid { get; set; }
        public string Sendmail { get; set; }
        public string Sendid { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Itemid { get; set; }
        public string Itemurl { get; set; }
        public string Starttime { get; set; }
        public string Endtime { get; set; }
        public string Currentprice { get; set; }
        public string Title { get; set; }
        public int? Status { get; set; }
        public string Createtime { get; set; }
        public string EbayUser { get; set; }
        public int? Classid { get; set; }
        public string EbayAccount { get; set; }
        public int AddTime { get; set; }
        public string Replaycontent { get; set; }
        public string Replyuser { get; set; }
        public int? Createtime1 { get; set; }
        public int? Mmarket { get; set; }
        public int? Ishide { get; set; }
        public int? Forms { get; set; }
        public int? Read { get; set; }
        public int? Isreply { get; set; }
        public string Replytime { get; set; }
        public string EbayAccount2 { get; set; }
    }
}
