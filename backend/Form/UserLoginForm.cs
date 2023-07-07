namespace backend.Form
{
    public class UserLoginForm
    {
        private string? email;
        private string? password;
        private bool isFromGoogle;
        private string? accessToken;

        public string? Email { get => email; set => email = value; }
        public string? Password { get => password; set => password = value; }
        public bool IsFromGoogle { get => isFromGoogle; set => isFromGoogle = value; }
        public string? AccessToken { get => accessToken; set => accessToken = value; }
    }
}