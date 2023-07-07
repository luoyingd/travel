using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

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

        public void ExecuteMultiple(string[] sqls, DynamicParameters[] dynamicParameters)
        {
            _connection.Open();
            IDbTransaction transaction = _connection.BeginTransaction();
            try
            {
                for (int j = 0; j < sqls.Count(); j++)
                {
                    _connection.Execute(sqls[j], dynamicParameters[j], transaction);
                }
                transaction.Commit();
            }
            catch (Exception exception)
            {
                transaction.Rollback();
            }

        }


    }
}