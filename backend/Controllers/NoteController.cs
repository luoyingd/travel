using backend.Form;
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
        public R Add(AddNoteForm addNoteForm, [FromHeader(Name = "UserId")]int userId)
        {
            _noteService.Add(addNoteForm, userId);
            return R.OK();
        }

        [HttpPost("/note/info")]
        public R GetInfoList(SearchNoteForm searchNoteForm)
        {
            return R.OK(_noteService.GetNoteInfoList(searchNoteForm));
        }

        [HttpGet("/note/{id}")]
        public R GetInfo(int id, [FromHeader(Name = "UserId")]int userId)
        {
            return R.OK(_noteService.GetNoteInfo(id, userId));
        }

        [HttpPost("/note/recommendation")]
        public R GetRecommendation(SearchRecommendationForm searchRecommendationForm)
        {
            return R.OK(_noteService.GetRecommendation(searchRecommendationForm));
        }
    }
}