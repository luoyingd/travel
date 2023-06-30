namespace c_web.Form
{
    public class UserRegisterForm
    {
        private string? email;
        private string? password;
        private string? firstName;
        private string? lastName;

        public string? Email { get => email; set => email = value; }
        public string? Password { get => password; set => password = value; }
        public string? FirstName { get => firstName; set => firstName = value; }
        public string? LastName { get => lastName; set => lastName = value; }
    }
}