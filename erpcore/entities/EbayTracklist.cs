using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayTracklist
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FeedbackScore { get; set; }
        public string PositiveFeedbackPercent { get; set; }
        public string TopRatedSeller { get; set; }
        public float? CurrentPrice { get; set; }
        public string ListingStatus { get; set; }
        public int? QuantitySold { get; set; }
        public string Site { get; set; }
        public string Title { get; set; }
        public string CurrencyId { get; set; }
        public string ItemId { get; set; }
        public string Trackid { get; set; }
        public string EbayUser { get; set; }
    }
}
