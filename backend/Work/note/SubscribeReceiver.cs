namespace backend.Work.Note
{
    public class SubscribeReceiver
    {
        public void SendMail(object sender, EventArgs e)
        {
            SubscribePublisher publisher = (SubscribePublisher)sender;
            SubscribeWork work = (SubscribeWork)e;
            // TODO: send mail
            Console.WriteLine(@$"{_email}收到{publisher.SenderEmail}的新note, 新的note是{work.NewNote.Title}, 
            {work.NewNote.Id}");
        }
        private string _email;
        public SubscribeReceiver(string email)
        {
            this._email = email;
        }
    }
}