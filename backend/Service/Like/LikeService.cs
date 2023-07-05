using System.Data;
using backend.Repository.Like;
using backend.Repository.Note;
using backend.Utils;

namespace backend.Service.Like
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly LockObj _lockObj;
        private readonly INoteRepository _noteRepository;

        public LikeService(ILikeRepository likeRepository, LockObj lockObj, 
        INoteRepository noteRepository)
        {
            _likeRepository = likeRepository;
            _lockObj = lockObj;
            _noteRepository = noteRepository;
        }

        public void DoLike(int like, int noteId, int userId)
        {
            lock (_lockObj)
            {
                // get original like
                int originalLike = _noteRepository.GetLikeCount(noteId);
                // see if has like status
                Models.Like likeStatus = _likeRepository.GetLike(noteId, userId);
                if (likeStatus != null)
                {
                    // update
                    _likeRepository.UpdateLike(like, noteId, userId, originalLike);
                }
                else
                {
                    // insert
                    _likeRepository.InsertLike(like, noteId, userId, originalLike);
                }
            }
        }

        public bool GetLikeStatus(int noteId, int userId)
        {
            Models.Like like = _likeRepository.GetLike(noteId, userId);
            return like != null && like.Status == 1;
        }
    }
}