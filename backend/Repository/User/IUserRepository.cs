using backend.Models;

namespace backend.Repository
{
    public interface IUserRepository
    {
        void RegisterUser(User user);
        User GetUser(string? email);
        ResetToken GetResetToken(string? email);
        void InsertResetToken(ResetToken resetToken);
        void UpdateResetToken(ResetToken resetToken);
        void UpdateUserPassword(User user);
    }
}