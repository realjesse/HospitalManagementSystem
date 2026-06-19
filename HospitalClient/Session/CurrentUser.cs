using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClient.Session
{
    public static class CurrentUser
    {
        public static string UserId { get; set; } = "";
        public static string UserName { get; set; } = "";
        public static string Role { get; set; } = "";

        public static bool IsLoggedIn => !string.IsNullOrEmpty(UserId);

        public static bool IsProvider => Role == "Provider";

        public static bool IsPatient => Role == "Patient";
    }
}
