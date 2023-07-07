using backend.Exceptions;
using backend.Form;
using backend.Repository.Common;
using backend.Response.VO.User;
using backend.Service.User;
using backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPasswordRepository _passwordRepository;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, IConfiguration configuration,
        IPasswordRepository passwordRepository)
        {
            _userService = userService;
            _passwordRepository = passwordRepository;
            _configuration = configuration;
        }

        // allow no token for this api
        [AllowAnonymous]
        [HttpPost("/user/register")]
        public R Register(UserRegisterForm userRegisterForm)
        {
            _userService.RegisterUser(userRegisterForm);
            return R.OK();
        }

        [AllowAnonymous]
        [HttpPost("/user/login")]
        public R Login(UserLoginForm userLoginForm)
        {
            UserLoginVO userLoginVO = _userService.Login(userLoginForm);
            return R.OK(userLoginVO);
        }

        [AllowAnonymous]
        [HttpPost("/user/sendResetMail")]
        public R SendResetMail(UserLoginForm userLoginForm)
        {
            _userService.SendResetMail(userLoginForm.Email, new MailUtil(_passwordRepository, _configuration));
            return R.OK();
        }

        [AllowAnonymous]
        [HttpPost("/user/resetPassword")]
        public R ResetPassword(ResetPasswordForm resetPasswordForm)
        {
            _userService.ResetPassword(resetPasswordForm);
            return R.OK();
        }
    }
}