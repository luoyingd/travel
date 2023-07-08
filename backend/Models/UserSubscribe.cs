using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Utils;

namespace backend.Models
{
    public class UserSubscribe
    {
        private int _id;
        private int _userId;
        private int _authorId;

        public int Id { get => _id; set => _id = value; }
        [Column(Name = "user_id")]
        public int UserId { get => _userId; set => _userId = value; }
        [Column(Name = "author_id")]
        public int AuthorId { get => _authorId; set => _authorId = value; }
    }
}