using c_web.Models;
using Dapper;

namespace c_web.Utils
{
    public class ColumnMapper
    {
        public static void SetMapper()
        {
            // you need to register every model here
            SqlMapper.SetTypeMap(typeof(Password), new ColumnAttributeTypeMapper<Password>());
        }
    }
}