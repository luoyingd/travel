using backend.Models;

namespace backend.Repository
{
    public interface IUserRepository
    {
        void AddPwd(Password password);
        IEnumerable<Password> GetPwd();
        void RegisterUser(User user);
        User GetUser(string? email);
    }
}