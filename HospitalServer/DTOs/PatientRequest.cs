namespace HospitalServer.DTOs
{
    // Info sent to database for Patient
    public class PatientRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}
