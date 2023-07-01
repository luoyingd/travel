using backend.Utils;

namespace backend.Models
{
    public class User
    {
        private int _id;
        private string? _firstName;
        private string? _lastName;
        private string? password;
        private string? email;
        private string? salt;

        [Column(Name = "id")]
        public int Id { get => _id; set => _id = value; }
        [Column(Name = "first_name")]
        public string? FirstName { get => _firstName; set => _firstName = value; }
        [Column(Name = "last_name")]
        public string? LastName { get => _lastName; set => _lastName = value; }
        [Column(Name = "password")]
        public string? Password { get => password; set => password = value; }
        [Column(Name = "email")]
        public string? Email { get => email; set => email = value; }
        [Column(Name = "salt")]
        public string? Salt { get => salt; set => salt = value; }
    }
}