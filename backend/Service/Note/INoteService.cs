using backend.Form;
using backend.Response.VO.Note;

namespace backend.Service.Note
{
    public interface INoteService
    {
        void Add(AddNoteForm addNoteForm);
        NoteListVO GetNoteInfoList(SearchNoteForm searchNoteForm);
        NoteInfoVO GetNoteInfo(int id);
    }
}