namespace DTOs.Shift;

public class ShiftDTOWithoutId
{
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public string TypeOfShift { get; set; }
    public string ShiftStatus { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
}