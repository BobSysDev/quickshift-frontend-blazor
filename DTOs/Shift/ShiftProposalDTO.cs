namespace DTOs.Shift
{
    public class ShiftProposalDTO
    {
        public long Id { get; set; }
        public ShiftDTO OriginShift { get; set; }
        public EmployeeDTO OriginEmployee { get; set; }
        public ShiftDTO TargetShift { get; set; }
        public EmployeeDTO TargetEmployee { get; set; }
    }
}