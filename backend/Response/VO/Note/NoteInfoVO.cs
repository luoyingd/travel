using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Response.VO.Note
{
    public class NoteInfoVO
    {
        private int _id;
        private string? _title;
        private string? _photos;
        private string? _address;
        private string? _addressCode;
        private int _likes;
        private string? _content;
        private string? _firstName;
        private string? _lastName;

        public int Id { get => _id; set => _id = value; }
        public string? Title { get => _title; set => _title = value; }
        public int Likes { get => _likes; set => _likes = value; }
        public string? Content { get => _content; set => _content = value; }
        public string? FirstName { get => _firstName; set => _firstName = value; }
        public string? LastName { get => _lastName; set => _lastName = value; }
        public string? Photos { get => _photos; set => _photos = value; }
        public string? Address { get => _address; set => _address = value; }
        public string? AddressCode { get => _addressCode; set => _addressCode = value; }
    }
}