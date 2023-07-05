using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Service.Like
{
    public interface ILikeService
    {
        bool GetLikeStatus(int noteId, int userId);

        void DoLike(int like, int noteId, int userId);
    }
}