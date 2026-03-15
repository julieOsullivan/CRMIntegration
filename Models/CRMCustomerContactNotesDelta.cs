namespace CustomerApi.Models;

public class CRMCustomerContactNotesDelta
{
    public string CompanyNumber { get; set; } = string.Empty;
    public string CustomerAccount { get; set; } = string.Empty;
    public string DeliverySequence { get; set; } = string.Empty;
    public string ContactType { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
    public int NoteLine { get; set; }
    public string? NoteText { get; set; }
    public string? RowHash { get; set; }
    public DateTime LoadTs { get; set; }
    public byte ChangeCode { get; set; }   // 1=Insert, 2=Delete, 3=Update
}
