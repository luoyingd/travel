using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c_web.Models
{
    public class User
    {
         private int _id;
         private string? _firstName;
         private string? _lastName;
         private string? password;
         private string? email;
         private string? salt;

        public int Id { get => _id; set => _id = value; }
        public string? FirstName { get => _firstName; set => _firstName = value; }
        public string? LastName { get => _lastName; set => _lastName = value; }
        public string? Password { get => password; set => password = value; }
        public string? Email { get => email; set => email = value; }
        public string? Salt { get => salt; set => salt = value; }
    }
}