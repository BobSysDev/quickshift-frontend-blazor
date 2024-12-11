using DTOs.Shift;
using DTOs.ShiftSwitching;
namespace QuickShiftUI.Services;


public interface IShiftSwitchRequestService
{
    Task CreateShiftSwitchRequestAsync(NewShiftSwitchRequestDTO shiftSwitchRequestDto);

    Task<IEnumerable<ShiftSwitchRequestDTO>> GetAllShiftSwitchRequestsAsync();
    Task<ShiftSwitchRequestDTO> GetShiftSwitchRequestByIdAsync(long Id);
    Task<ShiftSwitchRequestDTO> UpdateRequestAsync(long Id, UpdateShiftSwitchRequestDTO shiftSwitchRequestDto);
    Task DeleteShiftSwitchRequestAsync(long Id);
    
    Task<ShiftSwitchRequestDTO> GetShiftSwitchRequestByShiftIdAsync(long shiftId);
    Task<ShiftSwitchRequestDTO> GetShiftSwitchRequestByEmployeeIdAsync(long employeeId);
}