﻿using DTOs.Announcements;

namespace QuickShiftUI.Services
{
    public interface IAnnouncementService
    {
        Task<List<AnnouncementDTO>> GetAllAnnouncementsAsync();
        Task<List<AnnouncementDTO>> GetMostRecentAnnouncementsAsync(int amount);

        Task<AnnouncementDTO> GetAnnouncementByIdAsync(long id);
        Task AddAnnouncementAsync(AnnouncementDTO announcement);
        Task<AnnouncementDTO> UpdateAnnouncementAsync(long id, AnnouncementDTO announcement);
        Task DeleteAnnouncementAsync(long id);
    }
}
