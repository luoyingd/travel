using backend.Exceptions;
using backend.Form;
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
        public UserController(IUserService userService)
        {
            _userService = userService;
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
    }
}