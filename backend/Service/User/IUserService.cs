using backend.Form;
using backend.Response.VO.User;

namespace backend.Service.User
{
    public interface IUserService
    {
        void RegisterUser(UserRegisterForm userRegisterForm);

        UserLoginVO Login(UserLoginForm userLoginForm);
    }
}