using backend.Form;
using backend.Repository.Note;
using backend.Service.Note;
using backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }
        [HttpPost("/note")]
        public R Add(AddNoteForm addNoteForm)
        {
            _noteService.Add(addNoteForm);
            return R.OK();
        }

        [HttpPost("/note/info")]
        [AllowAnonymous]
        public R GetInfoList(SearchNoteForm searchNoteForm)
        {
            return R.OK(_noteService.GetNoteInfoList(searchNoteForm));
        }
    }
}