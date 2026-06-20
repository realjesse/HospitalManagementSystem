using System;

namespace HospitalClient.Models
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}