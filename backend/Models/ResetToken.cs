using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Utils;

namespace backend.Models
{
    public class ResetToken
    {
        private int _id;
        private string? _email;
        private string? _token;
        private DateTime _createTime;

        public int Id { get => _id; set => _id = value; }
        [Column(Name = "email")]
        public string? Email { get => _email; set => _email = value; }
        [Column(Name = "token")]
        public string? Token { get => _token; set => _token = value; }
        [Column(Name = "create_time")]
        public DateTime CreateTime { get => _createTime; set => _createTime = value; }
    }
}