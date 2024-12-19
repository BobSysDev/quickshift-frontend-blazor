using DTOs.Shift;

namespace QuickShiftUI.Services;

public interface IShiftService
{
    Task<ShiftDTO> GetShiftByIdAsync(long Id);
    Task<List<ShiftDTO>> GetAllShiftsAsync();
    Task AddShiftAsync(NewShiftDTO shiftDto);
    Task<ShiftDTO> UpdateShiftAsync(long Id, NewShiftDTO shiftDto);
    Task DeleteShiftAsync(long Id);
    
    Task<List<ShiftDTO>> GetAllShiftsByUserIdAsync(long userId);
    
    Task<HttpResponseMessage> AssignShiftToEmployeeAsync(long shiftId, long employeeId);
    Task<HttpResponseMessage> UnassignShiftFromEmployeeAsync(long shiftId, long employeeId);

}