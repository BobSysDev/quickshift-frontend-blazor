using DTOs;
using DTOs.Shift;

namespace QuickShiftUI.Services;

public interface IShiftSwitchReplyService
{
    Task CreateShiftSwitchReplyAsync(long requestId, NewShiftSwitchReplyDTO shiftSwitchReplyDto);
    Task<ShiftSwitchReplyDTO> GetShiftSwitchReplyByRequestIdAsync(long requestId);
    Task<ShiftSwitchReplyDTO> GetShiftSwitchReplyByIdAsync(long replyId);
    Task<ShiftSwitchReplyDTO> UpdateShiftSwitchReplyAsync(long replyId, UpdateShiftSwitchReplyDTO shiftSwitchReplyDto);
    Task DeleteShiftSwitchReplyAsync(long replyId);
    
    Task <List<ShiftSwitchReplyDTO>> GetShiftSwitchReplyByEmployeeIdAsync(long employeeId);

    Task TargetRejectShiftSwitchReplyAsync(long requestId, long replyId);
    Task TargetAcceptShiftSwitchReplyAsync(long requestId, long replyId);
    Task OriginRejectShiftSwitchReplyAsync(long requestId, long replyId);
    Task OriginAcceptShiftSwitchReplyAsync(long requestId, long replyId);
    
    Task<List<ShiftDTO>> SwitchShiftsAsync(long requestId, long replyId);
}