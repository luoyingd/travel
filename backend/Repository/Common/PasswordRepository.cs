using backend.Data;
using backend.Models;

namespace backend.Repository.Common
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly DapperContext _dapperContext;
        public PasswordRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public Password GetAwsPassword()
        {
            string sql = "select [client_id], [client_key] from [tb_password] where id = 1";
            IEnumerable<Password> passwords = _dapperContext.QueryData<Password>(sql, null);
            return passwords.FirstOrDefault();
        }

        public string GetEmailPwd()
        {
            string sql = "select [email_pwd] from [tb_password] where id = 1";
            IEnumerable<string> passwords = _dapperContext.QueryData<string>(sql, null);
            return passwords.FirstOrDefault();
        }

        public string GetGoogleApi()
        {
            string sql = "select [google_api] from [tb_password] where id = 1";
            IEnumerable<string> passwords = _dapperContext.QueryData<string>(sql, null);
            return passwords.FirstOrDefault();
        }
    }
}