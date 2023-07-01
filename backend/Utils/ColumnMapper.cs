using backend.Models;
using Dapper;

namespace backend.Utils
{
    public class ColumnMapper
    {
        public static void SetMapper()
        {
            // you need to register every model here
            SqlMapper.SetTypeMap(typeof(Password), new ColumnAttributeTypeMapper<Password>());
            SqlMapper.SetTypeMap(typeof(User), new ColumnAttributeTypeMapper<User>());
            SqlMapper.SetTypeMap(typeof(Note), new ColumnAttributeTypeMapper<Note>());
            SqlMapper.SetTypeMap(typeof(Like), new ColumnAttributeTypeMapper<Like>());
        }
    }
}