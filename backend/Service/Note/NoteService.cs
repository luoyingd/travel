using System.Text;
using backend.Exceptions;
using backend.Form;
using backend.Repository.Note;
using backend.Response.VO.Note;
using Microsoft.IdentityModel.Tokens;

namespace backend.Service.Note
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly ILogger _logger;
        public NoteService(INoteRepository noteRepository, ILogger<NoteService> logger)
        {
            _logger = logger;
            _noteRepository = noteRepository;
        }

        public void Add(AddNoteForm addNoteForm)
        {
            if (addNoteForm.Address.IsNullOrEmpty()
                || addNoteForm.AddressCode.IsNullOrEmpty()
                || addNoteForm.Description.IsNullOrEmpty()
                || addNoteForm.Title.IsNullOrEmpty()
                || addNoteForm.Category.IsNullOrEmpty())
            {
                throw new CustomException(CodeAndMsg.PARAM_VERIFICATION_FAIL);
            }
            Models.Note note = new()
            {
                Address = addNoteForm.Address,
                Content = addNoteForm.Description,
                Title = addNoteForm.Title,
                AddressCode = addNoteForm.AddressCode,
                Category = addNoteForm.Category,
                UserId = addNoteForm.UserId,

            };
            if (addNoteForm.PhotoKeys != null && addNoteForm.PhotoKeys.Length > 0)
            {
                StringBuilder keys = new StringBuilder();
                foreach (string key in addNoteForm.PhotoKeys)
                {
                    keys.Append(key).Append(",");
                }
                note.Photos = keys.ToString(0, keys.Length - 1);
            }
            _noteRepository.AddNote(note);
        }

        public NoteListVO GetNoteInfoList(SearchNoteForm searchNoteForm)
        {
            searchNoteForm.Offset = (searchNoteForm.Offset - 1) * searchNoteForm.Size;
            IEnumerable<NoteInfoVO> noteInfoVOs = _noteRepository.GetNoteInfoList(searchNoteForm);
            int total = _noteRepository.GetNoteListTotal(searchNoteForm);
            return new NoteListVO() { Notes = noteInfoVOs, Total = total };
        }
    }
}