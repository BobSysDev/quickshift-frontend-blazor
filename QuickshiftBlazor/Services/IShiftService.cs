using DTOs.Shift;

namespace QuickshiftBlazor.Services;

public interface IShiftService
{
    Task<ShiftDTO> GetShiftByIdAsync(long Id);
    Task<IEnumerable<ShiftDTO>> GetAllShiftsAsync(long Id);
    Task AddShiftAsync(CreateShiftDTO shiftDto);
    Task<ShiftDTO> UpdateShiftAsync(long Id, CreateShiftDTO shiftDto);
    Task DeleteShiftAsync(long Id);
}