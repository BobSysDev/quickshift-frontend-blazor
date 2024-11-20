using DTOs.Shift;

namespace QuickShiftUI.Services;

public interface IShiftService
{
    Task<ShiftDTO> GetShiftByIdAsync(long Id);
    Task<IEnumerable<ShiftDTO>> GetAllShiftsAsync();
    Task AddShiftAsync(CreateShiftDTO shiftDto);
    Task<ShiftDTO> UpdateShiftAsync(long Id, CreateShiftDTO shiftDto);
    Task DeleteShiftAsync(long Id);
}