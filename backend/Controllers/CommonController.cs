using System;
using System.Security.AccessControl;
using backend.Form;
using backend.Repository.Common;
using backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IPasswordRepository _passwordRepository;
        public CommonController(IPasswordRepository passwordRepository)
        {
            _passwordRepository = passwordRepository;
        }

        [HttpPost("/common/upload")]
        public async Task<R> Upload(IFormFile file)
        {
            string key = Guid.NewGuid() + ".png";
            var filePath = Path.Combine(Constant.Constant.BASE_DIR, key);
            await FileUtil.SaveFile(filePath, file);
            await FileUtil.WritingAnObjectAsync(key, filePath, _passwordRepository);
            // delete file

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