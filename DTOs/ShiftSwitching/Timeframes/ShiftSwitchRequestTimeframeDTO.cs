namespace DTOs.Shift;

public class ShiftSwitchRequestTimeframeDTO
{
    public long Id { get; set; }
    public long RequestId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}