using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace erpcore.entities
{
    public partial class ERPContext : DbContext
    {
        public virtual DbSet<EbayAccount> EbayAccount { get; set; }
        public virtual DbSet<EbayBarcode> EbayBarcode { get; set; }
        public virtual DbSet<EbayCarrier> EbayCarrier { get; set; }
        public virtual DbSet<EbayCarrierfees> EbayCarrierfees { get; set; }
        public virtual DbSet<EbayCarrierweight> EbayCarrierweight { get; set; }
        public virtual DbSet<EbayConfig> EbayConfig { get; set; }
        public virtual DbSet<EbayCountryrule> EbayCountryrule { get; set; }
        public virtual DbSet<EbayCountrys> EbayCountrys { get; set; }
        public virtual DbSet<EbayCountrysdd> EbayCountrysdd { get; set; }
        public virtual DbSet<EbayCpghcalcfee> EbayCpghcalcfee { get; set; }
        public virtual DbSet<EbayCppycalcfee> EbayCppycalcfee { get; set; }
        public virtual DbSet<EbayCurrency> EbayCurrency { get; set; }
        public virtual DbSet<EbayEmscalcfee> EbayEmscalcfee { get; set; }
        public virtual DbSet<EbayFahuo> EbayFahuo { get; set; }
        public virtual DbSet<EbayFahuoprocess> EbayFahuoprocess { get; set; }
        public virtual DbSet<EbayFee> EbayFee { get; set; }
        public virtual DbSet<EbayFeedback> EbayFeedback { get; set; }
        public virtual DbSet<EbayGetlist> EbayGetlist { get; set; }
        public virtual DbSet<EbayGoods> EbayGoods { get; set; }
        public virtual DbSet<EbayGoodscategory> EbayGoodscategory { get; set; }
        public virtual DbSet<EbayGoodshistory> EbayGoodshistory { get; set; }
        public virtual DbSet<EbayGoodsNewplan> EbayGoodsNewplan { get; set; }
        public virtual DbSet<EbayGoodsOutstock> EbayGoodsOutstock { get; set; }
        public virtual DbSet<EbayGoodspic> EbayGoodspic { get; set; }
        public virtual DbSet<EbayGoodsrule> EbayGoodsrule { get; set; }
        public virtual DbSet<EbayGoodssort> EbayGoodssort { get; set; }
        public virtual DbSet<EbayGoodsstatus> EbayGoodsstatus { get; set; }
        public virtual DbSet<EbayHackpeoles> EbayHackpeoles { get; set; }
        public virtual DbSet<EbayHkpostcalcfee> EbayHkpostcalcfee { get; set; }
        public virtual DbSet<EbayHkpostghcalcfee> EbayHkpostghcalcfee { get; set; }
        public virtual DbSet<EbayIodetail> EbayIodetail { get; set; }
        public virtual DbSet<EbayIostore> EbayIostore { get; set; }
        public virtual DbSet<EbayIostoredetail> EbayIostoredetail { get; set; }
        public virtual DbSet<EbayIostorepay> EbayIostorepay { get; set; }
        public virtual DbSet<EbayLabeltotable> EbayLabeltotable { get; set; }
        public virtual DbSet<EbayLishicalcfee> EbayLishicalcfee { get; set; }
        public virtual DbSet<EbayList> EbayList { get; set; }
        public virtual DbSet<EbayListlog> EbayListlog { get; set; }
        public virtual DbSet<EbayListvariations> EbayListvariations { get; set; }
        public virtual DbSet<EbayListvarious> EbayListvarious { get; set; }
        public virtual DbSet<EbayLog> EbayLog { get; set; }
        public virtual DbSet<EbayMailaccount> EbayMailaccount { get; set; }
        public virtual DbSet<EbayMessage> EbayMessage { get; set; }
        public virtual DbSet<EbayMessagecategory> EbayMessagecategory { get; set; }
        public virtual DbSet<EbayMessagelog> EbayMessagelog { get; set; }
        public virtual DbSet<EbayMessagenote> EbayMessagenote { get; set; }
        public virtual DbSet<EbayMessagetemplate> EbayMessagetemplate { get; set; }
        public virtual DbSet<EbayOnhandle> EbayOnhandle { get; set; }
        public virtual DbSet<EbayOnhandle1> EbayOnhandle1 { get; set; }
        public virtual DbSet<EbayOrder> EbayOrder { get; set; }
        public virtual DbSet<EbayOrderdetail> EbayOrderdetail { get; set; }
        public virtual DbSet<EbayOrdernote> EbayOrdernote { get; set; }
        public virtual DbSet<EbayOrderpaypal> EbayOrderpaypal { get; set; }
        public virtual DbSet<EbayOrderslog> EbayOrderslog { get; set; }
        public virtual DbSet<EbayOrdertype> EbayOrdertype { get; set; }
        public virtual DbSet<EbayPackingmaterial> EbayPackingmaterial { get; set; }
        public virtual DbSet<EbayPandian> EbayPandian { get; set; }
        public virtual DbSet<EbayParcel> EbayParcel { get; set; }
        public virtual DbSet<EbayPartner> EbayPartner { get; set; }
        public virtual DbSet<EbayPartnertype> EbayPartnertype { get; set; }
        public virtual DbSet<EbayPaypal> EbayPaypal { get; set; }
        public virtual DbSet<EbayPaypaldetail> EbayPaypaldetail { get; set; }
        public virtual DbSet<EbayPaypalview> EbayPaypalview { get; set; }
        public virtual DbSet<EbayProductscombine> EbayProductscombine { get; set; }
        public virtual DbSet<EbayRand> EbayRand { get; set; }
        public virtual DbSet<EbayRma> EbayRma { get; set; }
        public virtual DbSet<EbayRmaactions> EbayRmaactions { get; set; }
        public virtual DbSet<EbayRmatype> EbayRmatype { get; set; }
        public virtual DbSet<EbayScanning> EbayScanning { get; set; }
        public virtual DbSet<EbayShelve> EbayShelve { get; set; }
        public virtual DbSet<EbayShipfees> EbayShipfees { get; set; }
        public virtual DbSet<EbayShipmentbox> EbayShipmentbox { get; set; }
        public virtual DbSet<EbayShiporder> EbayShiporder { get; set; }
        public virtual DbSet<EbayShipping> EbayShipping { get; set; }
        public virtual DbSet<EbaySku> EbaySku { get; set; }
        public virtual DbSet<EbaySkucountrynote> EbaySkucountrynote { get; set; }
        public virtual DbSet<EbaySkulist> EbaySkulist { get; set; }
        public virtual DbSet<EbaySn> EbaySn { get; set; }
        public virtual DbSet<EbayStoragebox> EbayStoragebox { get; set; }
        public virtual DbSet<EbayStore> EbayStore { get; set; }
        public virtual DbSet<EbayStoretype> EbayStoretype { get; set; }
        public virtual DbSet<EbaySystemshipfee> EbaySystemshipfee { get; set; }
        public virtual DbSet<EbayTemplatecategory> EbayTemplatecategory { get; set; }
        public virtual DbSet<EbayTongji> EbayTongji { get; set; }
        public virtual DbSet<EbayTopmenu> EbayTopmenu { get; set; }
        public virtual DbSet<EbayTracklist> EbayTracklist { get; set; }
        public virtual DbSet<EbayUser> EbayUser { get; set; }
        public virtual DbSet<EbayZen> EbayZen { get; set; }
        public virtual DbSet<ErpProductsOp> ErpProductsOp { get; set; }
        public virtual DbSet<ErpProductsQs> ErpProductsQs { get; set; }
        public virtual DbSet<ErrorsAck> ErrorsAck { get; set; }
        public virtual DbSet<ErrorsAckmessage> ErrorsAckmessage { get; set; }
        public virtual DbSet<EubAccount> EubAccount { get; set; }
        public virtual DbSet<EubAccount1> EubAccount1 { get; set; }
        public virtual DbSet<PartnerSkuprice> PartnerSkuprice { get; set; }
        public virtual DbSet<Productprofitview> Productprofitview { get; set; }
        public virtual DbSet<ShipfeeCk1> ShipfeeCk1 { get; set; }
        public virtual DbSet<SystemLog> SystemLog { get; set; }
        public virtual DbSet<SystemLogmessage> SystemLogmessage { get; set; }
        public virtual DbSet<Uploadfilesrecord> Uploadfilesrecord { get; set; }
        public virtual DbSet<Wuliu4pxDhl> Wuliu4pxDhl { get; set; }
        public virtual DbSet<Wuliu4pxDhlcz> Wuliu4pxDhlcz { get; set; }
        public virtual DbSet<Wuliu4pxDhlczTemp> Wuliu4pxDhlczTemp { get; set; }
        public virtual DbSet<Wuliu4pxDhldh> Wuliu4pxDhldh { get; set; }
        public virtual DbSet<Wuliu4pxDhldhTemp> Wuliu4pxDhldhTemp { get; set; }
        public virtual DbSet<Wuliu4pxDhlTemp> Wuliu4pxDhlTemp { get; set; }
        public virtual DbSet<Wuliu4pxDirect> Wuliu4pxDirect { get; set; }
        public virtual DbSet<Wuliu4pxHkdhlyfb> Wuliu4pxHkdhlyfb { get; set; }
        public virtual DbSet<Wuliu4pxHkfedexie> Wuliu4pxHkfedexie { get; set; }
        public virtual DbSet<Wuliu4pxHkyzdb> Wuliu4pxHkyzdb { get; set; }
        public virtual DbSet<Wuliu4pxLytgh> Wuliu4pxLytgh { get; set; }
        public virtual DbSet<Wuliu4pxLytpy> Wuliu4pxLytpy { get; set; }
        public virtual DbSet<Wuliu4pxXjpxb> Wuliu4pxXjpxb { get; set; }
        public virtual DbSet<WuliuBeiyubao> WuliuBeiyubao { get; set; }
        public virtual DbSet<WuliuCk1Dnyzx> WuliuCk1Dnyzx { get; set; }
        public virtual DbSet<WuliuCk1Zdzx> WuliuCk1Zdzx { get; set; }
        public virtual DbSet<WuliuEmsFqyfb> WuliuEmsFqyfb { get; set; }
        public virtual DbSet<WuliuEubYfb> WuliuEubYfb { get; set; }
        public virtual DbSet<WuliuFedexieFqyfb> WuliuFedexieFqyfb { get; set; }
        public virtual DbSet<WuliuFedexipFqyfb> WuliuFedexipFqyfb { get; set; }
        public virtual DbSet<WuliuHkpost> WuliuHkpost { get; set; }
        public virtual DbSet<WuliuJiachenDubai> WuliuJiachenDubai { get; set; }
        public virtual DbSet<WuliuJiachenMalaysia> WuliuJiachenMalaysia { get; set; }
        public virtual DbSet<WuliuJiachenOumeiau> WuliuJiachenOumeiau { get; set; }
        public virtual DbSet<WuliuUps> WuliuUps { get; set; }
        public virtual DbSet<WuliuYfhFqb> WuliuYfhFqb { get; set; }
        public virtual DbSet<WuliuYyb> WuliuYyb { get; set; }
        public virtual DbSet<WuliuZyxbFqyfb> WuliuZyxbFqyfb { get; set; }
        public virtual DbSet<AmazonList> AmazonList { get; set; }
        public virtual DbSet<AmazonAccount> AmazonAccount { get; set; }

        // Unable to generate entity type for table 'ebay_goods2'. Please see the warning messages.
        // Unable to generate entity type for table 'ebay_pandiandetail'. Please see the warning messages.
        // Unable to generate entity type for table 'ebay_word'. Please see the warning messages.
        // Unable to generate entity type for table 'factorymould'. Please see the warning messages.
        // Unable to generate entity type for table 'product_encoding'. Please see the warning messages.
        // Unable to generate entity type for table 'turblister'. Please see the warning messages.
        // Unable to generate entity type for table 'wuliu_ck1_cnukkx'. Please see the warning messages.
        // Unable to generate entity type for table 'wuliu_ck1_zx'. Please see the warning messages.
        // Unable to generate entity type for table 'wuliu_fedexzy'. Please see the warning messages.
        // Unable to generate entity type for table 'wuliu_yfh_yfb'. Please see the warning messages.
        private readonly string connectionString;
        public ERPContext(string connectionString):base()
        {
            this.connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=EFDnpz8PeJ758VeN;database=v3-all");
                optionsBuilder.UseMySql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EbayAccount>(entity =>
            {
                entity.ToTable("ebay_account");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Appname)
                    .HasColumnName("appname")
                    .HasMaxLength(50);

                entity.Property(e => e.AwsAccessKeyId)
                    .HasColumnName("AWS_ACCESS_KEY_ID")
                    .HasMaxLength(255);

                entity.Property(e => e.AwsSecretAccessKey)
                    .HasColumnName("AWS_SECRET_ACCESS_KEY")
                    .HasMaxLength(255);

                entity.Property(e => e.Ck)
                    .HasColumnName("ck")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Desc1)
                    .IsRequired()
                    .HasColumnName("desc_1");

                entity.Property(e => e.Desc2)
                    .IsRequired()
                    .HasColumnName("desc_2");

                entity.Property(e => e.Desc3)
                    .IsRequired()
                    .HasColumnName("desc_3");

                entity.Property(e => e.Desc4)
                    .IsRequired()
                    .HasColumnName("desc_4");

                entity.Property(e => e.DescAdvs)
                    .HasColumnName("desc_advs")
                    .HasMaxLength(200);

                entity.Property(e => e.EbayAccount1)
                    .IsRequired()
                    .HasColumnName("ebay_account")
                    .HasMaxLength(50);

                entity.Property(e => e.EbayAddtime)
                    .HasColumnName("ebay_addtime")
                    .HasMaxLength(60);

                entity.Property(e => e.EbayExpirtime)
                    .HasColumnName("ebay_expirtime")
                    .HasMaxLength(60);

                entity.Property(e => e.EbayToken)
                    .HasColumnName("ebay_token")
                    .HasColumnType("text");

                entity.Property(e => e.EbayToken2)
                    .HasColumnName("ebay_token2")
                    .HasColumnType("text");

                entity.Property(e => e.EbayToken3)
                    .HasColumnName("ebay_token3")
                    .HasColumnType("text");

                entity.Property(e => e.EbayToken4)
                    .HasColumnName("ebay_token4")
                    .HasColumnType("text");

                entity.Property(e => e.EbayToken5)
                    .HasColumnName("ebay_token5")
                    .HasColumnType("text");

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(60);

                entity.Property(e => e.ImgAccount)
                    .IsRequired()
                    .HasColumnName("img_account")
                    .HasMaxLength(20);

                entity.Property(e => e.ImgStore)
                    .IsRequired()
                    .HasColumnName("img_store")
                    .HasMaxLength(5);

                entity.Property(e => e.LastSyncTime)
                    .HasColumnName("lastSyncTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(50);

                entity.Property(e => e.MarketplaceId)
                    .HasColumnName("MARKETPLACE_ID")
                    .HasMaxLength(255);

                entity.Property(e => e.MerchantId)
                    .HasColumnName("MERCHANT_ID")
                    .HasMaxLength(255);

                entity.Property(e => e.ServiceUrl)
                    .HasColumnName("serviceUrl")
                    .HasMaxLength(255);

                entity.Property(e => e.Site)
                    .IsRequired()
                    .HasColumnName("site")
                    .HasMaxLength(60);

                entity.Property(e => e.Storeid)
                    .HasColumnName("storeid")
                    .HasMaxLength(23);

                entity.Property(e => e.Template)
                    .HasColumnName("template")
                    .HasColumnType("varchar(10240)");
            });

            modelBuilder.Entity<EbayBarcode>(entity =>
            {
                entity.HasKey(e => e.BId);

                entity.ToTable("ebay_barcode");

                entity.Property(e => e.BId)
                    .HasColumnName("b_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(64);

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Exist)
                    .HasColumnName("exist")
                    .HasColumnType("tinyint(1)");
            });

            modelBuilder.Entity<EbayCarrier>(entity =>
            {
                entity.ToTable("ebay_carrier");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255);

                entity.Property(e => e.Backtype)
                    .HasColumnName("backtype")
                    .HasMaxLength(2);

                entity.Property(e => e.CarrierSn)
                    .HasColumnName("carrier_sn")
                    .HasMaxLength(255);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(255);

                entity.Property(e => e.ConfigLable)
                    .HasColumnName("config_lable")
                    .HasColumnType("text");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(255);

                entity.Property(e => e.Default01)
                    .HasColumnName("default01")
                    .HasMaxLength(255);

                entity.Property(e => e.Default02)
                    .HasColumnName("default02")
                    .HasMaxLength(255);

                entity.Property(e => e.Default03)
                    .HasColumnName("default03")
                    .HasMaxLength(255);

                entity.Property(e => e.Default04)
                    .HasColumnName("default04")
                    .HasMaxLength(255);

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EbayAccount)
                    .HasColumnName("ebay_account")
                    .HasColumnType("text");

                entity.Property(e => e.EbayCountry)
                    .HasColumnName("ebay_country")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayWarehouse)
                    .HasColumnName("ebay_warehouse")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Encounts)
                    .HasColumnName("encounts")
                    .HasColumnType("text");

                entity.Property(e => e.Firstweight)
                    .HasColumnName("firstweight")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FromEbaycarrier)
                    .HasColumnName("from_ebaycarrier")
                    .HasColumnType("text");

                entity.Property(e => e.Handlefee)
                    .HasColumnName("handlefee")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Kg)
                    .HasColumnName("kg")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Max)
                    .HasColumnName("max")
                    .HasMaxLength(255);

                entity.Property(e => e.Min)
                    .HasColumnName("min")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(255);

                entity.Property(e => e.Orderstatus)
                    .HasColumnName("orderstatus")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PrintBg)
                    .HasColumnName("print_bg")
                    .HasMaxLength(255);

                entity.Property(e => e.Priority).HasColumnType("int(11)");

                entity.Property(e => e.Province)
                    .HasColumnName("province")
                    .HasMaxLength(255);

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Safetype)
                    .HasColumnName("safetype")
                    .HasMaxLength(2);

                entity.Property(e => e.Signature)
                    .HasColumnName("signature")
                    .HasMaxLength(255);

                entity.Property(e => e.Skus)
                    .HasColumnName("skus")
                    .HasColumnType("text");

                entity.Property(e => e.StampPic)
                    .HasColumnName("stamp_pic")
                    .HasMaxLength(40);

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(255);

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasMaxLength(255);

                entity.Property(e => e.Teshu)
                    .HasColumnName("teshu")
                    .HasMaxLength(255);

                entity.Property(e => e.Tjcarrier)
                    .HasColumnName("tjcarrier")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Tjcountry)
                    .HasColumnName("tjcountry")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Tjsku)
                    .HasColumnName("tjsku")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Track)
                    .IsRequired()
                    .HasColumnName("track")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(255);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(255);

                entity.Property(e => e.WeighebayCountry)
                    .HasColumnName("weighebay_country")
                    .HasMaxLength(255);

                entity.Property(e => e.Weightmax).HasColumnName("weightmax");

                entity.Property(e => e.Weightmin).HasColumnName("weightmin");
            });

            modelBuilder.Entity<EbayCarrierfees>(entity =>
            {
                entity.ToTable("ebay_carrierfees");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Carrierid)
                    .HasColumnName("carrierid")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Priceend)
                    .IsRequired()
                    .HasColumnName("priceend")
                    .HasMaxLength(255);

                entity.Property(e => e.Pricestart)
                    .HasColumnName("pricestart")
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayCarrierweight>(entity =>
            {
                entity.ToTable("ebay_carrierweight");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Max).HasColumnName("max");

                entity.Property(e => e.Min).HasColumnName("min");

                entity.Property(e => e.ShippingId)
                    .HasColumnName("shipping_id")
                    .HasMaxLength(30);

                entity.Property(e => e.Totalweight).HasColumnName("totalweight");

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<EbayConfig>(entity =>
            {
                entity.ToTable("ebay_config");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Allowauditorderstatus)
                    .HasColumnName("allowauditorderstatus")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Auditcompleteorderstatus)
                    .HasColumnName("auditcompleteorderstatus")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Days15).HasColumnName("days15");

                entity.Property(e => e.Days30).HasColumnName("days30");

                entity.Property(e => e.Days7).HasColumnName("days7");

                entity.Property(e => e.Distrubitestock)
                    .HasColumnName("distrubitestock")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(30);

                entity.Property(e => e.Feedbackstring)
                    .HasColumnName("feedbackstring")
                    .HasColumnType("text");

                entity.Property(e => e.Hackorer)
                    .HasColumnName("hackorer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Notesorderstatus)
                    .HasColumnName("notesorderstatus")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Onstock)
                    .HasColumnName("onstock")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Overtock)
                    .HasColumnName("overtock")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Overweightstatus)
                    .HasColumnName("overweightstatus")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Paypalstatus)
                    .HasColumnName("paypalstatus")
                    .HasMaxLength(12);

                entity.Property(e => e.Scaningorderstatus)
                    .HasColumnName("scaningorderstatus")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Storeid)
                    .HasColumnName("storeid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Systemprofit)
                    .HasColumnName("systemprofit")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Token4px)
                    .HasColumnName("token4px")
                    .HasMaxLength(50);

                entity.Property(e => e.Totalprofitstatus)
                    .HasColumnName("totalprofitstatus")
                    .HasMaxLength(11);

                entity.Property(e => e.Ywpassword)
                    .HasColumnName("ywpassword")
                    .HasMaxLength(30);

                entity.Property(e => e.Ywuserid)
                    .HasColumnName("ywuserid")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<EbayCountryrule>(entity =>
            {
                entity.ToTable("ebay_countryrule");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(255);

                entity.Property(e => e.Value2)
                    .HasColumnName("value2")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayCountrys>(entity =>
            {
                entity.ToTable("ebay_countrys");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Countrycn)
                    .HasColumnName("countrycn")
                    .HasMaxLength(30);

                entity.Property(e => e.Countryen)
                    .HasColumnName("countryen")
                    .HasMaxLength(28);

                entity.Property(e => e.Countrysn)
                    .HasColumnName("countrysn")
                    .HasMaxLength(6);

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<EbayCountrysdd>(entity =>
            {
                entity.ToTable("ebay_countrysdd");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Countrycn)
                    .IsRequired()
                    .HasColumnName("countrycn")
                    .HasMaxLength(30);

                entity.Property(e => e.Countryen)
                    .IsRequired()
                    .HasColumnName("countryen")
                    .HasMaxLength(30);

                entity.Property(e => e.Countrysn)
                    .IsRequired()
                    .HasColumnName("countrysn")
                    .HasMaxLength(30);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<EbayCpghcalcfee>(entity =>
            {
                entity.ToTable("ebay_cpghcalcfee");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Countrys)
                    .HasColumnName("countrys")
                    .HasColumnType("text");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasMaxLength(30);

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(30);

                entity.Property(e => e.Firstweight)
                    .HasColumnName("firstweight")
                    .HasMaxLength(30);

                entity.Property(e => e.Handlefee).HasColumnName("handlefee");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Nextweight).HasColumnName("nextweight");

                entity.Property(e => e.Xx0)
                    .HasColumnName("xx0")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Xx1)
                    .HasColumnName("xx1")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<EbayCppycalcfee>(entity =>
            {
                entity.ToTable("ebay_cppycalcfee");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Countrys)
                    .HasColumnName("countrys")
                    .HasColumnType("text");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasMaxLength(30);

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(30);

                entity.Property(e => e.Firstweight)
                    .HasColumnName("firstweight")
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Nextweight).HasColumnName("nextweight");

                entity.Property(e => e.Xx0)
                    .HasColumnName("xx0")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Xx1)
                    .HasColumnName("xx1")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<EbayCurrency>(entity =>
            {
                entity.ToTable("ebay_currency");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasColumnName("currency")
                    .HasMaxLength(114);

                entity.Property(e => e.Rates)
                    .HasColumnName("rates")
                    .HasMaxLength(77)
                    .HasDefaultValueSql("'0.000'");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasColumnName("user")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayEmscalcfee>(entity =>
            {
                entity.ToTable("ebay_emscalcfee");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Countrys)
                    .HasColumnName("countrys")
                    .HasColumnType("text");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasMaxLength(30);

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(30);

                entity.Property(e => e.Files)
                    .HasColumnName("files")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Firstweight)
                    .HasColumnName("firstweight")
                    .HasMaxLength(30);

                entity.Property(e => e.Firstweight0).HasColumnName("firstweight0");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Nextweight)
                    .HasColumnName("nextweight")
                    .HasColumnType("int(30)");
            });

            modelBuilder.Entity<EbayFahuo>(entity =>
            {
                entity.ToTable("ebay_fahuo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayFahuoprocess>(entity =>
            {
                entity.ToTable("ebay_fahuoprocess");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Corder)
                    .HasColumnName("corder")
                    .HasMaxLength(255);

                entity.Property(e => e.Days)
                    .HasColumnName("days")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Pid)
                    .IsRequired()
                    .HasColumnName("pid")
                    .HasMaxLength(25);

                entity.Property(e => e.Template)
                    .HasColumnName("template")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayFee>(entity =>
            {
                entity.ToTable("ebay_fee");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Account)
                    .HasColumnName("account")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayProductsSn)
                    .HasColumnName("ebay_products_sn")
                    .HasMaxLength(255);

                entity.Property(e => e.Feeamount)
                    .HasColumnName("feeamount")
                    .HasMaxLength(255);

                entity.Property(e => e.Feedate)
                    .HasColumnName("feedate")
                    .HasMaxLength(255);

                entity.Property(e => e.Feeddate1)
                    .HasColumnName("feeddate1")
                    .HasColumnType("int(50)");

                entity.Property(e => e.Feetdescription)
                    .HasColumnName("feetdescription")
                    .HasMaxLength(255);

                entity.Property(e => e.Feetype)
                    .HasColumnName("feetype")
                    .HasMaxLength(255);

                entity.Property(e => e.Itemid)
                    .HasColumnName("itemid")
                    .HasMaxLength(255);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.Property(e => e.User)
                    .HasColumnName("user")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayFeedback>(entity =>
            {
                entity.ToTable("ebay_feedback");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasColumnName("account")
                    .HasMaxLength(255);

                entity.Property(e => e.Buyerstatus)
                    .HasColumnName("buyerstatus")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CommentText).HasColumnType("text");

                entity.Property(e => e.CommentTime).HasMaxLength(255);

                entity.Property(e => e.CommentType).HasMaxLength(255);

                entity.Property(e => e.CommentingUser).HasMaxLength(255);

                entity.Property(e => e.CommentingUserScore).HasMaxLength(255);

                entity.Property(e => e.CurrencyId)
                    .HasColumnName("currencyID")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.FeedbackId)
                    .HasColumnName("FeedbackID")
                    .HasMaxLength(255);

                entity.Property(e => e.Feedbacktime)
                    .HasColumnName("feedbacktime")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ItemId)
                    .HasColumnName("ItemID")
                    .HasMaxLength(255);

                entity.Property(e => e.ItemPrice).HasMaxLength(255);

                entity.Property(e => e.ItemTitle).HasMaxLength(255);

                entity.Property(e => e.Sellerstatus)
                    .HasColumnName("sellerstatus")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(20);

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayGetlist>(entity =>
            {
                entity.ToTable("ebay_getlist");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayGoods>(entity =>
            {
                entity.HasKey(e => e.GoodsId);

                entity.ToTable("ebay_goods");

                entity.HasIndex(e => e.EbayUser)
                    .HasName("ebay_user");

                entity.HasIndex(e => e.GoodsSn)
                    .HasName("goods_sn");

                entity.HasIndex(e => new { e.GoodsSn, e.EbayUser })
                    .HasName("goods_sn_2");

                entity.Property(e => e.GoodsId)
                    .HasColumnName("goods_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addtim)
                    .HasColumnName("addtim")
                    .HasMaxLength(60);

                entity.Property(e => e.Application)
                    .HasColumnName("application")
                    .HasMaxLength(255);

                entity.Property(e => e.BtoBnumber).HasMaxLength(60);

                entity.Property(e => e.Bzuser)
                    .HasColumnName("bzuser")
                    .HasMaxLength(60);

                entity.Property(e => e.Capacity)
                    .HasColumnName("capacity")
                    .HasMaxLength(30);

                entity.Property(e => e.Carrier)
                    .HasColumnName("carrier")
                    .HasMaxLength(255);

                entity.Property(e => e.Cguser)
                    .HasColumnName("cguser")
                    .HasMaxLength(90);

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasMaxLength(255);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(10240)");

                entity.Property(e => e.EbayPackingmaterial)
                    .HasColumnName("ebay_packingmaterial")
                    .HasMaxLength(30);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(15);

                entity.Property(e => e.Factory)
                    .HasColumnName("factory")
                    .HasMaxLength(255);

                entity.Property(e => e.Factory2)
                    .HasColumnName("factory2")
                    .HasMaxLength(255);

                entity.Property(e => e.Factory3)
                    .HasColumnName("factory3")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsAribute)
                    .HasColumnName("goods_aribute")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GoodsAttribute)
                    .HasColumnName("goods_attribute")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsCategory)
                    .HasColumnName("goods_category")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsCost)
                    .HasColumnName("goods_cost")
                    .HasColumnType("decimal(10,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.GoodsCount)
                    .HasColumnName("goods_count")
                    .HasColumnType("int(20)");

                entity.Property(e => e.GoodsHeight)
                    .HasColumnName("goods_height")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GoodsHgbm)
                    .HasColumnName("goods_hgbm")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsLength)
                    .HasColumnName("goods_length")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GoodsLocation)
                    .HasColumnName("goods_location")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsName)
                    .HasColumnName("goods_name")
                    .HasMaxLength(355);

                entity.Property(e => e.GoodsName2)
                    .HasColumnName("goods_name2")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsNote)
                    .HasColumnName("goods_note")
                    .HasColumnType("text");

                entity.Property(e => e.GoodsPic)
                    .HasColumnName("goods_pic")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsPrice)
                    .HasColumnName("goods_price")
                    .HasMaxLength(20);

                entity.Property(e => e.GoodsRegister)
                    .HasColumnName("goods_register")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsSbjz)
                    .HasColumnName("goods_sbjz")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsSn)
                    .HasColumnName("goods_sn")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsStatus)
                    .HasColumnName("goods_status")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GoodsUnit)
                    .HasColumnName("goods_unit")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsWeight)
                    .HasColumnName("goods_weight")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsWeight2).HasColumnName("goods_weight2");

                entity.Property(e => e.GoodsWeight3)
                    .HasColumnName("goods_weight3")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsWidth)
                    .HasColumnName("goods_width")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GoodsYwsbmc)
                    .HasColumnName("goods_ywsbmc")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsZysbmc)
                    .HasColumnName("goods_zysbmc")
                    .HasMaxLength(255);

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Ispacking)
                    .HasColumnName("ispacking")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Isuse)
                    .HasColumnName("isuse")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Kfuser)
                    .HasColumnName("kfuser")
                    .HasMaxLength(60);

                entity.Property(e => e.Materil)
                    .HasColumnName("materil")
                    .HasMaxLength(255);

                entity.Property(e => e.PgoodsSn)
                    .HasColumnName("pgoods_sn")
                    .HasMaxLength(255);

                entity.Property(e => e.PriceJc)
                    .HasColumnName("priceJC")
                    .HasColumnType("decimal(10,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Salesuser)
                    .HasColumnName("salesuser")
                    .HasMaxLength(90);

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasMaxLength(255);

                entity.Property(e => e.Storeid)
                    .HasColumnName("storeid")
                    .HasMaxLength(255);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.Property(e => e.Warehousesx)
                    .HasColumnName("warehousesx")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Warehousexx)
                    .HasColumnName("warehousexx")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<EbayGoodscategory>(entity =>
            {
                entity.ToTable("ebay_goodscategory");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(25);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<EbayGoodshistory>(entity =>
            {
                entity.ToTable("ebay_goodshistory");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addtime)
                    .IsRequired()
                    .HasColumnName("addtime")
                    .HasMaxLength(60);

                entity.Property(e => e.EbayAccount)
                    .HasColumnName("ebay_account")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayCurrency)
                    .HasColumnName("ebay_currency")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(210);

                entity.Property(e => e.GoodsCategory)
                    .HasColumnName("goods_category")
                    .HasMaxLength(255);

                entity.Property(e => e.Goodsid)
                    .IsRequired()
                    .HasColumnName("goodsid")
                    .HasMaxLength(60);

                entity.Property(e => e.Goodsn)
                    .HasColumnName("goodsn")
                    .HasMaxLength(200);

                entity.Property(e => e.Goodsname)
                    .HasColumnName("goodsname")
                    .HasMaxLength(200);

                entity.Property(e => e.Goodsnumber)
                    .IsRequired()
                    .HasColumnName("goodsnumber")
                    .HasMaxLength(20);

                entity.Property(e => e.Goodsprice)
                    .IsRequired()
                    .HasColumnName("goodsprice")
                    .HasMaxLength(60);

                entity.Property(e => e.Sourceorder)
                    .HasColumnName("sourceorder")
                    .HasMaxLength(255);

                entity.Property(e => e.Stocktype)
                    .IsRequired()
                    .HasColumnName("stocktype")
                    .HasMaxLength(60);

                entity.Property(e => e.StoreId)
                    .HasColumnName("store_id")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayGoodsNewplan>(entity =>
            {
                entity.ToTable("ebay_goods_newplan");

                entity.HasIndex(e => e.EbayUser)
                    .HasName("ebay_user");

                entity.HasIndex(e => e.Sku)
                    .HasName("sku");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cguser)
                    .HasColumnName("cguser")
                    .HasMaxLength(50);

                entity.Property(e => e.EbayId)
                    .HasColumnName("ebay_id")
                    .HasMaxLength(30);

                entity.Property(e => e.EbayOrderinfoId)
                    .HasColumnName("ebay_orderinfo_id")
                    .HasMaxLength(30);

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(100);

                entity.Property(e => e.EbayWarehouse)
                    .HasColumnName("ebay_warehouse")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GoodsCount)
                    .HasColumnName("goods_count")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GoodsName)
                    .HasColumnName("goods_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Kfuser)
                    .HasColumnName("kfuser")
                    .HasMaxLength(50);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(255);

                entity.Property(e => e.Partner)
                    .HasColumnName("partner")
                    .HasMaxLength(30);

                entity.Property(e => e.Purchaseprice)
                    .HasColumnName("purchaseprice")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Unit)
                    .HasColumnName("unit")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<EbayGoodsOutstock>(entity =>
            {
                entity.ToTable("ebay_goods_outstock");

                entity.HasIndex(e => new { e.EbayId, e.EbayOrderinfoId })
                    .HasName("ebay_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cguser)
                    .HasColumnName("cguser")
                    .HasMaxLength(50);

                entity.Property(e => e.EbayId)
                    .HasColumnName("ebay_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayOrderinfoId)
                    .HasColumnName("ebay_orderinfo_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayWarehouse)
                    .HasColumnName("ebay_warehouse")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GoodsCount)
                    .HasColumnName("goods_count")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GoodsId)
                    .HasColumnName("goods_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GoodsName)
                    .HasColumnName("goods_name")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsNote)
                    .HasColumnName("goods_note")
                    .HasMaxLength(255);

                entity.Property(e => e.Kfuser)
                    .IsRequired()
                    .HasColumnName("kfuser")
                    .HasMaxLength(50);

                entity.Property(e => e.LastPurchaseprice)
                    .HasColumnName("last_purchaseprice")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("sku")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<EbayGoodspic>(entity =>
            {
                entity.ToTable("ebay_goodspic");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(20);

                entity.Property(e => e.GoodsId)
                    .HasColumnName("goods_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Picurl)
                    .IsRequired()
                    .HasColumnName("picurl")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EbayGoodsrule>(entity =>
            {
                entity.ToTable("ebay_goodsrule");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(255);

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasMaxLength(255);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayGoodssort>(entity =>
            {
                entity.ToTable("ebay_goodssort");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsCost)
                    .HasColumnName("goods_cost")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsName)
                    .HasColumnName("goods_name")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsSn)
                    .HasColumnName("goods_sn")
                    .HasMaxLength(255);

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Totalprice).HasColumnName("totalprice");

                entity.Property(e => e.Totalprofit).HasColumnName("totalprofit");
            });

            modelBuilder.Entity<EbayGoodsstatus>(entity =>
            {
                entity.ToTable("ebay_goodsstatus");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3)");

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(30);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<EbayHackpeoles>(entity =>
            {
                entity.ToTable("ebay_hackpeoles");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addtim)
                    .IsRequired()
                    .HasColumnName("addtim")
                    .HasMaxLength(40);

                entity.Property(e => e.Adduser)
                    .IsRequired()
                    .HasColumnName("adduser")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayCity)
                    .HasColumnName("ebay_city")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayCountryname)
                    .HasColumnName("ebay_countryname")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayPhone)
                    .HasColumnName("ebay_phone")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayPostcode)
                    .HasColumnName("ebay_postcode")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayState)
                    .HasColumnName("ebay_state")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayStreet)
                    .HasColumnName("ebay_street")
                    .HasMaxLength(60);

                entity.Property(e => e.EbayStreet1)
                    .HasColumnName("ebay_street1")
                    .HasMaxLength(60);

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayUsername)
                    .HasColumnName("ebay_username")
                    .HasMaxLength(40);

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(60);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.PaypalAccount)
                    .HasColumnName("paypal_account")
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<EbayHkpostcalcfee>(entity =>
            {
                entity.ToTable("ebay_hkpostcalcfee");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Countrys)
                    .HasColumnName("countrys")
                    .HasColumnType("text");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasMaxLength(30);

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(30);

                entity.Property(e => e.Firstweight)
                    .HasColumnName("firstweight")
                    .HasMaxLength(30);

                entity.Property(e => e.Handlefee).HasColumnName("handlefee");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Nextweight).HasColumnName("nextweight");

                entity.Property(e => e.Xx0)
                    .HasColumnName("xx0")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Xx1)
                    .HasColumnName("xx1")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<EbayHkpostghcalcfee>(entity =>
            {
                entity.ToTable("ebay_hkpostghcalcfee");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Countrys)
                    .HasColumnName("countrys")
                    .HasColumnType("text");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasMaxLength(30);

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(30);

                entity.Property(e => e.Firstweight)
                    .HasColumnName("firstweight")
                    .HasMaxLength(30);

                entity.Property(e => e.Handlefee).HasColumnName("handlefee");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Nextweight).HasColumnName("nextweight");

                entity.Property(e => e.Xx0)
                    .HasColumnName("xx0")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Xx1)
                    .HasColumnName("xx1")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<EbayIodetail>(entity =>
            {
                entity.ToTable("ebay_iodetail");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addtime)
                    .HasColumnName("addtime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(30);

                entity.Property(e => e.Ioid)
                    .HasColumnName("ioid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<EbayIostore>(entity =>
            {
                entity.ToTable("ebay_iostore");

                entity.HasIndex(e => e.EbayUser)
                    .HasName("ebay_user");

                entity.HasIndex(e => e.IoOrdersn)
                    .HasName("io_ordersn");

                entity.HasIndex(e => e.IoStatus)
                    .HasName("io_status");

                entity.HasIndex(e => e.Type)
                    .HasName("type_2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Audituser)
                    .HasColumnName("audituser")
                    .HasMaxLength(30);

                entity.Property(e => e.Deliverytime)
                    .HasColumnName("deliverytime")
                    .HasColumnType("int(40)");

                entity.Property(e => e.EbayAccount)
                    .HasColumnName("ebay_account")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(30);

                entity.Property(e => e.InWarehousefrom)
                    .HasColumnName("in_warehousefrom")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InWarehouseto)
                    .HasColumnName("in_warehouseto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IoAddtime)
                    .HasColumnName("io_addtime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IoAudittime)
                    .HasColumnName("io_audittime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IoNote)
                    .HasColumnName("io_note")
                    .HasColumnType("text");

                entity.Property(e => e.IoOrdersn)
                    .HasColumnName("io_ordersn")
                    .HasMaxLength(30);

                entity.Property(e => e.IoPaidtotal)
                    .HasColumnName("io_paidtotal")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IoPartner)
                    .HasColumnName("io_partner")
                    .HasMaxLength(40);

                entity.Property(e => e.IoPaymentmethod)
                    .HasColumnName("io_paymentmethod")
                    .HasMaxLength(60);

                entity.Property(e => e.IoPurchaseorder)
                    .HasColumnName("io_purchaseorder")
                    .HasMaxLength(30);

                entity.Property(e => e.IoPurchaseuser)
                    .HasColumnName("io_purchaseuser")
                    .HasMaxLength(40);

                entity.Property(e => e.IoShipfee)
                    .HasColumnName("io_shipfee")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IoStatus)
                    .IsRequired()
                    .HasColumnName("io_status")
                    .HasMaxLength(10);

                entity.Property(e => e.IoType)
                    .IsRequired()
                    .HasColumnName("io_type")
                    .HasMaxLength(20);

                entity.Property(e => e.IoUser)
                    .IsRequired()
                    .HasColumnName("io_user")
                    .HasMaxLength(30);

                entity.Property(e => e.IoWarehouse)
                    .IsRequired()
                    .HasColumnName("io_warehouse")
                    .HasMaxLength(20);

                entity.Property(e => e.Operationuser)
                    .HasColumnName("operationuser")
                    .HasMaxLength(30);

                entity.Property(e => e.Partner)
                    .HasColumnName("partner")
                    .HasMaxLength(40);

                entity.Property(e => e.Paystatus)
                    .HasColumnName("paystatus")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.QcUser)
                    .HasColumnName("qc_user")
                    .HasMaxLength(50);

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasMaxLength(255);

                entity.Property(e => e.Sourceorder)
                    .HasColumnName("sourceorder")
                    .HasColumnType("int(40)");

                entity.Property(e => e.Stockstatus)
                    .HasColumnName("stockstatus")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(12);
            });

            modelBuilder.Entity<EbayIostoredetail>(entity =>
            {
                entity.ToTable("ebay_iostoredetail");

                entity.HasIndex(e => e.GoodsCost)
                    .HasName("goods_cost");

                entity.HasIndex(e => e.GoodsSn)
                    .HasName("goods_sn");

                entity.HasIndex(e => e.IoOrdersn)
                    .HasName("io_ordersn");

                entity.HasIndex(e => e.Status)
                    .HasName("status");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayShipfee)
                    .HasColumnName("ebay_shipfee")
                    .HasMaxLength(10);

                entity.Property(e => e.GoodsCost).HasColumnName("goods_cost");

                entity.Property(e => e.GoodsCount)
                    .HasColumnName("goods_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GoodsCount0)
                    .HasColumnName("goods_count0")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GoodsCount1)
                    .HasColumnName("goods_count1")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GoodsCount2)
                    .HasColumnName("goods_count2")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GoodsId)
                    .HasColumnName("goods_id")
                    .HasMaxLength(40);

                entity.Property(e => e.GoodsName)
                    .HasColumnName("goods_name")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsPrice)
                    .HasColumnName("goods_price")
                    .HasMaxLength(40);

                entity.Property(e => e.GoodsSn)
                    .HasColumnName("goods_sn")
                    .HasMaxLength(40);

                entity.Property(e => e.GoodsUnit)
                    .HasColumnName("goods_unit")
                    .HasMaxLength(40);

                entity.Property(e => e.IoOrdersn)
                    .HasColumnName("io_ordersn")
                    .HasMaxLength(30);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(255);

                entity.Property(e => e.Partnerprice)
                    .HasColumnName("partnerprice")
                    .HasMaxLength(40);

                entity.Property(e => e.Partnersn)
                    .HasColumnName("partnersn")
                    .HasMaxLength(40);

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Qty01)
                    .HasColumnName("qty_01")
                    .HasColumnType("int(40)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Qty02)
                    .HasColumnName("qty_02")
                    .HasMaxLength(40);

                entity.Property(e => e.Qty03)
                    .HasColumnName("qty_03")
                    .HasMaxLength(40);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Stockqty)
                    .HasColumnName("stockqty")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Transactioncurrncy)
                    .HasColumnName("transactioncurrncy")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<EbayIostorepay>(entity =>
            {
                entity.ToTable("ebay_iostorepay");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IoOrdersn)
                    .IsRequired()
                    .HasColumnName("io_ordersn")
                    .HasMaxLength(30);

                entity.Property(e => e.PayMethod)
                    .IsRequired()
                    .HasColumnName("pay_method")
                    .HasMaxLength(255);

                entity.Property(e => e.PayMoney).HasColumnName("pay_money");

                entity.Property(e => e.PayTime)
                    .HasColumnName("pay_time")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Payer)
                    .IsRequired()
                    .HasColumnName("payer")
                    .HasMaxLength(30);

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasColumnName("remark")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayLabeltotable>(entity =>
            {
                entity.ToTable("ebay_labeltotable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GoodsAmount)
                    .HasColumnName("goods_amount")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GoodsName)
                    .IsRequired()
                    .HasColumnName("goods_name")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsSn)
                    .IsRequired()
                    .HasColumnName("goods_sn")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayLishicalcfee>(entity =>
            {
                entity.ToTable("ebay_lishicalcfee");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Orderid)
                    .HasColumnName("orderid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Shippingid)
                    .HasColumnName("shippingid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Totalweight).HasColumnName("totalweight");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<EbayList>(entity =>
            {
                entity.ToTable("ebay_list");

                entity.HasIndex(e => e.EbayUser)
                    .HasName("ebay_user");

                entity.HasIndex(e => e.ItemId)
                    .HasName("ItemID");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Addprice).HasColumnName("addprice");

                entity.Property(e => e.Advprice)
                    .HasColumnName("advprice")
                    .HasColumnType("decimal(10,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.BidCount).HasMaxLength(255);

                entity.Property(e => e.BuyItNowPrice).HasMaxLength(255);

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .HasMaxLength(255);

                entity.Property(e => e.ConditionId)
                    .HasColumnName("ConditionID")
                    .HasMaxLength(255);

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.DispatchTimeMax).HasMaxLength(255);

                entity.Property(e => e.EbayAccount)
                    .IsRequired()
                    .HasColumnName("ebay_account")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayListingreturnmethodid)
                    .HasColumnName("ebay_listingreturnmethodid")
                    .HasMaxLength(11);

                entity.Property(e => e.EbayListingshippingmethodid)
                    .HasColumnName("ebay_listingshippingmethodid")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(30);

                entity.Property(e => e.GalleryType).HasMaxLength(255);

                entity.Property(e => e.GalleryUrl)
                    .HasColumnName("GalleryURL")
                    .HasMaxLength(255);

                entity.Property(e => e.Hightprice).HasColumnName("hightprice");

                entity.Property(e => e.HitCount).HasMaxLength(255);

                entity.Property(e => e.ItemId)
                    .IsRequired()
                    .HasColumnName("ItemID")
                    .HasMaxLength(30);

                entity.Property(e => e.Jianprice).HasColumnName("jianprice");

                entity.Property(e => e.Lawprice).HasColumnName("lawprice");

                entity.Property(e => e.ListingDuration).HasMaxLength(255);

                entity.Property(e => e.ListingType).HasMaxLength(255);

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.PayPalEmailAddress).HasMaxLength(255);

                entity.Property(e => e.PictureUrl01)
                    .HasColumnName("PictureURL01")
                    .HasMaxLength(255);

                entity.Property(e => e.PictureUrl02)
                    .HasColumnName("PictureURL02")
                    .HasMaxLength(255);

                entity.Property(e => e.PictureUrl03)
                    .HasColumnName("PictureURL03")
                    .HasMaxLength(255);

                entity.Property(e => e.PictureUrl04)
                    .HasColumnName("PictureURL04")
                    .HasMaxLength(255);

                entity.Property(e => e.PriceJc)
                    .HasColumnName("priceJC")
                    .HasColumnType("decimal(10,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Quantity).HasMaxLength(11);

                entity.Property(e => e.QuantityAvailable).HasColumnType("int(20)");

                entity.Property(e => e.QuantitySold)
                    .HasColumnType("int(255)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ReservePrice).HasMaxLength(255);

                entity.Property(e => e.Site).HasMaxLength(255);

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasMaxLength(255);

                entity.Property(e => e.StartPrice).HasMaxLength(255);

                entity.Property(e => e.StartPricecurrencyId)
                    .HasColumnName("StartPricecurrencyID")
                    .HasMaxLength(10);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.StoreCategoryId)
                    .HasColumnName("StoreCategoryID")
                    .HasMaxLength(255);

                entity.Property(e => e.TimeLeft).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.TrackPrice)
                    .HasColumnName("track_price")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TrackStock)
                    .HasColumnName("track_stock")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ViewItemUrl)
                    .HasColumnName("ViewItemURL")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayListlog>(entity =>
            {
                entity.ToTable("ebay_listlog");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasColumnName("account")
                    .HasColumnType("text");

                entity.Property(e => e.Addtime)
                    .HasColumnName("addtime")
                    .HasMaxLength(40);

                entity.Property(e => e.Currentuser)
                    .HasColumnName("currentuser")
                    .HasMaxLength(30);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(50);

                entity.Property(e => e.Itemid)
                    .IsRequired()
                    .HasColumnName("itemid")
                    .HasMaxLength(50);

                entity.Property(e => e.Logs)
                    .IsRequired()
                    .HasColumnName("logs")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayListvariations>(entity =>
            {
                entity.ToTable("ebay_listvariations");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayAccount)
                    .HasColumnName("ebay_account")
                    .HasMaxLength(50);

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(50);

                entity.Property(e => e.Itemid)
                    .HasColumnName("itemid")
                    .HasMaxLength(30);

                entity.Property(e => e.Quantity).HasMaxLength(20);

                entity.Property(e => e.QuantityAvailable)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.QuantitySold).HasColumnType("int(255)");

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasMaxLength(50);

                entity.Property(e => e.StartPrice).HasMaxLength(20);

                entity.Property(e => e.VariationSpecifics).HasColumnType("text");
            });

            modelBuilder.Entity<EbayListvarious>(entity =>
            {
                entity.ToTable("ebay_listvarious");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.Name0)
                    .HasColumnName("name0")
                    .HasMaxLength(255);

                entity.Property(e => e.Name1)
                    .HasColumnName("name1")
                    .HasMaxLength(255);

                entity.Property(e => e.Name2)
                    .HasColumnName("name2")
                    .HasMaxLength(255);

                entity.Property(e => e.Name3)
                    .HasColumnName("name3")
                    .HasMaxLength(255);

                entity.Property(e => e.Name4)
                    .HasColumnName("name4")
                    .HasMaxLength(255);

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasColumnName("sid")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayLog>(entity =>
            {
                entity.ToTable("ebay_log");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasMaxLength(255);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayMailaccount>(entity =>
            {
                entity.ToTable("ebay_mailaccount");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Host)
                    .IsRequired()
                    .HasColumnName("host")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Pid)
                    .IsRequired()
                    .HasColumnName("pid")
                    .HasMaxLength(255);

                entity.Property(e => e.Port)
                    .IsRequired()
                    .HasColumnName("port")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayMessage>(entity =>
            {
                entity.ToTable("ebay_message");

                entity.HasIndex(e => e.EbayUser)
                    .HasName("ebay_user_3");

                entity.HasIndex(e => e.Forms)
                    .HasName("forms");

                entity.HasIndex(e => e.MessageId)
                    .HasName("message_id_2")
                    .IsUnique();

                entity.HasIndex(e => e.Sendid)
                    .HasName("sendid");

                entity.HasIndex(e => e.Status)
                    .HasName("status_2");

                entity.HasIndex(e => new { e.MessageId, e.EbayAccount })
                    .HasName("message_id_3");

                entity.HasIndex(e => new { e.EbayUser, e.EbayAccount, e.Forms })
                    .HasName("ebay_user_2");

                entity.HasIndex(e => new { e.Id, e.Sendid, e.EbayAccount })
                    .HasName("id");

                entity.HasIndex(e => new { e.EbayUser, e.EbayAccount, e.Createtime1, e.Forms })
                    .HasName("ebay_user");

                entity.HasIndex(e => new { e.Status, e.Classid, e.EbayAccount, e.Ishide })
                    .HasName("status");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddTime)
                    .HasColumnName("add_time")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Body).HasColumnName("body");

                entity.Property(e => e.Classid)
                    .HasColumnName("classid")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Createtime)
                    .HasColumnName("createtime")
                    .HasMaxLength(30);

                entity.Property(e => e.Createtime1)
                    .HasColumnName("createtime1")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Currentprice)
                    .HasColumnName("currentprice")
                    .HasMaxLength(30);

                entity.Property(e => e.EbayAccount)
                    .HasColumnName("ebay_account")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayAccount2)
                    .HasColumnName("ebay_account2")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(25);

                entity.Property(e => e.Endtime)
                    .HasColumnName("endtime")
                    .HasMaxLength(30);

                entity.Property(e => e.ExternalMessageId)
                    .HasColumnName("ExternalMessageID")
                    .HasMaxLength(20);

                entity.Property(e => e.Forms)
                    .HasColumnName("forms")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ishide)
                    .HasColumnName("ishide")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Isreply)
                    .HasColumnName("isreply")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Itemid)
                    .HasColumnName("itemid")
                    .HasMaxLength(25);

                entity.Property(e => e.Itemurl)
                    .HasColumnName("itemurl")
                    .HasColumnType("text");

                entity.Property(e => e.MessageId)
                    .HasColumnName("message_id")
                    .HasMaxLength(20);

                entity.Property(e => e.MessageType)
                    .HasColumnName("message_type")
                    .HasMaxLength(30);

                entity.Property(e => e.Mmarket)
                    .HasColumnName("mmarket")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.QuestionType)
                    .HasColumnName("question_type")
                    .HasMaxLength(30);

                entity.Property(e => e.Read)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Recipientid)
                    .HasColumnName("recipientid")
                    .HasMaxLength(100);

                entity.Property(e => e.Replaycontent)
                    .HasColumnName("replaycontent")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Replytime)
                    .HasColumnName("replytime")
                    .HasMaxLength(30);

                entity.Property(e => e.Replyuser)
                    .HasColumnName("replyuser")
                    .HasMaxLength(25);

                entity.Property(e => e.Sendid)
                    .HasColumnName("sendid")
                    .HasMaxLength(100);

                entity.Property(e => e.Sendmail)
                    .HasColumnName("sendmail")
                    .HasMaxLength(100);

                entity.Property(e => e.Starttime)
                    .HasColumnName("starttime")
                    .HasMaxLength(30);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasColumnType("text");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayMessagecategory>(entity =>
            {
                entity.ToTable("ebay_messagecategory");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("category_name")
                    .HasMaxLength(120);

                entity.Property(e => e.EbayAccount)
                    .HasColumnName("ebay_account")
                    .HasColumnType("text");

                entity.Property(e => e.EbayNote)
                    .HasColumnName("ebay_note")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(120);

                entity.Property(e => e.Rules)
                    .HasColumnName("rules")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<EbayMessagelog>(entity =>
            {
                entity.ToTable("ebay_messagelog");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Messagetemplate)
                    .HasColumnName("messagetemplate")
                    .HasColumnType("text");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("order_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Ordernumber)
                    .HasColumnName("ordernumber")
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayMessagenote>(entity =>
            {
                entity.ToTable("ebay_messagenote");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addtime)
                    .IsRequired()
                    .HasColumnName("addtime")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayAccount)
                    .HasColumnName("ebay_account")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayUserid)
                    .HasColumnName("ebay_userid")
                    .HasMaxLength(255);

                entity.Property(e => e.Messageid)
                    .IsRequired()
                    .HasColumnName("messageid")
                    .HasMaxLength(100);

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnName("note")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<EbayMessagetemplate>(entity =>
            {
                entity.ToTable("ebay_messagetemplate");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(255);

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("text");

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(244);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Ordersn)
                    .HasColumnName("ordersn")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayOnhandle>(entity =>
            {
                entity.ToTable("ebay_onhandle");

                entity.HasIndex(e => e.EbayUser)
                    .HasName("ebay_user");

                entity.HasIndex(e => e.GoodsSn)
                    .HasName("goods_sn");

                entity.HasIndex(e => e.StoreId)
                    .HasName("store_id");

                entity.HasIndex(e => new { e.GoodsId, e.GoodsSn, e.StoreId })
                    .HasName("goods_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsCount)
                    .HasColumnName("goods_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GoodsDays)
                    .HasColumnName("goods_days")
                    .HasColumnType("int(255)");

                entity.Property(e => e.GoodsDelivery)
                    .HasColumnName("goods_delivery")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsId)
                    .HasColumnName("goods_id")
                    .HasColumnType("int(255)");

                entity.Property(e => e.GoodsName)
                    .HasColumnName("goods_name")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsSku)
                    .HasColumnName("goods_sku")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsSn)
                    .HasColumnName("goods_sn")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsSx)
                    .HasColumnName("goods_sx")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GoodsXx)
                    .HasColumnName("goods_xx")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Purchasedays)
                    .HasColumnName("purchasedays")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.StoreId)
                    .HasColumnName("store_id")
                    .HasColumnType("int(4)");
            });

            modelBuilder.Entity<EbayOnhandle1>(entity =>
            {
                entity.ToTable("ebay_onhandle1");

                entity.HasIndex(e => e.EbayUser)
                    .HasName("ebay_user");

                entity.HasIndex(e => e.GoodsSn)
                    .HasName("goods_sn");

                entity.HasIndex(e => e.StoreId)
                    .HasName("store_id");

                entity.HasIndex(e => new { e.GoodsId, e.GoodsSn, e.StoreId })
                    .HasName("goods_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsCount)
                    .HasColumnName("goods_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GoodsDays)
                    .HasColumnName("goods_days")
                    .HasColumnType("int(255)");

                entity.Property(e => e.GoodsDelivery)
                    .HasColumnName("goods_delivery")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsId)
                    .HasColumnName("goods_id")
                    .HasColumnType("int(255)");

                entity.Property(e => e.GoodsName)
                    .HasColumnName("goods_name")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsSku)
                    .HasColumnName("goods_sku")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsSn)
                    .HasColumnName("goods_sn")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsSx)
                    .HasColumnName("goods_sx")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GoodsXx)
                    .HasColumnName("goods_xx")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Purchasedays)
                    .HasColumnName("purchasedays")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.StoreId)
                    .HasColumnName("store_id")
                    .HasColumnType("int(4)");
            });

            modelBuilder.Entity<EbayOrder>(entity =>
            {
                entity.HasKey(e => e.EbayId);

                entity.ToTable("ebay_order");

                entity.HasIndex(e => e.EbayAccount)
                    .HasName("ebay_account");

                entity.HasIndex(e => e.EbayCombine)
                    .HasName("ebay_combine");

                entity.HasIndex(e => e.EbayId)
                    .HasName("ebay_id");

                entity.HasIndex(e => e.EbayOrdersn)
                    .HasName("ebay_ordersn_3")
                    .IsUnique();

                entity.HasIndex(e => e.EbayPaidtime)
                    .HasName("ebay_paidtime");

                entity.HasIndex(e => e.EbayStatus)
                    .HasName("ebay_status");

                entity.HasIndex(e => e.EbayTracknumber)
                    .HasName("ebay_tracknumber");

                entity.HasIndex(e => e.EbayUser)
                    .HasName("ebay_user");

                entity.HasIndex(e => e.EbayUserid)
                    .HasName("ebay_userid");

                entity.HasIndex(e => e.Recordnumber)
                    .HasName("recordnumber");

                entity.HasIndex(e => new { e.EbayId, e.EbayPaidtime, e.EbayStatus, e.EbayUser, e.EbayAccount })
                    .HasName("ebay_id_2");

                entity.Property(e => e.EbayId)
                    .HasColumnName("ebay_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cancelreason)
                    .HasColumnName("cancelreason")
                    .HasColumnType("text");

                entity.Property(e => e.Canceltime)
                    .HasColumnName("canceltime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CustomPaypalemailaddress)
                    .HasColumnName("Custom_Paypalemailaddress")
                    .HasMaxLength(49);

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EBayPaymentStatus)
                    .HasColumnName("eBayPaymentStatus")
                    .HasMaxLength(60);

                entity.Property(e => e.EbayAccount)
                    .HasColumnName("ebay_account")
                    .HasMaxLength(60);

                entity.Property(e => e.EbayAccount2)
                    .HasColumnName("ebay_account2")
                    .HasMaxLength(60);

                entity.Property(e => e.EbayAddtime)
                    .HasColumnName("ebay_addtime")
                    .HasColumnType("int(60)");

                entity.Property(e => e.EbayCarrier)
                    .HasColumnName("ebay_carrier")
                    .HasMaxLength(60);

                entity.Property(e => e.EbayCarrier2)
                    .IsRequired()
                    .HasColumnName("ebay_carrier2")
                    .HasMaxLength(60);

                entity.Property(e => e.EbayCarrierstyle)
                    .HasColumnName("ebay_carrierstyle")
                    .HasMaxLength(60);

                entity.Property(e => e.EbayCase)
                    .HasColumnName("ebay_case")
                    .HasColumnType("int(2)");

                entity.Property(e => e.EbayCity)
                    .HasColumnName("ebay_city")
                    .HasMaxLength(100);

                entity.Property(e => e.EbayCombine)
                    .HasColumnName("ebay_combine")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EbayCountryname)
                    .HasColumnName("ebay_countryname")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayCouny)
                    .HasColumnName("ebay_couny")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayCreatedtime)
                    .HasColumnName("ebay_createdtime")
                    .HasColumnType("int(40)");

                entity.Property(e => e.EbayCurrency)
                    .HasColumnName("ebay_currency")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayFeedback)
                    .HasColumnName("ebay_feedback")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EbayMarkettime)
                    .HasColumnName("ebay_markettime")
                    .HasMaxLength(60);

                entity.Property(e => e.EbayNote)
                    .HasColumnName("ebay_note")
                    .HasColumnType("text");

                entity.Property(e => e.EbayNoteb)
                    .HasColumnName("ebay_noteb")
                    .HasMaxLength(155);

                entity.Property(e => e.EbayOrderid)
                    .HasColumnName("ebay_orderid")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayOrderqk)
                    .HasColumnName("ebay_orderqk")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayOrdersn)
                    .IsRequired()
                    .HasColumnName("ebay_ordersn")
                    .HasMaxLength(30);

                entity.Property(e => e.EbayOrdertype)
                    .HasColumnName("ebay_ordertype")
                    .HasMaxLength(60);

                entity.Property(e => e.EbayPaidtime)
                    .HasColumnName("ebay_paidtime")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayPaystatus)
                    .HasColumnName("ebay_paystatus")
                    .HasMaxLength(55);

                entity.Property(e => e.EbayPhone)
                    .HasColumnName("ebay_phone")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayPhone1)
                    .HasColumnName("ebay_phone1")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayPostcode)
                    .HasColumnName("ebay_postcode")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayPtid)
                    .HasColumnName("ebay_ptid")
                    .HasMaxLength(40);

                entity.Property(e => e.EbaySdsn)
                    .HasColumnName("ebay_sdsn")
                    .HasMaxLength(15);

                entity.Property(e => e.EbayShipfee)
                    .HasColumnName("ebay_shipfee")
                    .HasMaxLength(20);

                entity.Property(e => e.EbaySite)
                    .HasColumnName("ebay_site")
                    .HasMaxLength(60);

                entity.Property(e => e.EbayState)
                    .HasColumnName("ebay_state")
                    .HasMaxLength(100);

                entity.Property(e => e.EbayStatus)
                    .HasColumnName("ebay_status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EbayStreet)
                    .HasColumnName("ebay_street")
                    .HasMaxLength(100);

                entity.Property(e => e.EbayStreet1)
                    .HasColumnName("ebay_street1")
                    .HasMaxLength(100);

                entity.Property(e => e.EbayTid)
                    .HasColumnName("ebay_tid")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayTotal).HasColumnName("ebay_total");

                entity.Property(e => e.EbayTracknumber)
                    .HasColumnName("ebay_tracknumber")
                    .HasMaxLength(60);

                entity.Property(e => e.EbayTracknumber2)
                    .IsRequired()
                    .HasColumnName("ebay_tracknumber2")
                    .HasMaxLength(200);

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(80);

                entity.Property(e => e.EbayUserid)
                    .HasColumnName("ebay_userid")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayUsermail)
                    .HasColumnName("ebay_usermail")
                    .HasMaxLength(80);

                entity.Property(e => e.EbayUsername)
                    .HasColumnName("ebay_username")
                    .HasMaxLength(80);

                entity.Property(e => e.EbayWarehouse)
                    .HasColumnName("ebay_warehouse")
                    .HasMaxLength(60);

                entity.Property(e => e.ErpOpId)
                    .HasColumnName("erp_op_id")
                    .HasColumnType("int(2)");

                entity.Property(e => e.IsReg)
                    .HasColumnName("is_reg")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsYichang)
                    .IsRequired()
                    .HasColumnName("is_yichang")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Ishide)
                    .HasColumnName("ishide")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Ismodifive)
                    .HasColumnName("ismodifive")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Isprint)
                    .HasColumnName("isprint")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Ispro)
                    .HasColumnName("ispro")
                    .HasColumnType("int(5)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(60);

                entity.Property(e => e.Mailstatus)
                    .HasColumnName("mailstatus")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Market)
                    .HasColumnName("market")
                    .HasMaxLength(9)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Moneyback)
                    .HasColumnName("moneyback")
                    .HasColumnType("int(2)");

                entity.Property(e => e.MoneybackTotal).HasColumnName("moneyback_total");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("order_no")
                    .HasMaxLength(30);

                entity.Property(e => e.Ordercopst).HasColumnName("ordercopst");

                entity.Property(e => e.OrdersEcaseTime)
                    .HasColumnName("orders_ecase_time")
                    .HasColumnType("int(40)");

                entity.Property(e => e.OrdersPcaseTime)
                    .HasColumnName("orders_pcase_time")
                    .HasColumnType("int(40)");

                entity.Property(e => e.Ordershipfee).HasColumnName("ordershipfee");

                entity.Property(e => e.Ordertype)
                    .HasColumnName("ordertype")
                    .HasMaxLength(255);

                entity.Property(e => e.Orderweight)
                    .HasColumnName("orderweight")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Orderweight2)
                    .HasColumnName("orderweight2")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Packagingstaff)
                    .HasColumnName("packagingstaff")
                    .HasMaxLength(40);

                entity.Property(e => e.Packingtype)
                    .HasColumnName("packingtype")
                    .HasMaxLength(30);

                entity.Property(e => e.Packinguser)
                    .HasColumnName("packinguser")
                    .HasMaxLength(30);

                entity.Property(e => e.PayPalEmailAddress).HasMaxLength(60);

                entity.Property(e => e.PaypalCase)
                    .HasColumnName("paypal_case")
                    .HasColumnType("int(2)");

                entity.Property(e => e.Postive)
                    .HasColumnName("postive")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Profitstatus)
                    .HasColumnName("profitstatus")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Pxorderid)
                    .HasColumnName("pxorderid")
                    .HasMaxLength(11);

                entity.Property(e => e.Pxordertime)
                    .HasColumnName("pxordertime")
                    .HasMaxLength(11);

                entity.Property(e => e.Recordnumber)
                    .HasColumnName("recordnumber")
                    .HasMaxLength(20);

                entity.Property(e => e.RefundAmount).HasColumnType("int(11)");

                entity.Property(e => e.Refundreason)
                    .HasColumnName("refundreason")
                    .HasColumnType("text");

                entity.Property(e => e.Refundtime)
                    .HasColumnName("refundtime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Resendreason)
                    .HasColumnName("resendreason")
                    .HasColumnType("text");

                entity.Property(e => e.Resendtime)
                    .HasColumnName("resendtime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Scantime)
                    .HasColumnName("scantime")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ShipfeeEstimate).HasColumnName("shipfee_estimate");

                entity.Property(e => e.ShippedTime).HasMaxLength(30);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Templateid)
                    .HasColumnName("templateid")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Totalprofit)
                    .HasColumnName("totalprofit")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<EbayOrderdetail>(entity =>
            {
                entity.HasKey(e => e.EbayId);

                entity.ToTable("ebay_orderdetail");

                entity.HasIndex(e => e.EbayCreatedtime)
                    .HasName("ebay_createdtime");

                entity.HasIndex(e => e.EbayOrdersn)
                    .HasName("ebay_ordersn");

                entity.HasIndex(e => e.Recordnumber)
                    .HasName("recordnumber");

                entity.HasIndex(e => e.Sku)
                    .HasName("sku");

                entity.HasIndex(e => new { e.Recordnumber, e.EbayOrdersn })
                    .HasName("recordnumber_2")
                    .IsUnique();

                entity.HasIndex(e => new { e.EbayOrdersn, e.Sku, e.EbayCreatedtime })
                    .HasName("ebay_ordersn_2");

                entity.Property(e => e.EbayId)
                    .HasColumnName("ebay_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addtime)
                    .HasColumnName("addtime")
                    .HasMaxLength(20);

                entity.Property(e => e.Attribute)
                    .HasColumnName("attribute")
                    .HasColumnType("text");

                entity.Property(e => e.CombineOrderid)
                    .HasColumnName("Combine_orderid")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EbayAccount)
                    .HasColumnName("ebay_account")
                    .HasMaxLength(100);

                entity.Property(e => e.EbayAmount)
                    .HasColumnName("ebay_amount")
                    .HasMaxLength(60);

                entity.Property(e => e.EbayCreatedtime)
                    .HasColumnName("ebay_createdtime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayItemid)
                    .HasColumnName("ebay_itemid")
                    .HasMaxLength(20);

                entity.Property(e => e.EbayItemprice)
                    .HasColumnName("ebay_itemprice")
                    .HasMaxLength(20);

                entity.Property(e => e.EbayItemtitle)
                    .HasColumnName("ebay_itemtitle")
                    .HasMaxLength(150);

                entity.Property(e => e.EbayItemurl)
                    .HasColumnName("ebay_itemurl")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayOrdersn)
                    .IsRequired()
                    .HasColumnName("ebay_ordersn")
                    .HasMaxLength(100);

                entity.Property(e => e.EbayShiptype)
                    .HasColumnName("ebay_shiptype")
                    .HasMaxLength(60);

                entity.Property(e => e.EbaySite)
                    .HasColumnName("ebay_site")
                    .HasMaxLength(20);

                entity.Property(e => e.EbayTid)
                    .HasColumnName("ebay_tid")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(60);

                entity.Property(e => e.FeeOrCreditAmount).HasMaxLength(20);

                entity.Property(e => e.GoodsLocation)
                    .HasColumnName("goods_location")
                    .HasMaxLength(30);

                entity.Property(e => e.Istrue)
                    .HasColumnName("istrue")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ListingType).HasMaxLength(20);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.OrderLineItemId)
                    .HasColumnName("OrderLineItemID")
                    .HasMaxLength(50);

                entity.Property(e => e.PayPalEmailAddress).HasMaxLength(60);

                entity.Property(e => e.Recordnumber)
                    .HasColumnName("recordnumber")
                    .HasMaxLength(100);

                entity.Property(e => e.Shipingfee)
                    .HasColumnName("shipingfee")
                    .HasMaxLength(34)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasMaxLength(100);

                entity.Property(e => e.Sourceorder)
                    .HasColumnName("sourceorder")
                    .HasMaxLength(20);

                entity.Property(e => e.Storeid)
                    .HasColumnName("storeid")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<EbayOrdernote>(entity =>
            {
                entity.ToTable("ebay_ordernote");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addtime)
                    .HasColumnName("addtime")
                    .HasMaxLength(255);

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("text");

                entity.Property(e => e.Ordersn)
                    .IsRequired()
                    .HasColumnName("ordersn")
                    .HasMaxLength(255);

                entity.Property(e => e.User)
                    .HasColumnName("user")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayOrderpaypal>(entity =>
            {
                entity.ToTable("ebay_orderpaypal");

                entity.HasIndex(e => e.ExternalTransactionId)
                    .HasName("ExternalTransactionID")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CurrencyId)
                    .IsRequired()
                    .HasColumnName("currencyID")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayOrdersn)
                    .IsRequired()
                    .HasColumnName("ebay_ordersn")
                    .HasMaxLength(255);

                entity.Property(e => e.ExternalTransactionId)
                    .IsRequired()
                    .HasColumnName("ExternalTransactionID")
                    .HasMaxLength(255);

                entity.Property(e => e.ExternalTransactionTime)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FeeOrCreditAmount)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PaymentOrRefundAmount)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayOrderslog>(entity =>
            {
                entity.ToTable("ebay_orderslog");

                entity.HasIndex(e => e.EbayId)
                    .HasName("ebay_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayId)
                    .HasColumnName("ebay_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasMaxLength(255);

                entity.Property(e => e.Operationtime)
                    .HasColumnName("operationtime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Operationuser)
                    .IsRequired()
                    .HasColumnName("operationuser")
                    .HasMaxLength(30);

                entity.Property(e => e.Types)
                    .HasColumnName("types")
                    .HasColumnType("int(2)");
            });

            modelBuilder.Entity<EbayOrdertype>(entity =>
            {
                entity.ToTable("ebay_ordertype");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.Typename)
                    .IsRequired()
                    .HasColumnName("typename")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayPackingmaterial>(entity =>
            {
                entity.ToTable("ebay_packingmaterial");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(30);

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasMaxLength(30);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(255);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Rules)
                    .HasColumnName("rules")
                    .HasMaxLength(100);

                entity.Property(e => e.Tjweight)
                    .HasColumnName("tjweight")
                    .HasColumnType("decimal(6,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<EbayPandian>(entity =>
            {
                entity.ToTable("ebay_pandian");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.HasIndex(e => e.PandianSn)
                    .HasName("goods_sn");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddTime)
                    .HasColumnName("add_time")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasColumnName("add_user")
                    .HasMaxLength(30);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(20);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(300);

                entity.Property(e => e.PandianSn)
                    .IsRequired()
                    .HasColumnName("pandian_sn")
                    .HasMaxLength(30);

                entity.Property(e => e.ShTime)
                    .HasColumnName("sh_time")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ShUser)
                    .HasColumnName("sh_user")
                    .HasMaxLength(30);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.StoreId)
                    .HasColumnName("store_id")
                    .HasColumnType("mediumint(3)");
            });

            modelBuilder.Entity<EbayParcel>(entity =>
            {
                entity.ToTable("ebay_parcel");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addtime)
                    .HasColumnName("addtime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(255);

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasColumnName("details")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnName("note")
                    .HasMaxLength(255);

                entity.Property(e => e.Orderstaus)
                    .IsRequired()
                    .HasColumnName("orderstaus")
                    .HasMaxLength(255);

                entity.Property(e => e.Recordnumber)
                    .IsRequired()
                    .HasColumnName("recordnumber")
                    .HasMaxLength(255);

                entity.Property(e => e.Tracknumber)
                    .IsRequired()
                    .HasColumnName("tracknumber")
                    .HasMaxLength(255);

                entity.Property(e => e.Weight)
                    .IsRequired()
                    .HasColumnName("weight")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayPartner>(entity =>
            {
                entity.ToTable("ebay_partner");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255);

                entity.Property(e => e.Audittime)
                    .HasColumnName("audittime")
                    .HasMaxLength(40);

                entity.Property(e => e.Audituser)
                    .HasColumnName("audituser")
                    .HasMaxLength(40);

                entity.Property(e => e.Bankaccountaddress)
                    .HasColumnName("bankaccountaddress")
                    .HasMaxLength(255);

                entity.Property(e => e.Bankaccountname)
                    .HasColumnName("bankaccountname")
                    .HasMaxLength(255);

                entity.Property(e => e.Bankaccountnumber)
                    .HasColumnName("bankaccountnumber")
                    .HasMaxLength(255);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(255);

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("company_name")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(255);

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(255);

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(255);

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(255);

                entity.Property(e => e.Qq)
                    .HasColumnName("QQ")
                    .HasMaxLength(25);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasMaxLength(255);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayPartnertype>(entity =>
            {
                entity.ToTable("ebay_partnertype");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayStorename)
                    .HasColumnName("ebay_storename")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayStoresn)
                    .HasColumnName("ebay_storesn")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayStoretype)
                    .HasColumnName("ebay_storetype")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayPaypal>(entity =>
            {
                entity.ToTable("ebay_paypal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasColumnName("account")
                    .HasMaxLength(255);

                entity.Property(e => e.Ebayaccount)
                    .HasColumnName("ebayaccount")
                    .HasMaxLength(89)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Fees)
                    .HasColumnName("fees")
                    .HasColumnType("decimal(10,3)")
                    .HasDefaultValueSql("'0.000'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("pass")
                    .HasMaxLength(255);

                entity.Property(e => e.Signature)
                    .IsRequired()
                    .HasColumnName("signature")
                    .HasMaxLength(255);

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasColumnName("user")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayPaypaldetail>(entity =>
            {
                entity.ToTable("ebay_paypaldetail");

                entity.HasIndex(e => e.Tid)
                    .HasName("tid_2")
                    .IsUnique();

                entity.HasIndex(e => e.User)
                    .HasName("user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Account)
                    .HasColumnName("account")
                    .HasMaxLength(50);

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasMaxLength(30);

                entity.Property(e => e.Fee)
                    .HasColumnName("fee")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Gross)
                    .HasColumnName("gross")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(60);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30);

                entity.Property(e => e.Net)
                    .HasColumnName("net")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Tid)
                    .HasColumnName("tid")
                    .HasMaxLength(50);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("int(50)");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasColumnName("user")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<EbayPaypalview>(entity =>
            {
                entity.ToTable("ebay_paypalview");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addtime)
                    .IsRequired()
                    .HasColumnName("addtime")
                    .HasMaxLength(255);

                entity.Property(e => e.Cpuser)
                    .IsRequired()
                    .HasColumnName("cpuser")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("sku")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayProductscombine>(entity =>
            {
                entity.ToTable("ebay_productscombine");

                entity.HasIndex(e => e.EbayUser)
                    .HasName("ebay_user");

                entity.HasIndex(e => e.GoodsSn)
                    .HasName("goods_sn_2");

                entity.HasIndex(e => new { e.GoodsSn, e.EbayUser })
                    .HasName("goods_sn");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(30);

                entity.Property(e => e.GoodsSn)
                    .IsRequired()
                    .HasColumnName("goods_sn")
                    .HasMaxLength(50);

                entity.Property(e => e.GoodsSncombine)
                    .HasColumnName("goods_sncombine")
                    .HasColumnType("text");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(150);

                entity.Property(e => e.NotesEn)
                    .HasColumnName("notes_en")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<EbayRand>(entity =>
            {
                entity.ToTable("ebay_rand");

                entity.HasIndex(e => e.Ordersn)
                    .HasName("ordersn");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayAccount)
                    .HasColumnName("ebay_account")
                    .HasMaxLength(30);

                entity.Property(e => e.Ordersn)
                    .HasColumnName("ordersn")
                    .HasMaxLength(30);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasMaxLength(30);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<EbayRma>(entity =>
            {
                entity.ToTable("ebay_rma");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addtime)
                    .HasColumnName("addtime")
                    .HasMaxLength(100);

                entity.Property(e => e.AreaOwner).HasMaxLength(255);

                entity.Property(e => e.Countrys)
                    .HasColumnName("countrys")
                    .HasMaxLength(255);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.DueDate).HasMaxLength(255);

                entity.Property(e => e.EbayAccount)
                    .HasColumnName("ebay_account")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayCurrency)
                    .HasColumnName("ebay_currency")
                    .HasMaxLength(30);

                entity.Property(e => e.EbayId)
                    .HasColumnName("ebay_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayPid)
                    .HasColumnName("ebay_pid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayRefundamount)
                    .HasColumnName("ebay_refundamount")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayStatus)
                    .HasColumnName("ebay_status")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(40);

                entity.Property(e => e.Nexthandletime)
                    .HasColumnName("nexthandletime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nexthandleuser)
                    .HasColumnName("nexthandleuser")
                    .HasMaxLength(30);

                entity.Property(e => e.OpenDate).HasMaxLength(255);

                entity.Property(e => e.Ordernumber)
                    .IsRequired()
                    .HasColumnName("ordernumber")
                    .HasMaxLength(255);

                entity.Property(e => e.Rastatus)
                    .HasColumnName("rastatus")
                    .HasMaxLength(255);

                entity.Property(e => e.RmaOsn)
                    .IsRequired()
                    .HasColumnName("rma_osn")
                    .HasMaxLength(255);

                entity.Property(e => e.Rtatype)
                    .HasColumnName("rtatype")
                    .HasMaxLength(255);

                entity.Property(e => e.SerialNumber).HasMaxLength(255);

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayRmaactions>(entity =>
            {
                entity.ToTable("ebay_rmaactions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasMaxLength(3);

                entity.Property(e => e.EbayId)
                    .HasColumnName("ebay_id")
                    .HasMaxLength(20);

                entity.Property(e => e.EbayPid)
                    .HasColumnName("ebay_pid")
                    .HasMaxLength(20);

                entity.Property(e => e.Edate)
                    .HasColumnName("edate")
                    .HasColumnType("int(12)");

                entity.Property(e => e.Hxculiren)
                    .HasColumnName("hxculiren")
                    .HasMaxLength(200);

                entity.Property(e => e.Isread)
                    .HasColumnName("isread")
                    .HasMaxLength(200);

                entity.Property(e => e.Noticeuser)
                    .HasColumnName("noticeuser")
                    .HasMaxLength(200);

                entity.Property(e => e.Odate)
                    .HasColumnName("odate")
                    .HasColumnType("int(12)");

                entity.Property(e => e.Psas)
                    .HasColumnName("psas")
                    .HasMaxLength(8);

                entity.Property(e => e.Refund)
                    .HasColumnName("refund")
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasMaxLength(30);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Stype)
                    .HasColumnName("stype")
                    .HasMaxLength(20);

                entity.Property(e => e.Tdate)
                    .HasColumnName("tdate")
                    .HasColumnType("int(12)");

                entity.Property(e => e.Wuser)
                    .HasColumnName("wuser")
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<EbayRmatype>(entity =>
            {
                entity.ToTable("ebay_rmatype");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3)");

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30);

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnName("note")
                    .HasMaxLength(200);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(1)");
            });

            modelBuilder.Entity<EbayScanning>(entity =>
            {
                entity.HasKey(e => e.ScanningId);

                entity.ToTable("ebay_scanning");

                entity.Property(e => e.ScanningId)
                    .HasColumnName("scanning_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.CheckNum)
                    .HasColumnName("check_num")
                    .HasColumnType("int(10)");

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(20);

                entity.Property(e => e.GoodsName)
                    .HasColumnName("goods_name")
                    .HasMaxLength(30);

                entity.Property(e => e.NowOrder)
                    .HasColumnName("now_order")
                    .HasMaxLength(30);

                entity.Property(e => e.OrderNum)
                    .HasColumnName("order_num")
                    .HasColumnType("int(10)");

                entity.Property(e => e.OrderNumber)
                    .HasColumnName("order_number")
                    .HasMaxLength(30);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<EbayShelve>(entity =>
            {
                entity.ToTable("ebay_shelve");

                entity.HasIndex(e => e.Sku)
                    .HasName("SKU");

                entity.HasIndex(e => new { e.WarehouseId, e.ShelveId })
                    .HasName("SHELVEID");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("char(1)");

                entity.Property(e => e.BoxId)
                    .HasColumnName("boxId")
                    .HasMaxLength(45);

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasMaxLength(45);

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Scannedtime)
                    .HasColumnName("scannedtime")
                    .HasMaxLength(45);

                entity.Property(e => e.ShelveId)
                    .IsRequired()
                    .HasColumnName("shelveId")
                    .HasMaxLength(45);

                entity.Property(e => e.ShipmentId)
                    .HasColumnName("shipmentId")
                    .HasMaxLength(45);

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasMaxLength(45);

                entity.Property(e => e.WarehouseId)
                    .IsRequired()
                    .HasColumnName("warehouseId")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<EbayShipfees>(entity =>
            {
                entity.ToTable("ebay_shipfees");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ShipCountry)
                    .HasColumnName("ship_country")
                    .HasMaxLength(255);

                entity.Property(e => e.ShipFee)
                    .HasColumnName("ship_fee")
                    .HasMaxLength(255);

                entity.Property(e => e.ShipGg)
                    .HasColumnName("ship_gg")
                    .HasMaxLength(255);

                entity.Property(e => e.ShipType)
                    .HasColumnName("ship_type")
                    .HasMaxLength(255);

                entity.Property(e => e.ShipWeightsx)
                    .HasColumnName("ship_weightsx")
                    .HasMaxLength(255);

                entity.Property(e => e.ShipWeightxx)
                    .HasColumnName("ship_weightxx")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayShipmentbox>(entity =>
            {
                entity.ToTable("ebay_shipmentbox");

                entity.HasIndex(e => e.Sku)
                    .HasName("SHIPMENTBOX_SKU");

                entity.HasIndex(e => new { e.ShipmentId, e.WarehouseId, e.BoxId, e.Type })
                    .HasName("SHIPMENTBOX_BOXID");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BoxId)
                    .IsRequired()
                    .HasColumnName("boxId")
                    .HasMaxLength(45);

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ShipmentId)
                    .IsRequired()
                    .HasColumnName("shipmentId")
                    .HasMaxLength(45);

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("sku")
                    .HasMaxLength(45);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(45);

                entity.Property(e => e.WarehouseId)
                    .IsRequired()
                    .HasColumnName("warehouseId")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<EbayShiporder>(entity =>
            {
                entity.ToTable("ebay_shiporder");

                entity.HasIndex(e => e.OrderId)
                    .HasName("ORDERID");

                entity.HasIndex(e => e.ShipDate)
                    .HasName("SHIPDATE");

                entity.HasIndex(e => e.TrackingNumber)
                    .HasName("TRACKINGNUMBER");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.OrderId)
                    .HasColumnName("orderId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrderIds)
                    .HasColumnName("orderIds")
                    .HasMaxLength(45);

                entity.Property(e => e.Printed)
                    .HasColumnName("printed")
                    .HasColumnType("char(1)");

                entity.Property(e => e.ScannedTime)
                    .HasColumnName("scannedTime")
                    .HasMaxLength(45);

                entity.Property(e => e.ShipDate)
                    .HasColumnName("shipDate")
                    .HasMaxLength(45);

                entity.Property(e => e.Shipped)
                    .HasColumnName("shipped")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasMaxLength(300);

                entity.Property(e => e.StoreId)
                    .HasColumnName("storeId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TrackingNumber)
                    .HasColumnName("trackingNumber")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<EbayShipping>(entity =>
            {
                entity.HasKey(e => e.ShippingId);

                entity.ToTable("ebay_shipping");

                entity.HasIndex(e => new { e.ShippingCode, e.Enabled })
                    .HasName("shipping_code");

                entity.Property(e => e.ShippingId)
                    .HasColumnName("shipping_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ConfigLable)
                    .HasColumnName("config_lable")
                    .HasColumnType("text");

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Insure)
                    .IsRequired()
                    .HasColumnName("insure")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PrintBg)
                    .HasColumnName("print_bg")
                    .HasMaxLength(255);

                entity.Property(e => e.PrintModel)
                    .HasColumnName("print_model")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ShippingCode)
                    .IsRequired()
                    .HasColumnName("shipping_code")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ShippingDesc)
                    .IsRequired()
                    .HasColumnName("shipping_desc")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ShippingName)
                    .IsRequired()
                    .HasColumnName("shipping_name")
                    .HasMaxLength(120)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ShippingPrint)
                    .IsRequired()
                    .HasColumnName("shipping_print")
                    .HasColumnType("text");

                entity.Property(e => e.SupportCod)
                    .HasColumnName("support_cod")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<EbaySku>(entity =>
            {
                entity.ToTable("ebay_sku");

                entity.HasIndex(e => e.Sku)
                    .HasName("sku")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(255);

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbaySkucountrynote>(entity =>
            {
                entity.ToTable("ebay_skucountrynote");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(30);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(30);

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnName("note")
                    .HasMaxLength(500);

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("sku")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EbaySkulist>(entity =>
            {
                entity.ToTable("ebay_skulist");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Account)
                    .HasColumnName("account")
                    .HasMaxLength(30);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(30);

                entity.Property(e => e.Namecn)
                    .HasColumnName("namecn")
                    .HasMaxLength(100);

                entity.Property(e => e.Nameen)
                    .HasColumnName("nameen")
                    .HasMaxLength(100);

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("sku")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EbaySn>(entity =>
            {
                entity.ToTable("ebay_sn");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addtime)
                    .HasColumnName("addtime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Sn)
                    .IsRequired()
                    .HasColumnName("sn")
                    .HasMaxLength(255);

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasColumnName("user")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayStoragebox>(entity =>
            {
                entity.ToTable("ebay_storagebox");

                entity.HasIndex(e => new { e.WarehouseId, e.StorageLocationId })
                    .HasName("STORAGELOCATIONID");

                entity.HasIndex(e => new { e.WarehouseId, e.ShipmentId, e.BoxId, e.Type })
                    .HasName("BOXID");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("char(1)");

                entity.Property(e => e.BoxId)
                    .IsRequired()
                    .HasColumnName("boxId")
                    .HasMaxLength(45);

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasMaxLength(45);

                entity.Property(e => e.Scannedtime)
                    .HasColumnName("scannedtime")
                    .HasMaxLength(45);

                entity.Property(e => e.ShipmentId)
                    .IsRequired()
                    .HasColumnName("shipmentId")
                    .HasMaxLength(45);

                entity.Property(e => e.StorageLocationId)
                    .IsRequired()
                    .HasColumnName("storageLocationId")
                    .HasMaxLength(45);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(45);

                entity.Property(e => e.WarehouseId)
                    .IsRequired()
                    .HasColumnName("warehouseId")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<EbayStore>(entity =>
            {
                entity.ToTable("ebay_store");

                entity.HasIndex(e => e.EbayUser)
                    .HasName("ebay_user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.StoreLocation)
                    .HasColumnName("store_location")
                    .HasMaxLength(255);

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasColumnName("store_name")
                    .HasMaxLength(255);

                entity.Property(e => e.StoreNote)
                    .HasColumnName("store_note")
                    .HasMaxLength(255);

                entity.Property(e => e.StoreSn)
                    .HasColumnName("store_sn")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayStoretype>(entity =>
            {
                entity.ToTable("ebay_storetype");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayStorename)
                    .HasColumnName("ebay_storename")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayStoresn)
                    .HasColumnName("ebay_storesn")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayStoretype1)
                    .HasColumnName("ebay_storetype")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbaySystemshipfee>(entity =>
            {
                entity.ToTable("ebay_systemshipfee");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Acountrys)
                    .HasColumnName("acountrys")
                    .HasColumnType("text");

                entity.Property(e => e.Adiscount)
                    .HasColumnName("adiscount")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Ahandelfee2)
                    .HasColumnName("ahandelfee2")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Ahandlefee).HasColumnName("ahandlefee");

                entity.Property(e => e.Ashipfee).HasColumnName("ashipfee");

                entity.Property(e => e.Aweightend).HasColumnName("aweightend");

                entity.Property(e => e.Aweightstart).HasColumnName("aweightstart");

                entity.Property(e => e.Bcountrys)
                    .HasColumnName("bcountrys")
                    .HasColumnType("text");

                entity.Property(e => e.Bdiscount).HasColumnName("bdiscount");

                entity.Property(e => e.Bfirstweight).HasColumnName("bfirstweight");

                entity.Property(e => e.Bfirstweightamount).HasColumnName("bfirstweightamount");

                entity.Property(e => e.Bhandlefee).HasColumnName("bhandlefee");

                entity.Property(e => e.Bnextweight).HasColumnName("bnextweight");

                entity.Property(e => e.Bnextweightamount).HasColumnName("bnextweightamount");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Shippingid)
                    .HasColumnName("shippingid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<EbayTemplatecategory>(entity =>
            {
                entity.ToTable("ebay_templatecategory");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(40);

                entity.Property(e => e.Mid)
                    .IsRequired()
                    .HasColumnName("mid")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayTongji>(entity =>
            {
                entity.ToTable("ebay_tongji");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasMaxLength(255);

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasMaxLength(255);

                entity.Property(e => e.User)
                    .HasColumnName("user")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EbayTopmenu>(entity =>
            {
                entity.ToTable("ebay_topmenu");

                entity.HasIndex(e => e.Name)
                    .HasName("name");

                entity.HasIndex(e => e.Ordernumber)
                    .HasName("ordernumber");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Ordernumber)
                    .HasColumnName("ordernumber")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<EbayTracklist>(entity =>
            {
                entity.ToTable("ebay_tracklist");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CurrencyId)
                    .HasColumnName("currencyID")
                    .HasMaxLength(80);

                entity.Property(e => e.EbayUser)
                    .HasColumnName("ebay_user")
                    .HasMaxLength(40);

                entity.Property(e => e.FeedbackScore).HasMaxLength(30);

                entity.Property(e => e.ItemId)
                    .IsRequired()
                    .HasColumnName("ItemID")
                    .HasMaxLength(20);

                entity.Property(e => e.ListingStatus).HasMaxLength(15);

                entity.Property(e => e.PositiveFeedbackPercent).HasMaxLength(20);

                entity.Property(e => e.QuantitySold).HasColumnType("int(11)");

                entity.Property(e => e.Site).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(120);

                entity.Property(e => e.TopRatedSeller).HasMaxLength(10);

                entity.Property(e => e.Trackid)
                    .HasColumnName("trackid")
                    .HasMaxLength(20);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<EbayUser>(entity =>
            {
                entity.ToTable("ebay_user");

                entity.HasIndex(e => e.Username)
                    .HasName("username")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(30);

                entity.Property(e => e.Ebayaccounts)
                    .HasColumnName("ebayaccounts")
                    .HasColumnType("text");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasMaxLength(60);

                entity.Property(e => e.Logtime)
                    .HasColumnName("logtime")
                    .HasMaxLength(60);

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(30);

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text");

                entity.Property(e => e.Orderscountry)
                    .HasColumnName("orderscountry")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(30);

                entity.Property(e => e.Paypal)
                    .HasColumnName("paypal")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Power).HasColumnName("power");

                entity.Property(e => e.Provience)
                    .HasColumnName("provience")
                    .HasMaxLength(30);

                entity.Property(e => e.Record)
                    .HasColumnName("record")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'25'");

                entity.Property(e => e.Regdate)
                    .HasColumnName("regdate")
                    .HasMaxLength(200);

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasMaxLength(30);

                entity.Property(e => e.Truename)
                    .HasColumnName("truename")
                    .HasMaxLength(30);

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasColumnName("user")
                    .HasMaxLength(33);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<EbayZen>(entity =>
            {
                entity.ToTable("ebay_zen");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.User)
                    .HasColumnName("user")
                    .HasMaxLength(255);

                entity.Property(e => e.ZenDatabase)
                    .IsRequired()
                    .HasColumnName("zen_database")
                    .HasMaxLength(255);

                entity.Property(e => e.ZenName)
                    .HasColumnName("zen_name")
                    .HasMaxLength(255);

                entity.Property(e => e.ZenPassword)
                    .HasColumnName("zen_password")
                    .HasMaxLength(255);

                entity.Property(e => e.ZenServer)
                    .HasColumnName("zen_server")
                    .HasMaxLength(255);

                entity.Property(e => e.ZenUsername)
                    .HasColumnName("zen_username")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ErpProductsOp>(entity =>
            {
                entity.ToTable("erp_products_op");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Adder)
                    .HasColumnName("adder")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addtime)
                    .HasColumnName("addtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Aprice).HasColumnName("aprice");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Dl).HasColumnName("dl");

                entity.Property(e => e.Dprice).HasColumnName("dprice");

                entity.Property(e => e.Keywords)
                    .IsRequired()
                    .HasColumnName("keywords")
                    .HasMaxLength(40);

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasColumnName("link")
                    .HasMaxLength(800);

                entity.Property(e => e.Oper)
                    .HasColumnName("oper")
                    .HasColumnType("int(4)");

                entity.Property(e => e.Opprice).HasColumnName("opprice");

                entity.Property(e => e.Opreb)
                    .IsRequired()
                    .HasColumnName("opreb")
                    .HasMaxLength(50);

                entity.Property(e => e.Optime)
                    .HasColumnName("optime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Passtime)
                    .HasColumnName("passtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Paypal).HasColumnName("paypal");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Price1).HasColumnName("price1");

                entity.Property(e => e.Price2).HasColumnName("price2");

                entity.Property(e => e.Profit).HasColumnName("profit");

                entity.Property(e => e.Reb)
                    .IsRequired()
                    .HasColumnName("reb")
                    .HasMaxLength(100);

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasColumnName("remark")
                    .HasMaxLength(1000);

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("sku")
                    .HasMaxLength(200);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ErpProductsQs>(entity =>
            {
                entity.ToTable("erp_products_qs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Adder)
                    .HasColumnName("adder")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addtime)
                    .HasColumnName("addtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cok)
                    .HasColumnName("cok")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("text");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("sku")
                    .HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ErrorsAck>(entity =>
            {
                entity.ToTable("errors_ack");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Currentpage)
                    .HasColumnName("currentpage")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayAccount)
                    .IsRequired()
                    .HasColumnName("ebay_account")
                    .HasMaxLength(100);

                entity.Property(e => e.Endtime)
                    .IsRequired()
                    .HasColumnName("endtime")
                    .HasMaxLength(100);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(255);

                entity.Property(e => e.Starttime)
                    .IsRequired()
                    .HasColumnName("starttime")
                    .HasMaxLength(100);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ErrorsAckmessage>(entity =>
            {
                entity.ToTable("errors_ackmessage");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayAccount)
                    .IsRequired()
                    .HasColumnName("ebay_account")
                    .HasMaxLength(100);

                entity.Property(e => e.Endtime)
                    .IsRequired()
                    .HasColumnName("endtime")
                    .HasMaxLength(100);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(255);

                entity.Property(e => e.Starttime)
                    .IsRequired()
                    .HasColumnName("starttime")
                    .HasMaxLength(100);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<EubAccount>(entity =>
            {
                entity.ToTable("eub_account");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dcity)
                    .HasColumnName("dcity")
                    .HasMaxLength(255);

                entity.Property(e => e.Dcompany)
                    .HasColumnName("dcompany")
                    .HasMaxLength(255);

                entity.Property(e => e.Dcountry)
                    .HasColumnName("dcountry")
                    .HasMaxLength(255);

                entity.Property(e => e.Ddis)
                    .HasColumnName("ddis")
                    .HasMaxLength(255);

                entity.Property(e => e.Demail)
                    .HasColumnName("demail")
                    .HasMaxLength(255);

                entity.Property(e => e.DevId)
                    .IsRequired()
                    .HasColumnName("dev_id")
                    .HasMaxLength(255);

                entity.Property(e => e.DevSig)
                    .IsRequired()
                    .HasColumnName("dev_sig")
                    .HasMaxLength(255);

                entity.Property(e => e.Dname)
                    .HasColumnName("dname")
                    .HasMaxLength(255);

                entity.Property(e => e.Dprovince)
                    .HasColumnName("dprovince")
                    .HasMaxLength(255);

                entity.Property(e => e.Dstreet)
                    .HasColumnName("dstreet")
                    .HasMaxLength(255);

                entity.Property(e => e.Dtel)
                    .HasColumnName("dtel")
                    .HasMaxLength(255);

                entity.Property(e => e.Dzip)
                    .HasColumnName("dzip")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayAccount)
                    .IsRequired()
                    .HasColumnName("ebay_account")
                    .HasMaxLength(255);

                entity.Property(e => e.Pcity)
                    .HasColumnName("pcity")
                    .HasMaxLength(255);

                entity.Property(e => e.Pcompany)
                    .HasColumnName("pcompany")
                    .HasMaxLength(255);

                entity.Property(e => e.Pcountry)
                    .HasColumnName("pcountry")
                    .HasMaxLength(255);

                entity.Property(e => e.Pdis)
                    .HasColumnName("pdis")
                    .HasMaxLength(255);

                entity.Property(e => e.Pemail)
                    .HasColumnName("pemail")
                    .HasMaxLength(255);

                entity.Property(e => e.Pid)
                    .IsRequired()
                    .HasColumnName("pid")
                    .HasMaxLength(255);

                entity.Property(e => e.Pname)
                    .HasColumnName("pname")
                    .HasMaxLength(255);

                entity.Property(e => e.Pprovince)
                    .HasColumnName("pprovince")
                    .HasMaxLength(255);

                entity.Property(e => e.Pstreet)
                    .HasColumnName("pstreet")
                    .HasMaxLength(255);

                entity.Property(e => e.Pte1)
                    .HasColumnName("pte1")
                    .HasMaxLength(255);

                entity.Property(e => e.Ptel)
                    .HasColumnName("ptel")
                    .HasMaxLength(255);

                entity.Property(e => e.Pzip)
                    .HasColumnName("pzip")
                    .HasMaxLength(255);

                entity.Property(e => e.Rcity)
                    .HasColumnName("rcity")
                    .HasMaxLength(255);

                entity.Property(e => e.Rcompany)
                    .HasColumnName("rcompany")
                    .HasMaxLength(255);

                entity.Property(e => e.Rcountry)
                    .HasColumnName("rcountry")
                    .HasMaxLength(255);

                entity.Property(e => e.Rdis)
                    .HasColumnName("rdis")
                    .HasMaxLength(255);

                entity.Property(e => e.Rname)
                    .HasColumnName("rname")
                    .HasMaxLength(255);

                entity.Property(e => e.Rprovince)
                    .HasColumnName("rprovince")
                    .HasMaxLength(255);

                entity.Property(e => e.Rstreet)
                    .HasColumnName("rstreet")
                    .HasMaxLength(100);

                entity.Property(e => e.Shiptype)
                    .HasColumnName("shiptype")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EubAccount1>(entity =>
            {
                entity.ToTable("eub_account1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dcity)
                    .HasColumnName("dcity")
                    .HasMaxLength(255);

                entity.Property(e => e.Dcompany)
                    .HasColumnName("dcompany")
                    .HasMaxLength(255);

                entity.Property(e => e.Dcountry)
                    .HasColumnName("dcountry")
                    .HasMaxLength(255);

                entity.Property(e => e.Ddis)
                    .HasColumnName("ddis")
                    .HasMaxLength(255);

                entity.Property(e => e.Demail)
                    .HasColumnName("demail")
                    .HasMaxLength(255);

                entity.Property(e => e.Dname)
                    .HasColumnName("dname")
                    .HasMaxLength(255);

                entity.Property(e => e.Dprovince)
                    .HasColumnName("dprovince")
                    .HasMaxLength(255);

                entity.Property(e => e.Dstreet)
                    .HasColumnName("dstreet")
                    .HasMaxLength(255);

                entity.Property(e => e.Dtel)
                    .HasColumnName("dtel")
                    .HasMaxLength(255);

                entity.Property(e => e.Dzip)
                    .HasColumnName("dzip")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayAccount)
                    .IsRequired()
                    .HasColumnName("ebay_account")
                    .HasMaxLength(255);

                entity.Property(e => e.Pcity)
                    .HasColumnName("pcity")
                    .HasMaxLength(255);

                entity.Property(e => e.Pcompany)
                    .HasColumnName("pcompany")
                    .HasMaxLength(255);

                entity.Property(e => e.Pcountry)
                    .HasColumnName("pcountry")
                    .HasMaxLength(255);

                entity.Property(e => e.Pdis)
                    .HasColumnName("pdis")
                    .HasMaxLength(255);

                entity.Property(e => e.Pemail)
                    .HasColumnName("pemail")
                    .HasMaxLength(255);

                entity.Property(e => e.Pid)
                    .IsRequired()
                    .HasColumnName("pid")
                    .HasMaxLength(255);

                entity.Property(e => e.Pname)
                    .HasColumnName("pname")
                    .HasMaxLength(255);

                entity.Property(e => e.Pprovince)
                    .HasColumnName("pprovince")
                    .HasMaxLength(255);

                entity.Property(e => e.Pstreet)
                    .HasColumnName("pstreet")
                    .HasMaxLength(255);

                entity.Property(e => e.Pte1)
                    .HasColumnName("pte1")
                    .HasMaxLength(255);

                entity.Property(e => e.Ptel)
                    .HasColumnName("ptel")
                    .HasMaxLength(255);

                entity.Property(e => e.Pzip)
                    .HasColumnName("pzip")
                    .HasMaxLength(255);

                entity.Property(e => e.Rcity)
                    .HasColumnName("rcity")
                    .HasMaxLength(255);

                entity.Property(e => e.Rcompany)
                    .HasColumnName("rcompany")
                    .HasMaxLength(255);

                entity.Property(e => e.Rcountry)
                    .HasColumnName("rcountry")
                    .HasMaxLength(255);

                entity.Property(e => e.Rdis)
                    .HasColumnName("rdis")
                    .HasMaxLength(255);

                entity.Property(e => e.Rname)
                    .HasColumnName("rname")
                    .HasMaxLength(255);

                entity.Property(e => e.Rprovince)
                    .HasColumnName("rprovince")
                    .HasMaxLength(255);

                entity.Property(e => e.Rstreet)
                    .HasColumnName("rstreet")
                    .HasMaxLength(100);

                entity.Property(e => e.Shiptype)
                    .HasColumnName("shiptype")
                    .HasMaxLength(255);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<PartnerSkuprice>(entity =>
            {
                entity.HasKey(e => e.PartnerId);

                entity.ToTable("partner_skuprice");

                entity.Property(e => e.PartnerId)
                    .HasColumnName("partner_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addtime)
                    .IsRequired()
                    .HasColumnName("addtime")
                    .HasMaxLength(40);

                entity.Property(e => e.Adduser)
                    .IsRequired()
                    .HasColumnName("adduser")
                    .HasMaxLength(40);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(40);

                entity.Property(e => e.GoodsCost).HasColumnName("goods_cost");

                entity.Property(e => e.GoodsName)
                    .IsRequired()
                    .HasColumnName("goods_name")
                    .HasMaxLength(255);

                entity.Property(e => e.GoodsNote)
                    .HasColumnName("goods_note")
                    .HasColumnType("text");

                entity.Property(e => e.PartnerSku)
                    .HasColumnName("partner_sku")
                    .HasColumnType("int(40)");

                entity.Property(e => e.Partnerid)
                    .HasColumnName("partnerid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("sku")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Productprofitview>(entity =>
            {
                entity.ToTable("productprofitview");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addtime)
                    .IsRequired()
                    .HasColumnName("addtime")
                    .HasMaxLength(255);

                entity.Property(e => e.Cpuser)
                    .IsRequired()
                    .HasColumnName("cpuser")
                    .HasMaxLength(255);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("sku")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ShipfeeCk1>(entity =>
            {
                entity.ToTable("shipfee_ck1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Clnumber)
                    .IsRequired()
                    .HasColumnName("CLnumber")
                    .HasMaxLength(30);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Jiner)
                    .HasColumnType("decimal(10,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Tracking)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(25);

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasColumnName("user")
                    .HasMaxLength(10);

                entity.Property(e => e.Weight)
                    .HasColumnType("decimal(10,2)")
                    .HasDefaultValueSql("'0.00'");
            });

            modelBuilder.Entity<SystemLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("system_log");

                entity.Property(e => e.LogId)
                    .HasColumnName("log_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Currentime)
                    .HasColumnName("currentime")
                    .HasMaxLength(50);

                entity.Property(e => e.Currentpage)
                    .HasColumnName("currentpage")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EbayAccount)
                    .HasColumnName("ebay_account")
                    .HasMaxLength(100);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.Endtime)
                    .HasColumnName("endtime")
                    .HasMaxLength(200);

                entity.Property(e => e.LogEbayAccount)
                    .HasColumnName("log_ebay_account")
                    .HasMaxLength(50);

                entity.Property(e => e.LogName)
                    .IsRequired()
                    .HasColumnName("log_name")
                    .HasMaxLength(50);

                entity.Property(e => e.LogNotes)
                    .IsRequired()
                    .HasColumnName("log_notes")
                    .HasMaxLength(255);

                entity.Property(e => e.LogOperationtime)
                    .HasColumnName("log_operationtime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LogOrderid)
                    .HasColumnName("log_orderid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Starttime)
                    .HasColumnName("starttime")
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<SystemLogmessage>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("system_logmessage");

                entity.Property(e => e.LogId)
                    .HasColumnName("log_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Currentime)
                    .HasColumnName("currentime")
                    .HasMaxLength(50);

                entity.Property(e => e.EbayAccount)
                    .HasColumnName("ebay_account")
                    .HasMaxLength(100);

                entity.Property(e => e.EbayUser)
                    .IsRequired()
                    .HasColumnName("ebay_user")
                    .HasMaxLength(255);

                entity.Property(e => e.Endtime)
                    .HasColumnName("endtime")
                    .HasMaxLength(200);

                entity.Property(e => e.LogEbayAccount)
                    .HasColumnName("log_ebay_account")
                    .HasMaxLength(50);

                entity.Property(e => e.LogName)
                    .IsRequired()
                    .HasColumnName("log_name")
                    .HasMaxLength(50);

                entity.Property(e => e.LogNotes)
                    .IsRequired()
                    .HasColumnName("log_notes")
                    .HasMaxLength(255);

                entity.Property(e => e.LogOperationtime)
                    .HasColumnName("log_operationtime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LogOrderid)
                    .HasColumnName("log_orderid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Starttime)
                    .HasColumnName("starttime")
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Uploadfilesrecord>(entity =>
            {
                entity.ToTable("uploadfilesrecord");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ebayuser)
                    .IsRequired()
                    .HasColumnName("ebayuser")
                    .HasMaxLength(30);

                entity.Property(e => e.Filetype)
                    .IsRequired()
                    .HasColumnName("filetype")
                    .HasMaxLength(125);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasMaxLength(255);

                entity.Property(e => e.TitleEn)
                    .IsRequired()
                    .HasColumnName("title_en")
                    .HasMaxLength(125);
            });

            modelBuilder.Entity<Wuliu4pxDhl>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_4px_dhl");

                entity.Property(e => e.分区代码).HasColumnType("int(2)");

                entity.Property(e => e._101200kg)
                    .HasColumnName("101200KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._201300kg)
                    .HasColumnName("201300KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._2130kg)
                    .HasColumnName("2130KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._301500kg)
                    .HasColumnName("301500KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._3150kg)
                    .HasColumnName("3150KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._500kg以上)
                    .HasColumnName("500KG_以上")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._5170kg)
                    .HasColumnName("5170KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._71100kg)
                    .HasColumnName("71100KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e.国家)
                    .IsRequired()
                    .HasMaxLength(29);

                entity.Property(e => e.续05kg)
                    .HasColumnName("续05KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e.首05kg)
                    .HasColumnName("首05KG")
                    .HasColumnType("decimal(5,1)");
            });

            modelBuilder.Entity<Wuliu4pxDhlcz>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_4px_dhlcz");

                entity.Property(e => e.分区代码).HasColumnType("int(2)");

                entity.Property(e => e._101200kg)
                    .HasColumnName("101200KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._201300kg)
                    .HasColumnName("201300KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._2130kg)
                    .HasColumnName("2130KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._301500kg)
                    .HasColumnName("301500KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._3150kg)
                    .HasColumnName("3150KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._500kg以上)
                    .HasColumnName("500KG_以上")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._5170kg)
                    .HasColumnName("5170KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._71100kg)
                    .HasColumnName("71100KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e.国家)
                    .IsRequired()
                    .HasMaxLength(29);

                entity.Property(e => e.续05kg)
                    .HasColumnName("续05KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e.首05kg)
                    .HasColumnName("首05KG")
                    .HasColumnType("decimal(5,1)");
            });

            modelBuilder.Entity<Wuliu4pxDhlczTemp>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_4px_dhlcz_temp");

                entity.Property(e => e.分区代码).HasColumnType("int(2)");

                entity.Property(e => e._05kg)
                    .HasColumnName("05KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._10kg)
                    .HasColumnName("10KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._15kg)
                    .HasColumnName("15KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._1kg)
                    .HasColumnName("1KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._25kg)
                    .HasColumnName("25KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._2kg)
                    .HasColumnName("2KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._35kg)
                    .HasColumnName("35KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._3kg)
                    .HasColumnName("3KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._45kg)
                    .HasColumnName("45KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._4kg)
                    .HasColumnName("4KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._55kg)
                    .HasColumnName("55KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._5kg)
                    .HasColumnName("5KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._65kg)
                    .HasColumnName("65KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._6kg)
                    .HasColumnName("6KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._75kg)
                    .HasColumnName("75KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._7kg)
                    .HasColumnName("7KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._85kg)
                    .HasColumnName("85KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._8kg)
                    .HasColumnName("8KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._95kg)
                    .HasColumnName("95KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._9kg)
                    .HasColumnName("9KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e.国家)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Wuliu4pxDhldh>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_4px_dhldh");

                entity.Property(e => e.分区代码).HasColumnType("int(2)");

                entity.Property(e => e._101200kg)
                    .HasColumnName("101200KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._201300kg)
                    .HasColumnName("201300KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._2130kg)
                    .HasColumnName("2130KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._301500kg)
                    .HasColumnName("301500KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._3150kg)
                    .HasColumnName("3150KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._500kg以上)
                    .HasColumnName("500KG_以上")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._5170kg)
                    .HasColumnName("5170KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._71100kg)
                    .HasColumnName("71100KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e.国家)
                    .IsRequired()
                    .HasMaxLength(29);

                entity.Property(e => e.续05kg)
                    .HasColumnName("续05KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e.首05kg)
                    .HasColumnName("首05KG")
                    .HasColumnType("decimal(5,1)");
            });

            modelBuilder.Entity<Wuliu4pxDhldhTemp>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_4px_dhldh_temp");

                entity.Property(e => e.分区代码).HasColumnType("int(2)");

                entity.Property(e => e._05kg)
                    .HasColumnName("05KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._10kg)
                    .HasColumnName("10KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._15kg)
                    .HasColumnName("15KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._1kg)
                    .HasColumnName("1KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._25kg)
                    .HasColumnName("25KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._2kg)
                    .HasColumnName("2KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._35kg)
                    .HasColumnName("35KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._3kg)
                    .HasColumnName("3KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._45kg)
                    .HasColumnName("45KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._4kg)
                    .HasColumnName("4KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._55kg)
                    .HasColumnName("55KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._5kg)
                    .HasColumnName("5KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._65kg)
                    .HasColumnName("65KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._6kg)
                    .HasColumnName("6KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._75kg)
                    .HasColumnName("75KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._7kg)
                    .HasColumnName("7KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._85kg)
                    .HasColumnName("85KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._8kg)
                    .HasColumnName("8KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._95kg)
                    .HasColumnName("95KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._9kg)
                    .HasColumnName("9KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e.国家)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Wuliu4pxDhlTemp>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_4px_dhl_temp");

                entity.Property(e => e.分区代码).HasColumnType("int(2)");

                entity.Property(e => e._05kg)
                    .HasColumnName("05KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._10kg)
                    .HasColumnName("10KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._15kg)
                    .HasColumnName("15KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._1kg)
                    .HasColumnName("1KG")
                    .HasColumnType("int(3)");

                entity.Property(e => e._25kg)
                    .HasColumnName("25KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._2kg)
                    .HasColumnName("2KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._35kg)
                    .HasColumnName("35KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._3kg)
                    .HasColumnName("3KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._45kg)
                    .HasColumnName("45KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._4kg)
                    .HasColumnName("4KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._55kg)
                    .HasColumnName("55KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._5kg)
                    .HasColumnName("5KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._65kg)
                    .HasColumnName("65KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._6kg)
                    .HasColumnName("6KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._75kg)
                    .HasColumnName("75KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._7kg)
                    .HasColumnName("7KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._85kg)
                    .HasColumnName("85KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._8kg)
                    .HasColumnName("8KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._95kg)
                    .HasColumnName("95KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._9kg)
                    .HasColumnName("9KG")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e.国家)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Wuliu4pxDirect>(entity =>
            {
                entity.ToTable("wuliu_4px_direct");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(800);

                entity.Property(e => e.Zone)
                    .HasColumnName("zone")
                    .HasColumnType("int(2)");

                entity.Property(e => e._05)
                    .HasColumnName("0.5")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._10)
                    .HasColumnName("1.0")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._100)
                    .HasColumnName("10.0")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._15)
                    .HasColumnName("1.5")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._20)
                    .HasColumnName("2.0")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._25)
                    .HasColumnName("2.5")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._30)
                    .HasColumnName("3.0")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._35)
                    .HasColumnName("3.5")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._40)
                    .HasColumnName("4.0")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._45)
                    .HasColumnName("4.5")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._50)
                    .HasColumnName("5.0")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._55)
                    .HasColumnName("5.5")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._60)
                    .HasColumnName("6.0")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._65)
                    .HasColumnName("6.5")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._70)
                    .HasColumnName("7.0")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._75)
                    .HasColumnName("7.5")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._80)
                    .HasColumnName("8.0")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._85)
                    .HasColumnName("8.5")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._90)
                    .HasColumnName("9.0")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._95)
                    .HasColumnName("9.5")
                    .HasColumnType("decimal(6,1)");
            });

            modelBuilder.Entity<Wuliu4pxHkdhlyfb>(entity =>
            {
                entity.HasKey(e => e.区域);

                entity.ToTable("wuliu_4px_hkdhlyfb");

                entity.Property(e => e.区域)
                    .HasMaxLength(129)
                    .HasDefaultValueSql("''");

                entity.Property(e => e._101200kg)
                    .HasColumnName("101-200KG")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._201300kg)
                    .HasColumnName("201-300KG")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._2130kg)
                    .HasColumnName("21-30KG")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e._301500kg)
                    .HasColumnName("301-500KG")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e._3150kg)
                    .HasColumnName("31-50KG")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e._500kg以上)
                    .HasColumnName("500KG以上")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e._5170kg)
                    .HasColumnName("51-70KG")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e._71100kg)
                    .HasColumnName("71-100KG")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e.包含国家中)
                    .HasColumnName("包含国家（中）")
                    .HasMaxLength(668);

                entity.Property(e => e.包含国家英)
                    .HasColumnName("包含国家（英）")
                    .HasMaxLength(10);

                entity.Property(e => e.备注).HasMaxLength(300);

                entity.Property(e => e.折扣).HasMaxLength(10);

                entity.Property(e => e.燃油附加费).HasColumnType("decimal(4,3)");

                entity.Property(e => e.物流公司).HasMaxLength(14);

                entity.Property(e => e.续05kg)
                    .HasColumnName("续0.5KG")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e.续25kg优惠)
                    .HasColumnName("续2.5KG优惠")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e.首05kg)
                    .HasColumnName("首0.5KG")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e.首25kg优惠)
                    .HasColumnName("首2.5KG优惠")
                    .HasColumnType("decimal(6,1)");
            });

            modelBuilder.Entity<Wuliu4pxHkfedexie>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_4px_hkfedexie");

                entity.Property(e => e.分区代码)
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e._05)
                    .HasColumnName("0.5")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._10)
                    .HasColumnName("1.0")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._100)
                    .HasColumnName("10.0")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._1000)
                    .HasColumnName("1000+")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e._100299)
                    .HasColumnName("100-299")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._105)
                    .HasColumnName("10.5")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._110)
                    .HasColumnName("11.0")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._115)
                    .HasColumnName("11.5")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._120)
                    .HasColumnName("12.0")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._125)
                    .HasColumnName("12.5")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._130)
                    .HasColumnName("13.0")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._135)
                    .HasColumnName("13.5")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._140)
                    .HasColumnName("14.0")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._145)
                    .HasColumnName("14.5")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._15)
                    .HasColumnName("1.5")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._150)
                    .HasColumnName("15.0")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._155)
                    .HasColumnName("15.5")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._160)
                    .HasColumnName("16.0")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._165)
                    .HasColumnName("16.5")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._170)
                    .HasColumnName("17.0")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._175)
                    .HasColumnName("17.5")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._180)
                    .HasColumnName("18.0")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._185)
                    .HasColumnName("18.5")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._190)
                    .HasColumnName("19.0")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._195)
                    .HasColumnName("19.5")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._20)
                    .HasColumnName("2.0")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._200)
                    .HasColumnName("20.0")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._205)
                    .HasColumnName("20.5")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._2144)
                    .HasColumnName("21-44")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e._25)
                    .HasColumnName("2.5")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._30)
                    .HasColumnName("3.0")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._300499)
                    .HasColumnName("300-499")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._35)
                    .HasColumnName("3.5")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._40)
                    .HasColumnName("4.0")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._45)
                    .HasColumnName("4.5")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._4570)
                    .HasColumnName("45-70")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._50)
                    .HasColumnName("5.0")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._500999)
                    .HasColumnName("500-999")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e._55)
                    .HasColumnName("5.5")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._60)
                    .HasColumnName("6.0")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._65)
                    .HasColumnName("6.5")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e._70)
                    .HasColumnName("7.0")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._7199)
                    .HasColumnName("71-99")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e._75)
                    .HasColumnName("7.5")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._80)
                    .HasColumnName("8.0")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._85)
                    .HasColumnName("8.5")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._90)
                    .HasColumnName("9.0")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e._95)
                    .HasColumnName("9.5")
                    .HasColumnType("decimal(5,1)");

                entity.Property(e => e.包含国家中)
                    .HasColumnName("包含国家（中）")
                    .HasMaxLength(370);

                entity.Property(e => e.包含国家英)
                    .HasColumnName("包含国家（英）")
                    .HasMaxLength(10);

                entity.Property(e => e.备注).HasMaxLength(28);

                entity.Property(e => e.折扣).HasMaxLength(10);

                entity.Property(e => e.燃油附加费).HasColumnType("decimal(4,3)");

                entity.Property(e => e.物流公司).HasMaxLength(13);
            });

            modelBuilder.Entity<Wuliu4pxHkyzdb>(entity =>
            {
                entity.HasKey(e => e.目的地);

                entity.ToTable("wuliu_4px_hkyzdb");

                entity.Property(e => e.目的地)
                    .HasMaxLength(49)
                    .HasDefaultValueSql("''");

                entity.Property(e => e._155kg续05kg)
                    .HasColumnName("1.5-5kg续0.5kg")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e._55kg以上续05kg)
                    .HasColumnName("5.5kg以上续0.5kg")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e.备注).HasMaxLength(15);

                entity.Property(e => e.折扣)
                    .HasColumnType("decimal(3,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.物流公司).HasMaxLength(23);

                entity.Property(e => e.重量上限公斤)
                    .HasColumnName("重量上限(公斤)")
                    .HasColumnType("int(2)");

                entity.Property(e => e.首05kg)
                    .HasColumnName("首0.5kg")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e.首10kg)
                    .HasColumnName("首1.0kg")
                    .HasColumnType("int(3)");
            });

            modelBuilder.Entity<Wuliu4pxLytgh>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_4px_lytgh");

                entity.Property(e => e.分区代码)
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.包含国家中)
                    .HasColumnName("包含国家（中）")
                    .HasMaxLength(500);

                entity.Property(e => e.包含国家英)
                    .HasColumnName("包含国家（英）")
                    .HasMaxLength(500);

                entity.Property(e => e.包裹处理费)
                    .HasColumnName("包裹-处理费")
                    .HasColumnType("int(1)");

                entity.Property(e => e.包裹续100克)
                    .HasColumnName("包裹-续100克")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e.包裹首100克)
                    .HasColumnName("包裹-首100克")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e.区域名称).HasMaxLength(19);

                entity.Property(e => e.备注).HasMaxLength(100);

                entity.Property(e => e.折扣)
                    .HasColumnType("decimal(3,2)")
                    .HasDefaultValueSql("'1.00'");

                entity.Property(e => e.挂号费).HasColumnType("int(2)");

                entity.Property(e => e.文件处理费)
                    .HasColumnName("文件-处理费")
                    .HasColumnType("int(1)");

                entity.Property(e => e.文件续100克)
                    .HasColumnName("文件-续100克")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e.文件首100克)
                    .HasColumnName("文件-首100克")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e.物流公司).HasMaxLength(20);
            });

            modelBuilder.Entity<Wuliu4pxLytpy>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_4px_lytpy");

                entity.Property(e => e.分区代码)
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.包含国家中).HasColumnName("包含国家（中）");

                entity.Property(e => e.包含国家英)
                    .HasColumnName("包含国家（英）")
                    .HasMaxLength(500);

                entity.Property(e => e.包裹处理费)
                    .HasColumnName("包裹-处理费")
                    .HasColumnType("int(1)");

                entity.Property(e => e.包裹续100克)
                    .HasColumnName("包裹-续100克")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e.包裹首100克)
                    .HasColumnName("包裹-首100克")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e.区域名称).HasMaxLength(19);

                entity.Property(e => e.备注).HasMaxLength(100);

                entity.Property(e => e.折扣)
                    .HasColumnType("decimal(3,2)")
                    .HasDefaultValueSql("'1.00'");

                entity.Property(e => e.文件处理费)
                    .HasColumnName("文件-处理费")
                    .HasColumnType("int(1)");

                entity.Property(e => e.文件续100克)
                    .HasColumnName("文件-续100克")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e.文件首100克)
                    .HasColumnName("文件-首100克")
                    .HasColumnType("decimal(6,1)");

                entity.Property(e => e.物流公司).HasMaxLength(20);
            });

            modelBuilder.Entity<Wuliu4pxXjpxb>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_4px_xjpxb");

                entity.Property(e => e.分区代码).HasMaxLength(6);

                entity.Property(e => e.备注).HasMaxLength(17);

                entity.Property(e => e.折扣).HasMaxLength(10);

                entity.Property(e => e.挂号费票)
                    .HasColumnName("挂号费（/票）")
                    .HasColumnType("int(2)");

                entity.Property(e => e.物流公司).HasMaxLength(18);

                entity.Property(e => e.运费Kg)
                    .HasColumnName("运费（/KG）")
                    .HasColumnType("int(3)");
            });

            modelBuilder.Entity<WuliuBeiyubao>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("wuliu_beiyubao");

                entity.Property(e => e.Code).HasColumnType("int(11)");

                entity.Property(e => e.Country).HasMaxLength(204);

                entity.Property(e => e.DeliveryConfirmation).HasColumnType("decimal(10,2)");

                entity.Property(e => e.Weight).HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<WuliuCk1Dnyzx>(entity =>
            {
                entity.HasKey(e => e.目的地Destination);

                entity.ToTable("wuliu_ck1_dnyzx");

                entity.Property(e => e.目的地Destination)
                    .HasColumnName("目的地 Destination")
                    .HasMaxLength(25)
                    .HasDefaultValueSql("''");

                entity.Property(e => e._101kg)
                    .HasColumnName("101kg+")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e._11kg)
                    .HasColumnName("11kg+")
                    .HasColumnType("int(2)");

                entity.Property(e => e._201kg)
                    .HasColumnName("201kg+")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e._21kg)
                    .HasColumnName("21kg+")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e._31kg)
                    .HasColumnName("31kg+")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e._41kg)
                    .HasColumnName("41kg+")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e._51kg)
                    .HasColumnName("51kg+")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e._71kg)
                    .HasColumnName("71kg+")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e.折扣).HasMaxLength(10);

                entity.Property(e => e.物流公司).HasMaxLength(20);

                entity.Property(e => e.续05kg)
                    .HasColumnName("续0.5kg")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e.附加费Kg)
                    .HasColumnName("附加费(/KG)")
                    .HasColumnType("int(4)")
                    .HasDefaultValueSql("'4'");

                entity.Property(e => e.首05kg)
                    .HasColumnName("首0.5kg")
                    .HasColumnType("int(2)");
            });

            modelBuilder.Entity<WuliuCk1Zdzx>(entity =>
            {
                entity.HasKey(e => e.目的地);

                entity.ToTable("wuliu_ck1_zdzx");

                entity.Property(e => e.目的地)
                    .HasMaxLength(15)
                    .HasDefaultValueSql("''");

                entity.Property(e => e._101)
                    .HasColumnName("101")
                    .HasColumnType("int(2)");

                entity.Property(e => e._201)
                    .HasColumnName("201")
                    .HasColumnType("int(2)");

                entity.Property(e => e._21)
                    .HasColumnName("21")
                    .HasColumnType("int(2)");

                entity.Property(e => e._301)
                    .HasColumnName("301")
                    .HasColumnType("int(2)");

                entity.Property(e => e._31)
                    .HasColumnName("31")
                    .HasColumnType("int(2)");

                entity.Property(e => e._51)
                    .HasColumnName("51")
                    .HasColumnType("int(2)");

                entity.Property(e => e._71)
                    .HasColumnName("71")
                    .HasColumnType("int(2)");

                entity.Property(e => e.包裹续重05kg)
                    .HasColumnName("包裹-续重0.5Kg")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e.包裹首重05kg)
                    .HasColumnName("包裹-首重0.5Kg")
                    .HasColumnType("int(3)");

                entity.Property(e => e.备注).HasMaxLength(200);

                entity.Property(e => e.折扣).HasMaxLength(10);

                entity.Property(e => e.文件续重05kg)
                    .HasColumnName("文件-续重0.5Kg")
                    .HasColumnType("decimal(3,1)");

                entity.Property(e => e.文件首重05kg)
                    .HasColumnName("文件-首重0.5Kg")
                    .HasColumnType("int(3)");

                entity.Property(e => e.物流公司).HasMaxLength(17);

                entity.Property(e => e.附加费Kg)
                    .HasColumnName("附加费(/KG)")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'4'");
            });

            modelBuilder.Entity<WuliuEmsFqyfb>(entity =>
            {
                entity.ToTable("wuliu_ems_fqyfb");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.User).HasMaxLength(8);

                entity.Property(e => e.分区).HasMaxLength(6);

                entity.Property(e => e.分区代码).HasMaxLength(1);

                entity.Property(e => e.包含国家中).HasColumnName("包含国家（中）");

                entity.Property(e => e.包含国家英).HasColumnName("包含国家（英）");

                entity.Property(e => e.备注).HasMaxLength(34);

                entity.Property(e => e.折扣).HasColumnType("decimal(3,2)");

                entity.Property(e => e.报关费)
                    .HasColumnType("decimal(4,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.物流公司).HasMaxLength(6);

                entity.Property(e => e.续重500克).HasColumnType("decimal(5,2)");

                entity.Property(e => e.起重500克文件)
                    .HasColumnName("起重500克(文件)")
                    .HasColumnType("decimal(4,2)");

                entity.Property(e => e.起重500克物品)
                    .HasColumnName("起重500克(物品)")
                    .HasColumnType("int(3)");
            });

            modelBuilder.Entity<WuliuEubYfb>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_eub_yfb");

                entity.Property(e => e.分区代码)
                    .HasMaxLength(12)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.分区).HasMaxLength(12);

                entity.Property(e => e.包含国家中)
                    .HasColumnName("包含国家（中）")
                    .HasMaxLength(12);

                entity.Property(e => e.包含国家英)
                    .HasColumnName("包含国家（英）")
                    .HasMaxLength(10);

                entity.Property(e => e.处理费1).HasColumnType("int(2)");

                entity.Property(e => e.处理费2).HasColumnType("int(2)");

                entity.Property(e => e.备注).HasMaxLength(250);

                entity.Property(e => e.折扣).HasColumnType("decimal(3,2)");

                entity.Property(e => e.物流公司).HasMaxLength(7);

                entity.Property(e => e.续重价)
                    .HasColumnType("decimal(5,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.起重G)
                    .HasColumnName("起重（g）")
                    .HasColumnType("int(5)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.起重价)
                    .HasColumnType("decimal(5,2)")
                    .HasDefaultValueSql("'0.00'");
            });

            modelBuilder.Entity<WuliuFedexieFqyfb>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_fedexie_fqyfb");

                entity.Property(e => e.分区代码)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("''");

                entity.Property(e => e._05)
                    .HasColumnName("0.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._10)
                    .HasColumnName("1.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._100)
                    .HasColumnName("10.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._1000)
                    .HasColumnName("1000+")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._100299)
                    .HasColumnName("100-299")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._105)
                    .HasColumnName("10.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._110)
                    .HasColumnName("11.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._115)
                    .HasColumnName("11.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._120)
                    .HasColumnName("12.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._125)
                    .HasColumnName("12.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._130)
                    .HasColumnName("13.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._135)
                    .HasColumnName("13.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._140)
                    .HasColumnName("14.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._145)
                    .HasColumnName("14.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._15)
                    .HasColumnName("1.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._150)
                    .HasColumnName("15.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._155)
                    .HasColumnName("15.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._160)
                    .HasColumnName("16.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._165)
                    .HasColumnName("16.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._170)
                    .HasColumnName("17.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._175)
                    .HasColumnName("17.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._180)
                    .HasColumnName("18.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._185)
                    .HasColumnName("18.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._190)
                    .HasColumnName("19.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._195)
                    .HasColumnName("19.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._20)
                    .HasColumnName("2.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._200)
                    .HasColumnName("20.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._205)
                    .HasColumnName("20.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._2144)
                    .HasColumnName("21-44")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._25)
                    .HasColumnName("2.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._30)
                    .HasColumnName("3.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._300499)
                    .HasColumnName("300-499")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._35)
                    .HasColumnName("3.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._40)
                    .HasColumnName("4.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._45)
                    .HasColumnName("4.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._4570)
                    .HasColumnName("45-70")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._50)
                    .HasColumnName("5.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._500999)
                    .HasColumnName("500-999")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._55)
                    .HasColumnName("5.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._60)
                    .HasColumnName("6.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._65)
                    .HasColumnName("6.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._70)
                    .HasColumnName("7.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._7199)
                    .HasColumnName("71-99")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._75)
                    .HasColumnName("7.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._80)
                    .HasColumnName("8.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._85)
                    .HasColumnName("8.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._90)
                    .HasColumnName("9.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._95)
                    .HasColumnName("9.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.包含国家中).HasColumnName("包含国家（中）");

                entity.Property(e => e.包含国家英)
                    .HasColumnName("包含国家（英）")
                    .HasMaxLength(800);

                entity.Property(e => e.备注).HasMaxLength(30);

                entity.Property(e => e.折扣).HasColumnType("decimal(3,2)");

                entity.Property(e => e.燃油附加费)
                    .HasColumnType("decimal(5,4)")
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.物流公司)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<WuliuFedexipFqyfb>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_fedexip_fqyfb");

                entity.Property(e => e.分区代码)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("''");

                entity.Property(e => e._05)
                    .HasColumnName("0.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._05envelope)
                    .HasColumnName("0.5Envelope")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._05pak)
                    .HasColumnName("0.5Pak")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._10)
                    .HasColumnName("1.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._100)
                    .HasColumnName("10.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._1000)
                    .HasColumnName("1000+")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._100299)
                    .HasColumnName("100-299")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._105)
                    .HasColumnName("10.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._10pak)
                    .HasColumnName("1.0Pak")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._110)
                    .HasColumnName("11.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._115)
                    .HasColumnName("11.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._120)
                    .HasColumnName("12.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._125)
                    .HasColumnName("12.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._130)
                    .HasColumnName("13.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._135)
                    .HasColumnName("13.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._140)
                    .HasColumnName("14.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._145)
                    .HasColumnName("14.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._15)
                    .HasColumnName("1.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._150)
                    .HasColumnName("15.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._155)
                    .HasColumnName("15.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._15pak)
                    .HasColumnName("1.5Pak")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._160)
                    .HasColumnName("16.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._165)
                    .HasColumnName("16.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._170)
                    .HasColumnName("17.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._175)
                    .HasColumnName("17.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._180)
                    .HasColumnName("18.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._185)
                    .HasColumnName("18.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._190)
                    .HasColumnName("19.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._195)
                    .HasColumnName("19.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._20)
                    .HasColumnName("2.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._200)
                    .HasColumnName("20.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._205)
                    .HasColumnName("20.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._20pak)
                    .HasColumnName("2.0Pak")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._2144)
                    .HasColumnName("21-44")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._25)
                    .HasColumnName("2.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._25pak)
                    .HasColumnName("2.5Pak")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._30)
                    .HasColumnName("3.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._300499)
                    .HasColumnName("300-499")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._35)
                    .HasColumnName("3.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._40)
                    .HasColumnName("4.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._45)
                    .HasColumnName("4.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._4570)
                    .HasColumnName("45-70")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._50)
                    .HasColumnName("5.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._500999)
                    .HasColumnName("500-999")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._55)
                    .HasColumnName("5.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._60)
                    .HasColumnName("6.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._65)
                    .HasColumnName("6.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._70)
                    .HasColumnName("7.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._7199)
                    .HasColumnName("71-99")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._75)
                    .HasColumnName("7.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._80)
                    .HasColumnName("8.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._85)
                    .HasColumnName("8.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._90)
                    .HasColumnName("9.0")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e._95)
                    .HasColumnName("9.5")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.包含国家中).HasColumnName("包含国家（中）");

                entity.Property(e => e.包含国家英)
                    .HasColumnName("包含国家（英）")
                    .HasMaxLength(800);

                entity.Property(e => e.备注).HasMaxLength(30);

                entity.Property(e => e.折扣).HasColumnType("decimal(3,2)");

                entity.Property(e => e.燃油附加费)
                    .HasColumnType("decimal(5,4)")
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.物流公司)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<WuliuHkpost>(entity =>
            {
                entity.HasKey(e => e.物流公司);

                entity.ToTable("wuliu_hkpost");

                entity.Property(e => e.物流公司)
                    .HasMaxLength(17)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.备注).HasMaxLength(40);

                entity.Property(e => e.折扣).HasMaxLength(10);

                entity.Property(e => e.挂号费票)
                    .HasColumnName("挂号费（/票）")
                    .HasColumnType("int(2)");

                entity.Property(e => e.运费Kg)
                    .HasColumnName("运费（/KG）")
                    .HasColumnType("int(2)");

                entity.Property(e => e.通达国家).HasMaxLength(6);
            });

            modelBuilder.Entity<WuliuJiachenDubai>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_jiachen_dubai");

                entity.Property(e => e.分区代码).HasColumnType("int(2)");

                entity.Property(e => e.国家)
                    .IsRequired()
                    .HasMaxLength(29);

                entity.Property(e => e.续05kg)
                    .HasColumnName("续05KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e.首05kg)
                    .HasColumnName("首05KG")
                    .HasColumnType("decimal(5,1)");
            });

            modelBuilder.Entity<WuliuJiachenMalaysia>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_jiachen_malaysia");

                entity.Property(e => e.分区代码).HasColumnType("int(2)");

                entity.Property(e => e.国家)
                    .IsRequired()
                    .HasMaxLength(29);

                entity.Property(e => e.续05kg)
                    .HasColumnName("续05KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e.首05kg)
                    .HasColumnName("首05KG")
                    .HasColumnType("decimal(5,1)");
            });

            modelBuilder.Entity<WuliuJiachenOumeiau>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_jiachen_oumeiau");

                entity.Property(e => e.分区代码).HasColumnType("int(2)");

                entity.Property(e => e.国家)
                    .IsRequired()
                    .HasMaxLength(29);

                entity.Property(e => e.续05kg)
                    .HasColumnName("续05KG")
                    .HasColumnType("decimal(4,1)");

                entity.Property(e => e.首05kg)
                    .HasColumnName("首05KG")
                    .HasColumnType("decimal(5,1)");
            });

            modelBuilder.Entity<WuliuUps>(entity =>
            {
                entity.HasKey(e => e.分区);

                entity.ToTable("wuliu_ups");

                entity.Property(e => e.分区).HasMaxLength(12);

                entity.Property(e => e.分区代码)
                    .HasMaxLength(12)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.包含国家中)
                    .HasColumnName("包含国家（中）")
                    .HasMaxLength(12);

                entity.Property(e => e.包含国家英)
                    .HasColumnName("包含国家（英）")
                    .HasMaxLength(10);

                entity.Property(e => e.处理费1).HasColumnType("int(2)");

                entity.Property(e => e.处理费2).HasColumnType("int(2)");

                entity.Property(e => e.备注).HasMaxLength(250);

                entity.Property(e => e.折扣).HasColumnType("decimal(3,2)");

                entity.Property(e => e.物流公司).HasMaxLength(7);

                entity.Property(e => e.续重价)
                    .HasColumnType("decimal(5,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.起重G)
                    .HasColumnName("起重（g）")
                    .HasColumnType("int(5)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.起重价)
                    .HasColumnType("decimal(5,2)")
                    .HasDefaultValueSql("'0.00'");
            });

            modelBuilder.Entity<WuliuYfhFqb>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_yfh_fqb");

                entity.Property(e => e.分区代码)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.分区).HasMaxLength(15);

                entity.Property(e => e.包含国家中).HasColumnName("包含国家（中）");

                entity.Property(e => e.包含国家英).HasColumnName("包含国家（英）");

                entity.Property(e => e.备注)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.折扣).HasColumnType("decimal(3,2)");

                entity.Property(e => e.物流公司).HasMaxLength(15);
            });

            modelBuilder.Entity<WuliuYyb>(entity =>
            {
                entity.HasKey(e => e.包含国家中);

                entity.ToTable("wuliu_yyb");

                entity.Property(e => e.包含国家中)
                    .HasColumnName("包含国家（中）")
                    .HasMaxLength(12)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.处理费1).HasColumnType("int(2)");

                entity.Property(e => e.处理费2).HasColumnType("int(2)");

                entity.Property(e => e.备注).HasMaxLength(250);

                entity.Property(e => e.折扣).HasColumnType("decimal(3,2)");

                entity.Property(e => e.挂号费件)
                    .HasColumnName("挂号费/件")
                    .HasColumnType("decimal(5,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.物流公司).HasMaxLength(7);

                entity.Property(e => e.续重价元Kg)
                    .HasColumnName("续重价元/kg")
                    .HasColumnType("decimal(5,2)")
                    .HasDefaultValueSql("'0.00'");
            });

            modelBuilder.Entity<WuliuZyxbFqyfb>(entity =>
            {
                entity.HasKey(e => e.分区代码);

                entity.ToTable("wuliu_zyxb_fqyfb");

                entity.Property(e => e.分区代码)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.价格)
                    .HasColumnType("decimal(5,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.分区).HasMaxLength(6);

                entity.Property(e => e.包含国家中).HasColumnName("包含国家（中）");

                entity.Property(e => e.包含国家英).HasColumnName("包含国家（英）");

                entity.Property(e => e.备注).HasMaxLength(300);

                entity.Property(e => e.折扣)
                    .HasColumnType("decimal(3,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.挂号费)
                    .HasColumnType("decimal(3,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.物流公司).HasMaxLength(12);
            });

            modelBuilder.Entity<AmazonList>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("amazon_list");

                entity.HasIndex(e => new { e.AccountName, e.SKU })
                    .HasName("account_sku");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccountName)
                    .HasColumnName("accountName")
                    .HasMaxLength(45);

                entity.Property(e => e.SKU)
                    .HasColumnName("sku")
                    .HasMaxLength(45);

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.ASIN)
                    .HasColumnName("asin")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<AmazonAccount>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("amazon_account");

                entity.HasIndex(e => e.AccountName)
                    .HasName("accountName");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccountName)
                    .HasColumnName("accountName")
                    .HasMaxLength(15);

                entity.Property(e => e.SellerId)
                    .HasColumnName("sellerId")
                    .HasMaxLength(15);

                entity.Property(e => e.MWSAuthToken)
                    .HasColumnName("mwsAuthToken")
                    .HasMaxLength(45);
            });
        }
    }
}
