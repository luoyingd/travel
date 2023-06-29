using c_web.Data;
using c_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace c_web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DapperContext _dapperContext;
        public UserController(IConfiguration config)
        {
            _dapperContext = new DapperContext(config);

        }

        [HttpGet("/pwd")]
        public IEnumerable<Password> GetPwd()
        {
            return _dapperContext.QueryData<Password>("select * from tb_password");
        }
    }
}