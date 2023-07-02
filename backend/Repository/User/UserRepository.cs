using backend.Data;
using backend.Models;
using Dapper;

namespace backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _dapperContext;
        public UserRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public User GetUser(string? email)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("email", email);
            string sql = "select * from tb_user where email = @email";
            return _dapperContext.QueryData<User>(sql, dynamicParameters).FirstOrDefault();
        }

        public void RegisterUser(User user)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("firstName", user.FirstName);
            dynamicParameters.Add("lastName", user.LastName);
            dynamicParameters.Add("email", user.Email);
            dynamicParameters.Add("password", user.Password);
            dynamicParameters.Add("salt", user.Salt);
            string sql = @"insert into [tb_user] 
            ([first_name], [last_name], [email], [password], [salt])
             values (@firstName, @lastName, @email, @password, @salt)";
            _dapperContext.Execute(sql, dynamicParameters);
        }
    }
}