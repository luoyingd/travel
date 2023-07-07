using backend.Repository.Common;
using backend.Service.Common;
using backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly FileUtil _fileUtil;
        private readonly ICommonService _commonService;
        public CommonController(ICommonService commonService, 
        IPasswordRepository passwordRepository)
        {
            _fileUtil = new(passwordRepository);
            _commonService = commonService;
        }

        [HttpPost("/common/upload")]
        public async Task<R> Upload(IFormFile file)
        {
            string key = await _commonService.Upload(file, _fileUtil);
            return R.OK(key);
        }

        [HttpGet("/common/photo/{key}")]
        [AllowAnonymous]
        public async Task<ActionResult> Photo(string key)
        {
            byte[] bytes = await _fileUtil.ReadObjectDataAsync(key);
            return File(bytes, "image/png");
        }

        [HttpGet("/common/getMapResult/{input}")]
        public R getMapResult(string input)
        {
            return R.OK(_commonService.GetMapResult(input));
        }
    }
}