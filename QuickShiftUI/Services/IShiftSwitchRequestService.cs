using DTOs.Shift;
using DTOs.ShiftSwitching;
namespace QuickShiftUI.Services;


public interface IShiftSwitchRequestService
{
    Task CreateShiftSwitchRequestAsync(NewShiftSwitchRequestDTO shiftSwitchRequestDto);

    Task<List<ShiftSwitchRequestDTO>> GetAllShiftSwitchRequestsAsync();
    Task<ShiftSwitchRequestDTO> GetShiftSwitchRequestByIdAsync(long Id);
    Task<ShiftSwitchRequestDTO> UpdateRequestAsync(long Id, UpdateShiftSwitchRequestDTO shiftSwitchRequestDto);
    Task DeleteShiftSwitchRequestAsync(long Id);
    
    Task<List<ShiftSwitchRequestDTO>> GetAllShiftSwitchRequestsByShiftIdAsync(long shiftId);
    Task<List<ShiftSwitchRequestDTO>> GetAllShiftSwitchRequestsByEmployeeIdAsync(long employeeId);
}