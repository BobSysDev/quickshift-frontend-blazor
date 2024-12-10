﻿using System.Text.Json;
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
    
    public async Task<IEnumerable<ShiftDTO>> GetAllShiftsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ShiftDTO>>($"Shift");
    }
    
    public async Task AddShiftAsync(CreateShiftDTO shiftDto)
    {
        await _httpClient.PostAsJsonAsync("Shift", shiftDto);
    }

    public async Task<ShiftDTO> UpdateShiftAsync(long Id, CreateShiftDTO shiftDto)
    {
        HttpResponseMessage response = await _httpClient.PatchAsJsonAsync($"Shift/{Id}", shiftDto);
        ShiftDTO responseDTO = JsonSerializer.Deserialize<ShiftDTO>(await response.Content.ReadAsStringAsync());
        return responseDTO;
    }

    public async Task DeleteShiftAsync(long Id)
    {
        await _httpClient.DeleteAsync($"Shift/{Id}");
    }
    
    
}