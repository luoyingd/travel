using Microsoft.Data.SqlClient;
using Dapper;

namespace backend.Data
{
    public class DapperContext
    {
        private readonly SqlConnection _connection;

        public DapperContext(IConfiguration configuration)
        {
            _connection = new SqlConnection(configuration.GetConnectionString("db_server"));
        }

        public IEnumerable<T> QueryData<T>(string sql, DynamicParameters? dynamicParameters)
        {
            return _connection.Query<T>(sql, dynamicParameters);
        }

        public void Execute(string sql, DynamicParameters? dynamicParameters)
        {
            _connection.Execute(sql, dynamicParameters);
        }


    }
}