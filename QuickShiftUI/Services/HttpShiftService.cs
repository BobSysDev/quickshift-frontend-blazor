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
        return await _httpClient.GetFromJsonAsync<ShiftDTO>($"MyShifts/{Id}");
    }
    
    public async Task<IEnumerable<ShiftDTO>> GetAllShiftsAsync(long Id)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ShiftDTO>>($"MyShifts/{Id}");
    }
    
    public async Task AddShiftAsync(CreateShiftDTO shiftDto)
    {
        await _httpClient.PostAsJsonAsync("MyShifts", shiftDto);
    }

    public async Task<ShiftDTO> UpdateShiftAsync(long Id, CreateShiftDTO shiftDto)
    {
        HttpResponseMessage response = await _httpClient.PatchAsJsonAsync($"MyShifts/{Id}", shiftDto);
        ShiftDTO responseDTO = JsonSerializer.Deserialize<ShiftDTO>(await response.Content.ReadAsStringAsync());
        return responseDTO;
    }

    public async Task DeleteShiftAsync(long Id)
    {
        await _httpClient.DeleteAsync($"MyShifts/{Id}");
    }
    
    
}