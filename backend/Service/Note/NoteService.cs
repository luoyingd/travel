using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Exceptions;
using backend.Form;
using backend.Repository.Note;
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
    }
}