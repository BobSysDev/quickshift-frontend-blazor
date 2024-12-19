using System.Text.Json;
using DTOs;

namespace QuickShiftUI.Services;

public class HttpEmployeeService : IEmployeeService
{
    private readonly HttpClient _httpClient;

    public HttpEmployeeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<EmployeeDTO> GetEmployeeByIdAsync(long Id)
    {
        return await _httpClient.GetFromJsonAsync<EmployeeDTO>($"Employee/{Id}");
    }

    public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<EmployeeDTO>>($"Employee");
    }

    public async Task AddShiftAsync(NewEmployeeDTO employeeDto)
    {
        await _httpClient.PostAsJsonAsync("Employee", employeeDto);
    }

    public async Task<EmployeeDTO> UpdateEmployeeAsync(long Id, NewEmployeeDTO employeeDto)
    {
        HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"Employee/{Id}", employeeDto);
        EmployeeDTO responseDTO = JsonSerializer.Deserialize<EmployeeDTO>(await response.Content.ReadAsStringAsync());
        return responseDTO;
    }

    public async Task DeleteEmployeeAsync(long Id)
    {
        await _httpClient.DeleteAsync($"Employee/{Id}");
    }
}