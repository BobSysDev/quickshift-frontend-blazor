namespace DTOs;

public class ShiftSwitchReplyDTO
{
    public long Id { get; set; }
    public long RequestId { get; set; }
    public long TargetEmployeeId { get; set; }
    public long TargetShiftId { get; set; }
    public string? Details { get; set; }
    public bool OriginAccepted { get; set; }
    public bool TargetAccepted { get; set; }
}