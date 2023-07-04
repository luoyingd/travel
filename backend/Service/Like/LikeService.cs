using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Repository.Like;

namespace backend.Service.Like
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }
        public bool GetLikeStatus(int noteId, int userId)
        {
            Models.Like like = _likeRepository.GetLike(noteId, userId);
            return like != null && like.Status == 1;
        }
    }
}