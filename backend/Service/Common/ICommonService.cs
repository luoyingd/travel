using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Response.VO.Map;
using backend.Utils;

namespace backend.Service.Common
{
    public interface ICommonService
    {
        public Task<string> Upload(IFormFile formFile, FileUtil fileUtil);

        public List<MapResVO> GetMapResult(string input);
    }
}