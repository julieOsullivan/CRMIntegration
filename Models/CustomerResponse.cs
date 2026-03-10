namespace CustomerApi.Models;

public class CustomerResponse
{
    public string CustomerAccount { get; set; }
    public string DeliverySequence { get; set; }
    public string? CustomerStatus { get; set; }
    public string? CustomerStatusDesc { get; set; }
    public string? CustomerName { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? AddressLine3 { get; set; }
    public string? AddressLine4 { get; set; }
    public string? AddressLine5 { get; set; }
    public string? PostCodePart1 { get; set; }
    public string? PostCodePart2 { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? PrimaryContact { get; set; }

    public List<DivisionResponse> Divisions { get; set; } = new();
}