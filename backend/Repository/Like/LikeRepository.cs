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
    }
}