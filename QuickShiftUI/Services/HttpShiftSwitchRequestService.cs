using DTOs.Shift;

namespace QuickShiftUI.Services;

public class HttpShiftSwitchRequestService : IShiftSwitchRequestService
{
    public Task<ShiftSwitchRequestDTO> CreateShiftSwitchRequestAsync(ShiftSwitchRequestDTO shiftSwitchRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task<ShiftSwitchRequestDTO> GetShiftSwitchRequestByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public Task<ShiftSwitchRequestDTO> UpdateRequestAsync(long Id, ShiftSwitchRequestDTO shiftSwitchRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteShiftSwitchRequestAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public Task<ShiftSwitchRequestDTO> GetShiftSwitchRequestByShiftIdAsync(long shiftId)
    {
        throw new NotImplementedException();
    }

    public Task<ShiftSwitchRequestDTO> GetShiftSwitchRequestByEmployeeIdAsync(long employeeId)
    {
        throw new NotImplementedException();
    }
}