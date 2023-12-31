using backend.Models;
using backend.Response.VO.Note;

namespace backend.Work.Note
{
    public class SubscribePublisher
    {
        public event EventHandler? onReceiveNewPost;

        private string _senderEmail;

        public string SenderEmail { get => _senderEmail; set => _senderEmail = value; }

        public SubscribePublisher(string senderEmail)
        {
            SenderEmail = senderEmail;
        }

        public void ReceivePost(SubscribeWork[] works)
        {
            if (onReceiveNewPost != null)
            {
                foreach (SubscribeWork work in works)
                {
                    onReceiveNewPost(this, work);
                }
            }
        }
        public SubscribeWork SetWork(NoteInfoVO noteInfoVO)
        {
            SubscribeWork work = new(noteInfoVO);
            return work;
        }
    }
}