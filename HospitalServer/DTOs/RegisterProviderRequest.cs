namespace HospitalServer.DTOs
{
    public class RegisterProviderRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "Provider";
    }
}
