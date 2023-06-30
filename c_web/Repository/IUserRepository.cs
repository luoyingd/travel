using c_web.Data;
using c_web.Models;

namespace c_web.Repository
{
    public interface IUserRepository
    {
        void AddPwd(Password password);
        IEnumerable<Password> GetPwd();
        void RegisterUser(User user);
        User GetUser(string? email);
    }
}