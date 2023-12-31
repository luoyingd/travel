using backend.Data;
using backend.Form;
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

        public ResetToken GetResetToken(string? email)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("email", email);
            string sql = "select [create_time], [token] from tb_reset_token where email = @email";
            return _dapperContext.QueryData<ResetToken>(sql, dynamicParameters).FirstOrDefault();
        }

        public User GetUser(string? email)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("email", email);
            string sql = "select * from tb_user where email = @email";
            return _dapperContext.QueryData<User>(sql, dynamicParameters).FirstOrDefault();
        }

        public void UpdateUserPassword(User user)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("email", user.Email);
            dynamicParameters.Add("password", user.Password);
            dynamicParameters.Add("salt", user.Salt);
            string sql = @"update tb_user set [password] = @password, [salt] = @salt 
            where email = @email";
            _dapperContext.Execute(sql, dynamicParameters);
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

        public UserSubscribe GetUserSubscribe(UserSubscribe userSubscribe)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("userId", userSubscribe.UserId);
            dynamicParameters.Add("authorId", userSubscribe.AuthorId);
            string sql = @"select id from tb_user_subscribe where user_id = @userId 
            and author_id = @authorId";
            return _dapperContext.QueryData<UserSubscribe>(sql, dynamicParameters).FirstOrDefault();
        }

        public void InsertUserSubscribe(UserSubscribe userSubscribe)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("userId", userSubscribe.UserId);
            dynamicParameters.Add("authorId", userSubscribe.AuthorId);
            string sql = @"insert into [tb_user_subscribe] 
            ([user_id], [author_id])
             values (@userId, @authorId)";
            _dapperContext.Execute(sql, dynamicParameters);
        }

        public void DeleteUserSubscribe(UserSubscribe userSubscribe)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("userId", userSubscribe.UserId);
            dynamicParameters.Add("authorId", userSubscribe.AuthorId);
            string sql = @"delete from [tb_user_subscribe] 
            where user_id = @userId 
            and author_id = @authorId";
            _dapperContext.Execute(sql, dynamicParameters);
        }

        public User GetUserById(int id)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("id", id);
            string sql = "select [email] from tb_user where id = @id";
            return _dapperContext.QueryData<User>(sql, dynamicParameters).FirstOrDefault();
        }

        public IEnumerable<string> getSubscribeEmails(int authorId)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("authorId", authorId);
            string sql = @"select u.email 
            from tb_user as u,  tb_user_subscribe as s
            where u.id = s.user_id and s.author_id = @authorId";
            return _dapperContext.QueryData<string>(sql, dynamicParameters);
        }
    }
}