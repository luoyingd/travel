using backend.Utils;

namespace backend.Models
{
    public class Note
    {
        private int _id;
        private int _userId;
        private string? _content;
        private string? _category;
        private int _likes;
        private string? _addressCode;
        private string? _address;
        private string? _photos;
        private string? title;

        [Column(Name = "id")]
        public int Id { get => _id; set => _id = value; }
        [Column(Name = "user_id")]
        public int UserId { get => _userId; set => _userId = value; }
        [Column(Name = "content")]
        public string? Content { get => _content; set => _content = value; }
        [Column(Name = "category")]
        public string? Category { get => _category; set => _category = value; }
        [Column(Name = "likes")]
        public int Likes { get => _likes; set => _likes = value; }
        [Column(Name = "address_code")]
        public string? AddressCode { get => _addressCode; set => _addressCode = value; }
        [Column(Name = "address")]
        public string? Address { get => _address; set => _address = value; }
        [Column(Name = "photos")]
        public string? Photos { get => _photos; set => _photos = value; }
        public string? Title { get => title; set => title = value; }
    }
}