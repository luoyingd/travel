using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c_web.Form
{
    public class UserLoginForm
    {
        private string? email;
        private string? password;

        public string? Email { get => email; set => email = value; }
        public string? Password { get => password; set => password = value; }
    }
}