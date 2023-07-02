using backend.Data;
using Dapper;

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
    }
}