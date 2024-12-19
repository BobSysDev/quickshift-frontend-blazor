namespace DTOs.Announcements;

public class NewAnnouncementDTO
{
    public long AuthorId { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public DateTime? DateTimeOfPosting { get; set; }
}