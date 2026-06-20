using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClient.Models
{
    public class AuthResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
