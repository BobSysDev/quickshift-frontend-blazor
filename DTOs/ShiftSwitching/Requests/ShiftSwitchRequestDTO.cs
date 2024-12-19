namespace DTOs.Shift;

public class ShiftSwitchRequestDTO
{
    public long Id { get; set; }
    public long OriginEmployeeId { get; set; }
    public long OriginShiftId { get; set; }
    public string? Details { get; set; }
    public List<ShiftSwitchReplyDTO>? ReplyDtos { get; set; }
    public List<ShiftSwitchRequestTimeframeDTO>? TimeframeDtos { get; set; }
}