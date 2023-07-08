using backend.Models;

namespace backend.Work.Note
{
    public class SubscribeWork : EventArgs
    {
        private Models.Note _newNote;

        public SubscribeWork(Models.Note newNote)
        {
            _newNote = newNote;
        }

        public Models.Note NewNote { get => _newNote; set => _newNote = value; }
    }
}