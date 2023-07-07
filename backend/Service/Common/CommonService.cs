using System.Text.Encodings.Web;
using backend.Response.VO.Map;
using backend.Utils;
using backend.Repository.Common;
using backend.Exceptions;
using Newtonsoft.Json;

namespace backend.Service.Common
{
    public class CommonService : ICommonService
    {
        private readonly IPasswordRepository _passwordRepository;
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        public CommonService(IConfiguration configuration, IPasswordRepository passwordRepository,
        ILogger<CommonService> logger, HttpClient httpClient)
        {
            _passwordRepository = passwordRepository;
            _logger = logger;
            _httpClient = httpClient;
        }
        public async Task<string> Upload(IFormFile formFile, FileUtil fileUtil)
        {
            string key = Guid.NewGuid() + ".png";
            var filePath = Path.Combine(Constant.Constant.BASE_DIR, key);
            await fileUtil.SaveFile(filePath, formFile);
            await fileUtil.WritingAnObjectAsync(key, filePath);
            // delete file
            System.IO.File.Delete(filePath);
            return key;
        }

        public List<MapResVO> GetMapResult(string input)
        {
            List<MapResVO> list = new();
            if (input.Length == 0)
            {
                return list;
            }
            string encodeInput = UrlEncoder.Create().Encode(input);
            _logger.LogInformation("encodeInput input: {}", encodeInput);
            string mapApi = _passwordRepository.GetGoogleApi();
            var response = _httpClient.GetStringAsync(Constant.Constant.GOOGLE_ADDRESS_URL +
                    encodeInput +
                    "&types=geocode&key=" + mapApi) ?? throw new CustomException(CodeAndMsg.PARAM_VERIFICATION_FAIL);
            if (response != null)
            {
                MapResult mapResult = JsonConvert.DeserializeObject<MapResult>(response.Result);
                List<Address> addresses = mapResult.Predictions;
                addresses.ForEach(address =>
                {
                    MapResVO mapResVO = new MapResVO()
                    {
                        Address = address.Description,
                        Code = address.Place_Id
                    };
                    list.Add(mapResVO);
                });
            }
            return list;
        }

    }

    class MapResult
    {
        private List<Address> predictions = new List<Address>();
        [JsonProperty("predictions")]
        public List<Address> Predictions { get => predictions; set => predictions = value; }
    }

    class Address
    {
        private string? place_id;
        private string? description;

        [JsonProperty("place_id")]
        public string? Place_Id { get => place_id; set => place_id = value; }
        [JsonProperty("description")]
        public string? Description { get => description; set => description = value; }
    }
}