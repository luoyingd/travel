using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Form
{
    public class ResetPasswordForm
    {
        private string? _token;
        private string? _email;
        private string? _newPassword;

        public string? Token { get => _token; set => _token = value; }
        public string? Email { get => _email; set => _email = value; }
        public string? NewPassword { get => _newPassword; set => _newPassword = value; }
    }
}