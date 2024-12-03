using DTOs.Shift;

namespace QuickShiftUI.Services;

public interface IShiftService
{
    Task<ShiftDTO> GetShiftByIdAsync(long Id);
    Task<IEnumerable<ShiftDTO>> GetAllShiftsAsync();
    Task AddShiftAsync(NewShiftDTO shiftDto);
    Task<ShiftDTO> UpdateShiftAsync(long Id, NewShiftDTO shiftDto);
    Task DeleteShiftAsync(long Id);
    
    Task<List<ShiftDTO>> GetAllShiftsByUserIdAsync(long userId);
}