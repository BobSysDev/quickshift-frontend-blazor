using DTOs;
using DTOs.Shift;

namespace QuickShiftUI.Services;

public interface IShiftSwitchReplyService
{
    Task CreateShiftSwitchReplyAsync(long requestId, NewShiftSwitchReplyDTO shiftSwitchReplyDto);
    Task<ShiftSwitchReplyDTO> GetShiftSwitchReplyByRequestIdAsync(long requestId);
    Task<ShiftSwitchReplyDTO> GetShiftSwitchReplyByIdAsync(long Id);
    Task<ShiftSwitchReplyDTO> UpdateShiftSwitchReplyAsync(long Id, UpdateShiftSwitchReplyDTO shiftSwitchReplyDto);
    Task DeleteShiftSwitchReplyAsync(long Id);
    
    Task<ShiftSwitchReplyDTO> GetShiftSwitchReplyByEmployeeIdAsync(long employeeId);
    
    //
    //
    //
    //
    //
}