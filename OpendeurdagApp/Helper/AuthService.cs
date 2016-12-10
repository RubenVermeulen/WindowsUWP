using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpendeurdagApp.Models;

namespace OpendeurdagApp.Helper
{
    public class AuthService
    {
        public static UserDbo User { get; set; }

        public static bool IsLoggedIn()
        {
            return User != null;
        }

        public static void LogOut()
        {
            User = null;
        }
    }
}
