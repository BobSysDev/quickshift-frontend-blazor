using System.Text.Json;
using DTOs;
using DTOs.Shift;

namespace QuickShiftUI.Services;

public class HttpShiftSwitchReplyService : IShiftSwitchReplyService
{
    private readonly HttpClient _httpClient;

    public HttpShiftSwitchReplyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateShiftSwitchReplyAsync(long requestId, NewShiftSwitchReplyDTO shiftSwitchReplyDto)
    {
        await _httpClient.PostAsJsonAsync("ShiftSwitching/Request/{requestId}/Reply", shiftSwitchReplyDto);
    }

    public async Task<ShiftSwitchReplyDTO> GetShiftSwitchReplyByRequestIdAsync(long requestId)
    {
        return await _httpClient.GetFromJsonAsync<ShiftSwitchReplyDTO>("ShiftSwitching/Request/{requestId}/Reply");
    }

    public async Task<ShiftSwitchReplyDTO> GetShiftSwitchReplyByIdAsync(long Id)
    {
        return await _httpClient.GetFromJsonAsync<ShiftSwitchReplyDTO>("ShiftSwitching/Reply/{ID}");
    }

    public async Task<ShiftSwitchReplyDTO> UpdateShiftSwitchReplyAsync(long Id,
        UpdateShiftSwitchReplyDTO shiftSwitchReplyDto)
    {
        HttpResponseMessage response =
            await _httpClient.PatchAsJsonAsync($"ShiftSwitching/Reply/{Id}", shiftSwitchReplyDto);
        ShiftSwitchReplyDTO responseDTO =
            JsonSerializer.Deserialize<ShiftSwitchReplyDTO>(await response.Content.ReadAsStringAsync());
        return responseDTO;
    }

    public async Task DeleteShiftSwitchReplyAsync(long Id)
    {
        await _httpClient.DeleteAsync($"ShiftSwitching/Reply/{Id}");
    }

    public async Task<List<ShiftSwitchReplyDTO>> GetShiftSwitchReplyByEmployeeIdAsync(long employeeId)
    {
        return await _httpClient.GetFromJsonAsync<List<ShiftSwitchReplyDTO>>($"Employee/{employeeId}/ShiftSwitching/Reply");
    }

    public async Task TargetRejectShiftSwitchReplyAsync(long requestId, long replyId)
    {
        await _httpClient.DeleteAsync($"/ShiftSwitching/Request/{requestId}/Reply/{replyId}/TargetAccept");
    }

    public async Task TargetAcceptShiftSwitchReplyAsync(long requestId, long replyId)
    {
        await _httpClient.PostAsJsonAsync($"/ShiftSwitching/Request/{requestId}/Reply/{replyId}/TargetAccept", "");
    }

    public async Task OriginRejectShiftSwitchReplyAsync(long requestId, long replyId)
    {
        await _httpClient.DeleteAsync($"/ShiftSwitching/Request/{requestId}/Reply/{replyId}/OriginAccept");
    }

    public async Task OriginAcceptShiftSwitchReplyAsync(long requestId, long replyId)
    {
        await _httpClient.PostAsJsonAsync($"/ShiftSwitching/Request/{requestId}/Reply/{replyId}/OriginAccept", "");
    }

    public async Task<List<ShiftDTO>> SwitchShiftsAsync(long requestId, long replyId)
    {
        return await _httpClient.GetFromJsonAsync<List<ShiftDTO>>(
            $"/ShiftSwitching/Request/{requestId}/Reply/{replyId}/Resolve");
    }
}