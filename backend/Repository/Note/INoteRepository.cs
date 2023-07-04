using backend.Form;
using backend.Response.VO.Note;

namespace backend.Repository.Note
{
    public interface INoteRepository
    {
        public void AddNote(Models.Note note);

        public IEnumerable<NoteInfoVO> GetNoteInfoList(SearchNoteForm searchNoteForm);

        public int GetNoteListTotal(SearchNoteForm searchNoteForm);

        public NoteInfoVO GetNoteInfo(int id);

        public IEnumerable<NoteInfoVO> GetHotNoteByCountryAndCategory(int id, string country, string category);
        public IEnumerable<NoteInfoVO> GetHotNoteByAuthorOrCategory(int authorId, 
        string category, int left, List<int> curIds);
    }
}