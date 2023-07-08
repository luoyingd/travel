using backend.Form;
using backend.Models;
using backend.Response.VO.Note;
using backend.Response.VO.User;
using backend.Utils;

namespace backend.Service.User
{
    public interface IUserService
    {
        void RegisterUser(UserRegisterForm userRegisterForm);
        UserLoginVO Login(UserLoginForm userLoginForm);
        void SendResetMail(string email, MailUtil mailUtil);
        void ResetPassword(ResetPasswordForm resetPasswordForm);
        void Subscribe(UserSubscribeForm subscribeForm, int userId);
        UserSubscribe GetUserSubscribe(UserSubscribe userSubscribe);
        void OnPublishNewNote(NoteInfoVO noteInfoVO, int senderId);
    }
}