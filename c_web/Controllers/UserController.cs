using System.Security.Cryptography;
using c_web.Form;
using c_web.Models;
using c_web.Repository;
using c_web.Utils;
using Microsoft.AspNetCore.Mvc;

namespace c_web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public Guid InstanceID { get; private set; }
        public UserController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpGet("/pwd")]
        public IEnumerable<Password> GetPwd()
        {
            return _userRepository.GetPwd();
        }

        [HttpPost("/pwd")]
        public IActionResult AddPwd(Password password)
        {
            _userRepository.AddPwd(password);
            return Ok();
        }

        [HttpPost("/")]
        public IActionResult AddUser(UserRegisterForm userRegisterForm)
        {
            User user = new()
            {
                FirstName = userRegisterForm.FirstName,
                LastName = userRegisterForm.LastName,
                Email = userRegisterForm.Email
            };
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            byte[] bytes = new byte[128 / 8];
            randomNumberGenerator.GetNonZeroBytes(bytes);
            string salt = Convert.ToBase64String(bytes);
            user.Password = PasswordEncrypt.Encrypt(userRegisterForm.Password,
             _configuration, salt);
            user.Salt = salt;
            _userRepository.RegisterUser(user);
            return Ok();
        }

        [HttpPost("/login")]
        public IActionResult Login(UserLoginForm userLoginForm)
        {
            User user = _userRepository.GetUser(userLoginForm.Email);
            string? salt = user.Salt;
            string? password = user.Password;
            Console.WriteLine(PasswordEncrypt.Encrypt(userLoginForm.Password, _configuration, salt));
            return Ok();
        }
    }
}