using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Column("id")]
        public int Id { get => _id; set => _id = value; }
        [Column("first_name")]
        public string? FirstName { get => _firstName; set => _firstName = value; }
        [Column("last_name")]
        public string? LastName { get => _lastName; set => _lastName = value; }
        [Column("password")]
        public string? Password { get => password; set => password = value; }
        [Column("email")]
        public string? Email { get => email; set => email = value; }
        [Column("salt")]
        public string? Salt { get => salt; set => salt = value; }
    }
}