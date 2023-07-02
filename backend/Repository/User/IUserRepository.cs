using backend.Models;

namespace backend.Repository
{
    public interface IUserRepository
    {
        void RegisterUser(User user);
        User GetUser(string? email);
    }
}