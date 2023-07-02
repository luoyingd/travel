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
using Newtonsoft.Json;

namespace backend.Service.User
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        public UserService(IConfiguration configuration, IUserRepository userRepository,
        ILogger<UserService> logger, HttpClient httpClient)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _logger = logger;
            _httpClient = httpClient;
        }

        public UserLoginVO Login(UserLoginForm userLoginForm)
        {
            Models.User curUser;
            if (userLoginForm.IsFromGoogle)
            {
                if (userLoginForm.AccessToken.IsNullOrEmpty())
                {
                    throw new CustomException(CodeAndMsg.PARAM_VERIFICATION_FAIL);
                }
                var response = _httpClient.GetStringAsync(Constant.Constant.GOOGLE_INFO_URL + userLoginForm.AccessToken) ?? throw new CustomException(CodeAndMsg.PARAM_VERIFICATION_FAIL);
                _logger.LogInformation("Google Info response {response}",
                            response.Result);
                // check user status, if not exists, create new one
                GoogleUserResponse googleUserResponse =
                JsonConvert.DeserializeObject<GoogleUserResponse>(response.Result);
                UserRegisterForm userRegisterForm = new()
                {
                    Email = googleUserResponse.Email,
                    FirstName = googleUserResponse.Given_name,
                    LastName = googleUserResponse.Family_name
                };
                _logger.LogInformation("UserRegisterForm {email}, {FirstName}, {LastName}",
                           userRegisterForm.Email, userRegisterForm.FirstName,
                           userRegisterForm.LastName);
                Models.User user = _userRepository.GetUser(userRegisterForm.Email);
                if (user == null)
                {
                    userRegisterForm.Password = "000000";
                    RegisterUser(userRegisterForm);
                }
                curUser = _userRepository.GetUser(userRegisterForm.Email);
            }
            else
            {
                if (userLoginForm.Password.IsNullOrEmpty()
                    || userLoginForm.Email.IsNullOrEmpty())
                {
                    throw new CustomException(CodeAndMsg.PARAM_VERIFICATION_FAIL);
                }
                curUser = _userRepository.GetUser(userLoginForm.Email) ?? throw new CustomException(CodeAndMsg.USER_WRONG_EMAIL);
                string? salt = curUser.Salt;
                string pwd = PasswordEncrypt.Encrypt(userLoginForm.Password, _configuration, salt);
                if (pwd != curUser.Password)
                {
                    throw new CustomException(CodeAndMsg.USER_WRONG_PWD);
                }
            }
            // return a token
            string token = GetToken(curUser.Id);
            UserLoginVO userLoginVO = new()
            {
                UserId = curUser.Id,
                Token = token
            };
            return userLoginVO;
        }

        public void RegisterUser(UserRegisterForm userRegisterForm)
        {
            if (userRegisterForm.Email.IsNullOrEmpty() ||
            userRegisterForm.LastName.IsNullOrEmpty() ||
            userRegisterForm.FirstName.IsNullOrEmpty() ||
            userRegisterForm.Password.IsNullOrEmpty())
            {
                throw new CustomException(CodeAndMsg.PARAM_VERIFICATION_FAIL);
            }
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

        class GoogleUserResponse
        {
            private string? given_name;
            private string? family_name;
            private string? email;

            [JsonProperty("given_name")]
            public string? Given_name { get => given_name; set => given_name = value; }
            [JsonProperty("family_name")]
            public string? Family_name { get => family_name; set => family_name = value; }
            [JsonProperty("email")]
            public string? Email { get => email; set => email = value; }
        }
    }
}