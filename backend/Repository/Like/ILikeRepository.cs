using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Repository.Like
{
    public interface ILikeRepository
    {
        Models.Like GetLike(int noteId, int userId);
    }
}