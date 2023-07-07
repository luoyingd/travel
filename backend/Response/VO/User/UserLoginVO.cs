namespace backend.Response.VO.User
{
    public class UserLoginVO
    {
        private string? _token;
        private int _userId;

        public string? Token { get => _token; set => _token = value; }
        public int UserId { get => _userId; set => _userId = value; }
    }
}