namespace DTOs.ShiftSwitching;

public class NewShiftSwitchRequestDTO
{
    public long OriginEmployeeId { get; set; }
    public long OriginShiftId { get; set; }
    public string Details { get; set; }
}