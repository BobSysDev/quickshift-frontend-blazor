namespace DTOs;

public class NewShiftSwitchReplyDTO
{
    public long TargetEmployeeId { get; set; }
    public long TargetShiftId { get; set; }
    public string? Details { get; set; }
}