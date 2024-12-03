namespace DTOs.Shift;

public class ShiftDTO
{
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public string TypeOfShift { get; set; }
    public string ShiftStatus { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public long Id { get; set; }
    public List<long> AssignedEmployees { get; set; }
}