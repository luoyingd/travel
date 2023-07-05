using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Repository.Like
{
    public interface ILikeRepository
    {
        Models.Like GetLike(int noteId, int userId);

        void UpdateLike(int like, int noteId, int userId, int originalLike);

        void InsertLike(int like, int noteId, int userId, int originalLike);
    }
}