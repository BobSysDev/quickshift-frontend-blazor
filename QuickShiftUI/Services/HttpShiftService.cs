using System.Text.Json;
using DTOs.Shift;

namespace QuickShiftUI.Services;

public class HttpShiftService : IShiftService
{
    private readonly HttpClient _httpClient;
    
    public HttpShiftService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<ShiftDTO> GetShiftByIdAsync(long Id)
    {
        return await _httpClient.GetFromJsonAsync<ShiftDTO>($"Shift/{Id}");
    }
    
    public async Task<List<ShiftDTO>> GetAllShiftsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<ShiftDTO>>($"Shift");
    }
    
    public async Task AddShiftAsync(NewShiftDTO shiftDto)
    {
        await _httpClient.PostAsJsonAsync("Shift", shiftDto);
    }

    public async Task<ShiftDTO> UpdateShiftAsync(long Id, NewShiftDTO shiftDto)
    {
        HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"Shift/{Id}", shiftDto);
        Console.WriteLine("Olek penis");
        Console.WriteLine(response.StatusCode);
        ShiftDTO responseDTO = JsonSerializer.Deserialize<ShiftDTO>(await response.Content.ReadAsStringAsync());
        return responseDTO;
    }

    public async Task DeleteShiftAsync(long Id)
    {
        await _httpClient.DeleteAsync($"Shift/{Id}");
    }

    public async Task<List<ShiftDTO>> GetAllShiftsByUserIdAsync(long userId)
    {
        return await _httpClient.GetFromJsonAsync<List<ShiftDTO>>($"Shifts/Employee/{userId}");
    }
    
    public async Task<HttpResponseMessage> AssignShiftToEmployeeAsync(long shiftId, long employeeId)
    {
        return await _httpClient.PatchAsync($"/Shift/{shiftId}/Assign/{employeeId}", null);
    }

    public async Task<HttpResponseMessage> UnassignShiftFromEmployeeAsync(long shiftId, long employeeId)
    {
        return await _httpClient.PatchAsync($"/Shift/{shiftId}/Unassign/{employeeId}", null);
    }

}