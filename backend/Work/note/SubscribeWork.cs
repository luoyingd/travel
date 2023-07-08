using backend.Models;
using backend.Response.VO.Note;

namespace backend.Work.Note
{
    public class SubscribeWork : EventArgs
    {
        private NoteInfoVO _noteInfoVO;

        public SubscribeWork(NoteInfoVO noteInfoVO)
        {
            _noteInfoVO = noteInfoVO;
        }

        public NoteInfoVO NewNote { get => _noteInfoVO; set => _noteInfoVO = value; }
    }
}