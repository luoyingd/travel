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
        public CommonController(FileUtil fileUtil)
        {
            _fileUtil = fileUtil;
        }

        [HttpPost("/common/upload")]
        public async Task<R> Upload(IFormFile file)
        {
            string key = Guid.NewGuid() + ".png";
            var filePath = Path.Combine(Constant.Constant.BASE_DIR, key);
            await _fileUtil.SaveFile(filePath, file);
            await _fileUtil.WritingAnObjectAsync(key, filePath);
            // delete file
            System.IO.File.Delete(filePath);
            return R.OK(key);
        }

        // [HttpGet("/common/photo/{key}")]
        // public async Task<R> Photo(string key)
        // {
        //     var filePath = Path.Combine(Constant.Constant.BASE_DIR, key);
        //     await FileUtil.SaveFile(filePath, file);
        //     await FileUtil.WritingAnObjectAsync(key, filePath, _passwordRepository);
        //     // delete file
            
        //     return R.OK(key);
        // }
    }
}