using backend.Utils;

namespace backend.Models
{
    public class Like
    {
        private int _id;
        private int _userId;
        private int _noteId;
        private byte _status;

        [Column(Name = "id")]
        public int Id { get => _id; set => _id = value; }
        [Column(Name = "user_id")]
        public int UserId { get => _userId; set => _userId = value; }
        [Column(Name = "note_id")]
        public int NoteId { get => _noteId; set => _noteId = value; }
        [Column(Name = "status")]
        public byte Status { get => _status; set => _status = value; }
    }
}