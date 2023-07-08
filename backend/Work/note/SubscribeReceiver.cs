namespace backend.Work.Note
{
    public class SubscribeReceiver
    {
        public void SendMail(object sender, EventArgs e)
        {
            SubscribePublisher publisher = (SubscribePublisher)sender;
            SubscribeWork work = (SubscribeWork)e;
            Console.WriteLine($"{_email}收到{publisher.SenderEmail}的新note, 新的note是{work.NewNote.Title}");
        }
        private string _email;
        public SubscribeReceiver(string email)
        {
            this._email = email;
        }
    }
}