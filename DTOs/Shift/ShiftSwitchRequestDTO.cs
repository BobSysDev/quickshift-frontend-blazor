namespace DTOs.Shift;

public class ShiftSwitchRequestDTO
{
    public long Id { get; set; }
    public long RequesterId { get; set; }
    public long TargetShiftId { get; set; }
    public long OriginShiftId { get; set; }
    public DateTime RequestDate { get; set; }
    public string Status { get; set; }
}