using System;
using System.Collections.Generic;

namespace erpcore.entities
{
    public partial class EbayList
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public string Title { get; set; }
        public string Sku { get; set; }
        public string ListingType { get; set; }
        public string ListingDuration { get; set; }
        public string TimeLeft { get; set; }
        public string StartPrice { get; set; }
        public string GalleryType { get; set; }
        public string GalleryUrl { get; set; }
        public string Quantity { get; set; }
        public string Site { get; set; }
        public string BidCount { get; set; }
        public string HitCount { get; set; }
        public int? QuantitySold { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string Location { get; set; }
        public string BuyItNowPrice { get; set; }
        public string DispatchTimeMax { get; set; }
        public string ViewItemUrl { get; set; }
        public string PictureUrl01 { get; set; }
        public string PictureUrl02 { get; set; }
        public string PictureUrl03 { get; set; }
        public string PictureUrl04 { get; set; }
        public string ReservePrice { get; set; }
        public string EbayListingreturnmethodid { get; set; }
        public string EbayListingshippingmethodid { get; set; }
        public string Country { get; set; }
        public string ConditionId { get; set; }
        public string EbayAccount { get; set; }
        public string StoreCategoryId { get; set; }
        public string PayPalEmailAddress { get; set; }
        public string EbayUser { get; set; }
        public int? Status { get; set; }
        public string StartPricecurrencyId { get; set; }
        public int? QuantityAvailable { get; set; }
        public int? TrackPrice { get; set; }
        public int? TrackStock { get; set; }
        public float? Addprice { get; set; }
        public float? Hightprice { get; set; }
        public float? Jianprice { get; set; }
        public float? Lawprice { get; set; }
        public decimal Advprice { get; set; }
        public decimal PriceJc { get; set; }
        public bool? Active { get; set; }
    }
}
