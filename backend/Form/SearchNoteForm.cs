using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Form
{
    public class SearchNoteForm
    {
        private int _filter;
        private string? _keyWord;
        private int _offset;
        private int _size;
        private string? _category;
        private int _userId;

        public int Filter { get => _filter; set => _filter = value; }
        public string? KeyWord { get => _keyWord; set => _keyWord = value; }
        public int Offset { get => _offset; set => _offset = value; }
        public int Size { get => _size; set => _size = value; }
        public string? Category { get => _category; set => _category = value; }
        public int UserId { get => _userId; set => _userId = value; }
    }
}