using backend.Models;

namespace backend.Repository
{
    public interface IUserRepository
    {
        void RegisterUser(User user);
        User GetUser(string? email);
        User GetUserById(int id);
        ResetToken GetResetToken(string? email);
        void InsertResetToken(ResetToken resetToken);
        void UpdateResetToken(ResetToken resetToken);
        void UpdateUserPassword(User user);
        UserSubscribe GetUserSubscribe(UserSubscribe userSubscribe);
        void InsertUserSubscribe(UserSubscribe userSubscribe);
        void DeleteUserSubscribe(UserSubscribe userSubscribe);
        IEnumerable<string> getSubscribeEmails(int authorId);
    }
}