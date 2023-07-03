using backend.Data;
using backend.Enums.Note;
using backend.Form;
using backend.Response.VO.Note;
using Dapper;
using Microsoft.IdentityModel.Tokens;

namespace backend.Repository.Note
{
    public class NoteRepository : INoteRepository
    {
        private readonly DapperContext _dapperContext;
        public NoteRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public void AddNote(Models.Note note)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("userId", note.UserId);
            dynamicParameters.Add("content", note.Content);
            dynamicParameters.Add("category", note.Category);
            dynamicParameters.Add("likes", 0);
            dynamicParameters.Add("addressCode", note.AddressCode);
            dynamicParameters.Add("address", note.Address);
            dynamicParameters.Add("photos", note.Photos);
            dynamicParameters.Add("title", note.Title);
            string sql = @"insert into [tb_note] 
            ([user_id], [content], [title], [category], [likes],
            [address_code], [address], [photos])
             values (@userId, @content, @title, @category, @likes, @addressCode, @address, @photos)";
            _dapperContext.Execute(sql, dynamicParameters);
        }

        public NoteInfoVO GetNoteInfo(int id)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("id", id);
            string sql = @"select n.title as title, n.photos as photos, 
            n.likes as likes, n.content as content,
            u.first_name as firstName, u.last_name as lastName,
            u.id as authorId,
            n.address as address, n.address_code as addressCode 
            from [tb_note] as n, [tb_user] as u
            where n.id = @id and n.user_id = u.id";
            return _dapperContext.QueryData<NoteInfoVO>(sql, dynamicParameters).FirstOrDefault();
        }

        public IEnumerable<NoteInfoVO> GetNoteInfoList(SearchNoteForm searchNoteForm)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("offset", searchNoteForm.Offset);
            dynamicParameters.Add("size", searchNoteForm.Size);
            dynamicParameters.Add("category", searchNoteForm.Category);
            string sql = @"select n.id as id, n.title as title, n.photos as photos, 
            n.likes as likes,
            n.address as address, n.address_code as addressCode 
            from [tb_note] as n join [tb_user] as u
            on n.user_id = u.id where n.category = @category ";
            if (!searchNoteForm.KeyWord.IsNullOrEmpty())
            {
                dynamicParameters.Add("keyWord", "%" + searchNoteForm.KeyWord + "%");
                sql += @"and (n.title like @keyWord 
                or n.content like @keyWord 
                or n.address like @keyWord
                or u.first_name like @keyWord
                or u.last_name like @keyWord) ";
            }
            if (searchNoteForm.UserId != 0)
            {
                dynamicParameters.Add("userId", searchNoteForm.UserId);
                sql += "and n.user_id = @userId  ";
            }
            if (searchNoteForm.Filter == (int)NoteFilterTypeEnum.HOT)
            {
                sql += "order by n.likes desc ";
            }
            else
            {
                sql += "order by n.create_time desc ";
            }
            sql += "offset @offset row fetch next @size row only";
            return _dapperContext.QueryData<NoteInfoVO>(sql, dynamicParameters);
        }

        public int GetNoteListTotal(SearchNoteForm searchNoteForm)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("category", searchNoteForm.Category);
            string sql = @"select count(n.id) from [tb_note] as n join [tb_user] as u 
            on n.user_id = u.id where n.category = @category ";
            if (!searchNoteForm.KeyWord.IsNullOrEmpty())
            {
                dynamicParameters.Add("keyWord", "%" + searchNoteForm.KeyWord + "%");
                sql += @"and (n.title like @keyWord 
                or n.content like @keyWord 
                or n.address like @keyWord
                or u.first_name like @keyWord
                or u.last_name like @keyWord) ";
            }
            if (searchNoteForm.UserId != 0)
            {
                dynamicParameters.Add("userId", searchNoteForm.UserId);
                sql += "and n.user_id = @userId  ";
            }
            return _dapperContext.QueryData<int>(sql, dynamicParameters).FirstOrDefault();
        }
    }
}