using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Response.VO.Note
{
    public class NoteListVO
    {
        private int _total;
        private IEnumerable<NoteInfoVO>? _notes;

        public int Total { get => _total; set => _total = value; }
        public IEnumerable<NoteInfoVO> Notes { get => _notes; set => _notes = value; }
    }
}