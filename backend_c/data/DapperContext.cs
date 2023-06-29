using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace backend_c.data
{
    public class DapperContext
    {
        private readonly SqlConnection _connection;

        public DapperContext(IConfigurationRoot configuration)
        {
            _connection = new SqlConnection(configuration.GetConnectionString("db_server"));
        }

        public IEnumerable<T> QueryData<T>(string sql)
        {
            return _connection.Query<T>(sql);
        }

        public void Execute(string sql)
        {
            _connection.Execute(sql);
        }

    }
}