namespace CustomerApi.Models;

public class CRMCustomerContactDelta
{
    public string CompanyNumber { get; set; }

    public string CustomerAccount { get; set; }

    public string DeliverySequence { get; set; }

    public string ContactType { get; set; }

    public int ContactNumber { get; set; }

    public string? ContactName { get; set; }

    public string? JobTitle { get; set; }

    public string? CorrespondenceName { get; set; }

    public string? PhoneHome { get; set; }

    public string? PhonePreferred { get; set; }

    public string? PhoneOffice { get; set; }

    public string? PhoneMobile { get; set; }

    public string? Email { get; set; }

    public string? GeneralText1 { get; set; }

    public string? GeneralText2 { get; set; }

    public string? RowHash { get; set; }

    public DateTime? LoadTs { get; set; }
}