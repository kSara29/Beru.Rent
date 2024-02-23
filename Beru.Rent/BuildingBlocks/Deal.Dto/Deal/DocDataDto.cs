namespace Deal.Dto.Booking;

public class DocDataDto
{
    public string? DocNumber { get; set; }
    public string? DocTown { get; set; }
    public string? TodayDate { get; set; }
    
    public string? ItemTitle { get; set; }
    public string? ItemDesc { get; set; }
    public string? ExtraConditions { get; set; }
    public string? DealCost { get; set; }
    public string? DealDepositCost { get; set; }
    public string? DealDateBegin { get; set; }
    public string? DealDateEnd{ get; set; }
    public string? DealAddress{ get; set; }
    public string? DealHourBegin{ get; set; }
    public string? DealHourEnd{ get; set; }
    
    public string? OwnerFio{ get; set; }
    public string? OwnerIin { get; set; }
    public string? OwnerIdNumber { get; set; }
    public string? OwnerIdWhereGot { get; set; }
    public string? OwnerPhone { get; set; }
    public string? OwnerEmail { get; set; }
    public string? OwnerAddress { get; set; }
    
    public string? TenantFio{ get; set; }
    public string? TenantIin { get; set; }
    public string? TenantIdNumber { get; set; }
    public string? TenantIdWhereGot { get; set; }
    public string? TenantPhone { get; set; }
    public string? TenantEmail { get; set; }
    public string? TenantAddress { get; set; }
    
}