using System.Net.Http;
using System.Text.Json;
using DTOs.Announcements;

namespace QuickShiftUI.Services
{
    public class HttpAnnouncementService : IAnnouncementService
    {
        private readonly HttpClient _httpClient;

        public HttpAnnouncementService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AnnouncementDTO>> GetAllAnnouncementsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<AnnouncementDTO>>("Announcement");
        }
        
        public async Task<List<AnnouncementDTO>> GetMostRecentAnnouncementsAsync(int amount)
        {
            return await _httpClient.GetFromJsonAsync<List<AnnouncementDTO>>($"Announcement/Top/{amount}");
        }

        public async Task<AnnouncementDTO> GetAnnouncementByIdAsync(long id)
        {
            return await _httpClient.GetFromJsonAsync<AnnouncementDTO>($"Announcement/{id}");
        }

        public async Task AddAnnouncementAsync(AnnouncementDTO announcement)
        {
            await _httpClient.PostAsJsonAsync("Announcement", announcement);
        }

        public async Task<AnnouncementDTO> UpdateAnnouncementAsync(long id, AnnouncementDTO announcement)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"Announcement/{id}", announcement);
            AnnouncementDTO responseDTO = JsonSerializer.Deserialize<AnnouncementDTO>(await response.Content.ReadAsStringAsync());
            return responseDTO;
        }

        public async Task DeleteAnnouncementAsync(long id)
        {
            await _httpClient.DeleteAsync($"Announcement/{id}");
        }
    }
}