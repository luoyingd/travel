using System.Text;
using backend.Exceptions;
using backend.Form;
using backend.Repository.Common;
using backend.Repository.Note;
using backend.Response.VO.Note;
using backend.Service.Like;
using backend.Service.User;
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
        private readonly ILikeService _likeService;
        private readonly IUserService _userService;
        public NoteService(INoteRepository noteRepository, ILogger<NoteService> logger,
        IPasswordRepository passwordRepository, HttpClient httpClient,
        ILikeService likeService, IUserService userService)
        {
            _logger = logger;
            _noteRepository = noteRepository;
            _passwordRepository = passwordRepository;
            _httpClient = httpClient;
            _likeService = likeService;
            _userService = userService;
        }

        public void Add(AddNoteForm addNoteForm, int userId)
        {
            if (addNoteForm.Address.IsNullOrEmpty()
                || addNoteForm.AddressCode.IsNullOrEmpty()
                || addNoteForm.Description.IsNullOrEmpty()
                || addNoteForm.Title.IsNullOrEmpty()
                || addNoteForm.Category.IsNullOrEmpty())
            {
                throw new CustomException(CodeAndMsg.PARAM_VERIFICATION_FAIL);
            }
            string[] address = addNoteForm.Address.Split(", ");
            string country = address[address.Length - 1];
            Models.Note note = new()
            {
                Address = addNoteForm.Address,
                Content = addNoteForm.Description,
                Title = addNoteForm.Title,
                AddressCode = addNoteForm.AddressCode,
                Category = addNoteForm.Category,
                UserId = userId,
                Country = country
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

            // publish to all subscribers
            _userService.OnPublishNewNote(note, userId);
        }

        public NoteInfoVO GetNoteInfo(int id, int userId)
        {
            NoteInfoVO noteInfoVO = _noteRepository.GetNoteInfo(id);
            string key = _passwordRepository.GetGoogleApi();
            string url = Constant.Constant.GOOGLE_MAP_URL
            + noteInfoVO.AddressCode + "&key=" + key;
            var response = _httpClient.GetStringAsync(url);
            if (response != null)
            {
                MapResult mapResult = JsonConvert.DeserializeObject<MapResult>(response.Result);
                noteInfoVO.AddressCode = mapResult.Result.Url;
            }
            else
            {
                noteInfoVO.AddressCode = null;
            }
            noteInfoVO.IsLiked = _likeService.GetLikeStatus(id, userId);
            noteInfoVO.IsSubscribed = _userService.GetUserSubscribe(new Models.UserSubscribe()
            {
                UserId = userId,
                AuthorId = noteInfoVO.AuthorId
            }) != null;
            return noteInfoVO;
        }

        public NoteListVO GetNoteInfoList(SearchNoteForm searchNoteForm)
        {
            searchNoteForm.Offset = (searchNoteForm.Offset - 1) * searchNoteForm.Size;
            IEnumerable<NoteInfoVO> noteInfoVOs = _noteRepository.GetNoteInfoList(searchNoteForm);
            int total = _noteRepository.GetNoteListTotal(searchNoteForm);
            return new NoteListVO() { Notes = noteInfoVOs, Total = total };
        }

        public List<NoteInfoVO> GetRecommendation(SearchRecommendationForm searchRecommendationForm)
        {
            List<NoteInfoVO> result = new List<NoteInfoVO>();
            // search hottest based on address
            string[] address = searchRecommendationForm.Address.Split(", ");
            string country = address[address.Length - 1];
            IEnumerable<NoteInfoVO> hotNoteByCountryAndCategory = _noteRepository
            .GetHotNoteByCountryAndCategory(searchRecommendationForm.Id, country, searchRecommendationForm.Category);
            List<int> curIds = new List<int>();
            curIds.Add(searchRecommendationForm.Id);
            foreach (NoteInfoVO noteInfoVO in hotNoteByCountryAndCategory)
            {
                result.Add(noteInfoVO);
                curIds.Add(noteInfoVO.Id);
            }
            if (hotNoteByCountryAndCategory.Count() < 3)
            {
                int left = 3 - hotNoteByCountryAndCategory.Count();
                IEnumerable<NoteInfoVO> hotNoteByAuthorOrCategory = _noteRepository
            .GetHotNoteByAuthorOrCategory(searchRecommendationForm.AuthorId,
            searchRecommendationForm.Category, left, curIds);
                foreach (NoteInfoVO noteInfoVO in hotNoteByAuthorOrCategory)
                {
                    result.Add(noteInfoVO);
                }
            }
            return result;
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