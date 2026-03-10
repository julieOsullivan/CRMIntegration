namespace CustomerApi.Models;

public class DivisionResponse
{
    public string? BusinessUnitCode { get; set; }
    public string? TradeChannelCode { get; set; }
    public string? CustomerPricing { get; set; }
    public string? PriceCode { get; set; }
    public string? TradingStatus { get; set; }
    public string? CustomerClass { get; set; }
    public int? DeliveryLeadTime { get; set; }
    public string? ProofOfDeliveryReq { get; set; }
    public string? InvoiceFlag { get; set; }
    public string? OutletCode { get; set; }
    public string? OeCustomer { get; set; }
    public string? EqCustomer { get; set; }
    public string? CsCustomer { get; set; }
}