using System.Data;
using backend.Data;
using Dapper;

namespace backend.Repository.Like
{
    public class LikeRepository : ILikeRepository
    {
        private readonly DapperContext _dapperContext;
        public LikeRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public Models.Like GetLike(int noteId, int userId)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("userId", userId);
            dynamicParameters.Add("noteId", noteId);
            string sql = @"select status from tb_like where note_id = @noteId and user_id = @userId";
            return _dapperContext.QueryData<Models.Like>(sql, dynamicParameters).FirstOrDefault();
        }

        public void InsertLike(int like, int noteId, int userId, int originalLike)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("userId", userId);
            dynamicParameters.Add("noteId", noteId);
            dynamicParameters.Add("status", like);
            string sql = @"insert into tb_like (status, note_id, user_id) 
            values (@status, @noteId, @userId)";

            DynamicParameters dynamicParameters2 = new();
            dynamicParameters2.Add("id", noteId);
            dynamicParameters2.Add("likes", like == 0 ? originalLike : originalLike + 1);
            string sql2 = @"update tb_note set likes = @likes where id = @id";
            _dapperContext.ExecuteMultiple(new string[] { sql, sql2 },
            new DynamicParameters[] { dynamicParameters, dynamicParameters2 });
        }

        public void UpdateLike(int like, int noteId, int userId, int originalLike)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("userId", userId);
            dynamicParameters.Add("noteId", noteId);
            dynamicParameters.Add("status", like);
            string sql = @"update tb_like set status = @status 
            where note_id = @noteId and user_id = @userId";

            DynamicParameters dynamicParameters2 = new();
            dynamicParameters2.Add("id", noteId);
            dynamicParameters2.Add("likes", like == 0 ? originalLike - 1 : originalLike + 1);
            string sql2 = @"update tb_note set likes = @likes where id = @id";
            _dapperContext.ExecuteMultiple(new string[] { sql, sql2 },
            new DynamicParameters[] { dynamicParameters, dynamicParameters2 });
        }
    }
}