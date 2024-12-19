namespace DTOs.Announcements;

public class AnnouncementDTO
{
    public long Id { get; set; }
    public long AuthorId { get; set; }
    public string? AuthorName { get; set; }
    public int? AuthorWorkingNumber { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public DateTime? DateTimeOfPosting { get; set; }
}