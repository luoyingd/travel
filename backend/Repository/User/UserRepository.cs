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

        public DateTime GetResetTokenTime(string? email)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("email", email);
            string sql = "select [create_time] from tb_reset_token where email = @email";
            return _dapperContext.QueryData<DateTime>(sql, dynamicParameters).FirstOrDefault();
        }

        public User GetUser(string? email)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("email", email);
            string sql = "select * from tb_user where email = @email";
            return _dapperContext.QueryData<User>(sql, dynamicParameters).FirstOrDefault();
        }

        public void InsertResetToken(ResetToken resetToken)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("email", resetToken.Email);
            dynamicParameters.Add("token", resetToken.Token);
            dynamicParameters.Add("createTime", resetToken.CreateTime);
            string sql = @"insert into tb_reset_token (email, token, create_time)
            values (@email, @token, @createTime)";
            _dapperContext.Execute(sql, dynamicParameters);
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

        public void UpdateResetToken(ResetToken resetToken)
        {
             DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("email", resetToken.Email);
            dynamicParameters.Add("token", resetToken.Token);
            dynamicParameters.Add("createTime", resetToken.CreateTime);
            string sql = @"update tb_reset_token set token = @token, 
            create_time = @createTime 
            where email = @email";
            _dapperContext.Execute(sql, dynamicParameters);
        }
    }
}