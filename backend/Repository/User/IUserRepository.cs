using backend.Models;

namespace backend.Repository
{
    public interface IUserRepository
    {
        void RegisterUser(User user);
        User GetUser(string? email);
        DateTime GetResetTokenTime(string? email);
        void InsertResetToken(ResetToken resetToken);
        void UpdateResetToken(ResetToken resetToken);
    }
}