using System.Text.Json;
using DTOs.Shift;
using DTOs.ShiftSwitching;

namespace QuickShiftUI.Services;

public class HttpShiftSwitchRequestService : IShiftSwitchRequestService
{
    private readonly HttpClient _httpClient;
    
    public HttpShiftSwitchRequestService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task CreateShiftSwitchRequestAsync(NewShiftSwitchRequestDTO shiftSwitchRequestDto)
    {
        await _httpClient.PostAsJsonAsync("ShiftSwitching/Request", shiftSwitchRequestDto);
    }

    public async Task<ShiftSwitchRequestDTO> GetShiftSwitchRequestByIdAsync(long Id)
    {
        return await _httpClient.GetFromJsonAsync<ShiftSwitchRequestDTO>($"ShiftSwitching/Request/{Id}");
    }

    public async Task<ShiftSwitchRequestDTO> UpdateRequestAsync(long Id, UpdateShiftSwitchRequestDTO shiftSwitchRequestDto)
    {
        HttpResponseMessage response = await _httpClient.PatchAsJsonAsync($"ShiftSwitching/Request/{Id}", shiftSwitchRequestDto);
        ShiftSwitchRequestDTO responseDTO = JsonSerializer.Deserialize<ShiftSwitchRequestDTO>(await response.Content.ReadAsStringAsync());
        return responseDTO;
    }

    public async Task DeleteShiftSwitchRequestAsync(long Id)
    {
        await _httpClient.DeleteAsync("ShiftSwitching/Request/{Id}");
    }

    public async Task<ShiftSwitchRequestDTO> GetShiftSwitchRequestByShiftIdAsync(long shiftId)
    {
        return await _httpClient.GetFromJsonAsync<ShiftSwitchRequestDTO>($"Shift/{shiftId}/ShiftSwitching/Request");
    }

    public async Task<ShiftSwitchRequestDTO> GetShiftSwitchRequestByEmployeeIdAsync(long employeeId)
    {
        return await _httpClient.GetFromJsonAsync<ShiftSwitchRequestDTO>($"Employee/{employeeId}/ShiftSwitching/Request");
    }
}