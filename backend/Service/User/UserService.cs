using Microsoft.IdentityModel.Tokens;
using backend.Form;
using backend.Repository;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using backend.Utils;
using backend.Response.VO.User;
using backend.Exceptions;

namespace backend.Service.User
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public UserService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public UserLoginVO Login(UserLoginForm userLoginForm)
        {
            Models.User user = _userRepository.GetUser(userLoginForm.Email);
            string? salt = user.Salt;
            // TODO
            Console.WriteLine(PasswordEncrypt.Encrypt(userLoginForm.Password, _configuration, salt));
            // return a token
            string token = GetToken(user.Id);
            UserLoginVO userLoginVO = new()
            {
                UserId = user.Id,
                Token = token
            };
            return userLoginVO;
        }

        public void RegisterUser(UserRegisterForm userRegisterForm)
        {
            Models.User user = _userRepository.GetUser(userRegisterForm.Email);
            if (user != null)
            {
                throw new CustomException(CodeAndMsg.USER_EXIST);
            }
            user = new()
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
        }

        private string GetToken(int userId)
        {
            Claim[] claims = new Claim[]{
                new Claim("userId", userId.ToString())
            };
            SymmetricSecurityKey symmetricSecurityKey = new(
                Encoding
                .UTF8.GetBytes(_configuration.GetSection("AppSettings:token_key").Value)
            );
            SigningCredentials signingCredentials = new(
                symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature
            );
            SecurityTokenDescriptor securityTokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = signingCredentials,
                Expires = DateTime.Now.AddHours(2)
            };
            JwtSecurityTokenHandler securityTokenHandler = new();
            SecurityToken securityToken = securityTokenHandler.CreateToken(securityTokenDescriptor);
            return securityTokenHandler.WriteToken(securityToken);
        }
    }
}