using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Form
{
    public class UserSubscribeForm
    {
        private int _authorId;
        private int _subscribe;

        public int AuthorId { get => _authorId; set => _authorId = value; }
        public int Subscribe { get => _subscribe; set => _subscribe = value; }
    }
}