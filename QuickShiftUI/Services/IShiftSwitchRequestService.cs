namespace QuickShiftUI.Services;
using DTOs.Shift;

public interface IShiftSwitchRequestService
{
    Task CreateShiftSwitchRequestAsync(ShiftSwitchRequestDTO shiftSwitchRequestDto);
    Task<ShiftSwitchRequestDTO> GetShiftSwitchRequestByIdAsync(long Id);
    Task<ShiftSwitchRequestDTO> UpdateRequestAsync(long Id, ShiftSwitchRequestDTO shiftSwitchRequestDto);
    Task DeleteShiftSwitchRequestAsync(long Id);
    
    Task<ShiftSwitchRequestDTO> GetShiftSwitchRequestByShiftIdAsync(long shiftId);
    Task<ShiftSwitchRequestDTO> GetShiftSwitchRequestByEmployeeIdAsync(long employeeId);
}