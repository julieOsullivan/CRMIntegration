using Microsoft.EntityFrameworkCore;
using CustomerApi.Models;

namespace CustomerApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<CRMCustomerDelta> CRMCustomerDelta { get; set; }
    public DbSet<CRMCustomerContactDelta> CRMCustomerContactDelta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CRMCustomerDelta>(entity =>
        {
            entity.ToTable("CRM_Customer_Delta", "dbo");

            entity.HasKey(x => new
            {
                x.CustomerAccount,
                x.DeliverySequence,
                x.LoadTs
            });

            entity.Property(e => e.CustomerAccount).HasColumnName("CUSTOMER_ACCOUNT");
            entity.Property(e => e.DeliverySequence).HasColumnName("DELIVERY_SEQUENCE");
            entity.Property(e => e.CustomerStatus).HasColumnName("CUSTOMER_STATUS");
            entity.Property(e => e.CustomerStatusDesc).HasColumnName("CUSTOMER_STATUS_DESC");
            entity.Property(e => e.CustomerName).HasColumnName("CUSTOMER_NAME");
            entity.Property(e => e.AddressLine1).HasColumnName("ADDRESS_LINE_1");
            entity.Property(e => e.AddressLine2).HasColumnName("ADDRESS_LINE_2");
            entity.Property(e => e.AddressLine3).HasColumnName("ADDRESS_LINE_3");
            entity.Property(e => e.AddressLine4).HasColumnName("ADDRESS_LINE_4");
            entity.Property(e => e.AddressLine5).HasColumnName("ADDRESS_LINE_5");
            entity.Property(e => e.PostCodePart1).HasColumnName("POST_CODE_PART1");
            entity.Property(e => e.PostCodePart2).HasColumnName("POST_CODE_PART2");
            entity.Property(e => e.PaymentTermsCode).HasColumnName("PAYMENT_TERMS_CODE");
            entity.Property(e => e.SecuritisedCode).HasColumnName("SECURITISED_CODE");
            entity.Property(e => e.SegmentTopLevel).HasColumnName("SEGMENT_TOP_LEVEL");
            entity.Property(e => e.SegmentBottomLevel).HasColumnName("SEGMENT_BOTTOM_LEVEL");
            entity.Property(e => e.SdmCode).HasColumnName("SDM_CODE");
            entity.Property(e => e.StatementAddressCode).HasColumnName("STATEMENT_ADDRESS_CODE");
            entity.Property(e => e.InvoiceAddressCode).HasColumnName("INVOICE_ADDRESS_CODE");
            entity.Property(e => e.CustomerTelephone).HasColumnName("CUSTOMER_TELEPHONE");
            entity.Property(e => e.SpecialInstructions).HasColumnName("SPECIAL_INSTRUCTIONS");
            entity.Property(e => e.DateAccountOpened).HasColumnName("DATE_ACCOUNT_OPENED");
            entity.Property(e => e.WebsiteUrl).HasColumnName("WEBSITE_URL");
            entity.Property(e => e.PrimaryContact).HasColumnName("PRIMARY_CONTACT");
            entity.Property(e => e.CustomerPricing).HasColumnName("CUSTOMER_PRICING");
            entity.Property(e => e.PriceCode).HasColumnName("PRICE_CODE");
            entity.Property(e => e.BusinessUnitCode).HasColumnName("BUSINESS_UNIT_CODE");
            entity.Property(e => e.TradeChannelCode).HasColumnName("TRADE_CHANNEL_CODE");
            entity.Property(e => e.TradingStatus).HasColumnName("TRADING_STATUS");
            entity.Property(e => e.CustomerClass).HasColumnName("CUSTOMER_CLASS");
            entity.Property(e => e.DeliveryLeadTime).HasColumnName("DELIVERY_LEAD_TIME");
            entity.Property(e => e.ProofOfDeliveryReq).HasColumnName("PROOF_OF_DELIVERY_REQ");
            entity.Property(e => e.InvoiceFlag).HasColumnName("INVOICE_FLAG");
            entity.Property(e => e.OutletCode).HasColumnName("OUTLET_CODE");
            entity.Property(e => e.CreditLimit).HasColumnName("CREDIT_LIMIT").HasPrecision(15, 2);
            entity.Property(e => e.CreditLimitCode).HasColumnName("CREDIT_LIMIT_CODE");
            entity.Property(e => e.CreditController).HasColumnName("CREDIT_CONTROLLER");
            entity.Property(e => e.DebtDaysCreditLimit).HasColumnName("DEBT_DAYS_CREDIT_LIMIT");
            entity.Property(e => e.PaymentMethod).HasColumnName("PAYMENT_METHOD");
            entity.Property(e => e.TransportCentre).HasColumnName("TRANSPORT_CENTRE");
            entity.Property(e => e.DeliveryRoute).HasColumnName("DELIVERY_ROUTE");
            entity.Property(e => e.DeliveryMonday).HasColumnName("DELIVERY_MONDAY");
            entity.Property(e => e.DeliveryTuesday).HasColumnName("DELIVERY_TUESDAY");
            entity.Property(e => e.DeliveryWednesday).HasColumnName("DELIVERY_WEDNESDAY");
            entity.Property(e => e.DeliveryThursday).HasColumnName("DELIVERY_THURSDAY");
            entity.Property(e => e.DeliveryFriday).HasColumnName("DELIVERY_FRIDAY");
            entity.Property(e => e.DeliverySaturday).HasColumnName("DELIVERY_SATURDAY");
            entity.Property(e => e.DeliverySunday).HasColumnName("DELIVERY_SUNDAY");
            entity.Property(e => e.GeneralLedgerDebtorsControlAccountExtension).HasColumnName("GENERAL_LEDGER_DEBTORS_CONTROL_ACCOUNT_EXTENSION");
            entity.Property(e => e.PaymentTermsType).HasColumnName("PAYMENT_TERMS_TYPE");
            entity.Property(e => e.PaymentTermsTermsDays).HasColumnName("PAYMENT_TERMS_TERMS_DAYS");
            entity.Property(e => e.PaymentTermsPeriodicRange).HasColumnName("PAYMENT_TERMS_PERIODIC_RANGE");
            entity.Property(e => e.CompanyRegistrationCode).HasColumnName("COMPANY_REGISTRATION_CODE");
            entity.Property(e => e.OeCustomer).HasColumnName("OE_CUSTOMER");
            entity.Property(e => e.EqCustomer).HasColumnName("EQ_CUSTOMER");
            entity.Property(e => e.CsCustomer).HasColumnName("CS_CUSTOMER");
            entity.Property(e => e.RowHash).HasColumnName("ROW_HASH");
            entity.Property(e => e.LoadTs).HasColumnName("LOAD_TS");
            entity.Property(e => e.ChangeCode).HasColumnName("CHANGE_CODE");
        });

        modelBuilder.Entity<CRMCustomerContactDelta>(entity =>
        {
            entity.ToTable("CRM_CustomerContact_Delta", "dbo");

            entity.HasKey(x => new
            {
                x.CompanyNumber,
                x.CustomerAccount,
                x.DeliverySequence,
                x.ContactType,
                x.ContactNumber,
                x.LoadTs
            });

            entity.Property(e => e.CompanyNumber).HasColumnName("company_number");
            entity.Property(e => e.CustomerAccount).HasColumnName("customer_account");
            entity.Property(e => e.DeliverySequence).HasColumnName("delivery_sequence");
            entity.Property(e => e.ContactType).HasColumnName("contact_type");
            entity.Property(e => e.ContactNumber).HasColumnName("contact_number");

            entity.Property(e => e.ContactName).HasColumnName("contact_name");
            entity.Property(e => e.JobTitle).HasColumnName("job_title");
            entity.Property(e => e.CorrespondenceName).HasColumnName("correspondence_name");

            entity.Property(e => e.PhoneHome).HasColumnName("phone_home");
            entity.Property(e => e.PhonePreferred).HasColumnName("phone_preferred");
            entity.Property(e => e.PhoneOffice).HasColumnName("phone_office");
            entity.Property(e => e.PhoneMobile).HasColumnName("phone_mobile");

            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.GeneralText1).HasColumnName("general_text1");
            entity.Property(e => e.GeneralText2).HasColumnName("general_text2");

            entity.Property(e => e.RowHash).HasColumnName("row_hash");
            entity.Property(e => e.LoadTs).HasColumnName("load_ts");
        });
 
    }
}