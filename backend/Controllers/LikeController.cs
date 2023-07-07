using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Service.Like;
using backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    public class LikeController
    {
        private readonly ILikeService _likeService;
        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost("/like/{like}/{noteId}")]
        public R Like(int like, int noteId, [FromHeader(Name = "UserId")] int userId)
        {
            _likeService.DoLike(like, noteId, userId);
            return R.OK();
        }
    }
}