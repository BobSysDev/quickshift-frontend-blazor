using DTOs.Shift;

namespace DTOs;

public class ShiftEmpoyeeDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int WorkingNumber { get; set; }
    public long Id { get; set; }
    public List<ShiftDTO> Shifts { get; set; }
    public bool IsManager { get; set; }
}