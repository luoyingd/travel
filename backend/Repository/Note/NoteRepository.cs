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

        public IEnumerable<NoteInfoVO> GetNoteInfoList(SearchNoteForm searchNoteForm)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("offset", searchNoteForm.Offset);
            dynamicParameters.Add("size", searchNoteForm.Size);
            dynamicParameters.Add("category", searchNoteForm.Category);
            string sql = @"select n.id as id, n.title as title, n.photos as photos, 
            n.likes as likes, n.content as content,
            u.first_name as firstName, u.last_name as lastName
            from [tb_note] as n, [tb_user] as u
            where n.user_id = u.id and n.category = @category ";
            if (!searchNoteForm.KeyWord.IsNullOrEmpty())
            {
                dynamicParameters.Add("keyWord", "%" + searchNoteForm.KeyWord + "%");
                sql += "and (n.title like @keyWord or n.content like @keyWord) ";
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
            string sql = "select count(id) from tb_note where category = @category ";
            if (!searchNoteForm.KeyWord.IsNullOrEmpty())
            {
                dynamicParameters.Add("keyWord", "%" + searchNoteForm.KeyWord + "%");
                sql += "and (title like @keyWord or content like @keyWord) ";
            }
            return _dapperContext.QueryData<int>(sql, dynamicParameters).FirstOrDefault();
        }
    }
}