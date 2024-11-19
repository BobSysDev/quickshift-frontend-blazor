using System.Text.Json;
using DTOs.Shift;

namespace QuickshiftBlazor.Services;

public class HttpShiftService : IShiftService
{
    private readonly HttpClient _httpClient;
    
    public HttpShiftService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<ShiftDTO> GetShiftByIdAsync(long Id)
    {
        return await _httpClient.GetFromJsonAsync<ShiftDTO>($"shifts/{Id}");
    }
    
    public async Task<IEnumerable<ShiftDTO>> GetAllShiftsAsync(long Id)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ShiftDTO>>($"shifts/{Id}");
    }
    
    public async Task AddShiftAsync(CreateShiftDTO shiftDto)
    {
        await _httpClient.PostAsJsonAsync("shifts", shiftDto);
    }

    public async Task<ShiftDTO> UpdateShiftAsync(long Id, CreateShiftDTO shiftDto)
    {
        HttpResponseMessage response = await _httpClient.PatchAsJsonAsync($"shifts/{Id}", shiftDto);
        ShiftDTO responseDTO = JsonSerializer.Deserialize<ShiftDTO>(await response.Content.ReadAsStringAsync());
        return responseDTO;
    }

    public async Task DeleteShiftAsync(long Id)
    {
        await _httpClient.DeleteAsync($"shifts/{Id}");
    }
    
    
}