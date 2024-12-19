using DTOs;

namespace QuickShiftUI.Services;

public interface IEmployeeService
{
    Task<EmployeeDTO> GetEmployeeByIdAsync(long Id);
    Task<List<EmployeeDTO>> GetAllEmployeesAsync();
    Task AddShiftAsync(NewEmployeeDTO employeeDto);
    Task<EmployeeDTO> UpdateEmployeeAsync(long Id, NewEmployeeDTO employeeDto);
    Task DeleteEmployeeAsync(long Id);
}