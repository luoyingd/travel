using System.Text;
using backend.Exceptions;
using backend.Form;
using backend.Repository.Common;
using backend.Repository.Note;
using backend.Response.VO.Note;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace backend.Service.Note
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly ILogger _logger;
        private readonly IPasswordRepository _passwordRepository;
        private readonly HttpClient _httpClient;
        public NoteService(INoteRepository noteRepository, ILogger<NoteService> logger,
        IPasswordRepository passwordRepository, HttpClient httpClient)
        {
            _logger = logger;
            _noteRepository = noteRepository;
            _passwordRepository = passwordRepository;
            _httpClient = httpClient;
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

        public NoteInfoVO GetNoteInfo(int id)
        {
            NoteInfoVO noteInfoVO = _noteRepository.GetNoteInfo(id);
            string key = _passwordRepository.GetGoogleApi();
            string url = Constant.Constant.GOOGLE_MAP_URL
            + noteInfoVO.AddressCode + "&key=" + key;
            var response = _httpClient.GetStringAsync(url);
            _logger.LogInformation("google map response: {}", response.Result);
            if (response != null)
            {
                MapResult mapResult = JsonConvert.DeserializeObject<MapResult>(response.Result);
                noteInfoVO.AddressCode = mapResult.Result.Url;
            }
            else
            {
                noteInfoVO.AddressCode = null;
            }
            return noteInfoVO;
        }

        public NoteListVO GetNoteInfoList(SearchNoteForm searchNoteForm)
        {
            searchNoteForm.Offset = (searchNoteForm.Offset - 1) * searchNoteForm.Size;
            IEnumerable<NoteInfoVO> noteInfoVOs = _noteRepository.GetNoteInfoList(searchNoteForm);
            int total = _noteRepository.GetNoteListTotal(searchNoteForm);
            return new NoteListVO() { Notes = noteInfoVOs, Total = total };
        }
    }

    class MapResult
    {
        private Address? result;

        public Address? Result { get => result; set => result = value; }
    }

    class Address
    {
        private string? _url;

        [JsonProperty("url")]
        public string? Url { get => _url; set => _url = value; }
    }
}