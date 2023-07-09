using backend.Utils;

namespace backend.Work.Note
{
    public class SubscribeReceiver
    {
        public void SendMail(object sender, EventArgs e)
        {
            SubscribePublisher publisher = (SubscribePublisher)sender;
            SubscribeWork work = (SubscribeWork)e;
            Console.WriteLine(@$"{_email}收到{publisher.SenderEmail}的新note, 新的note是{work.NewNote.Title}, 
            {work.NewNote.Id}, {work.NewNote.Address}, {work.NewNote.Photos}");
            // send mail
            Dictionary<string, string> parameters = new(){
                {"username", "Hi " + work.NewNote.FirstName + ","},
                {"my-title",work.NewNote.Title},
                {"src", work.NewNote.Photos != null && work.NewNote.Photos.Length > 0
                ? Constant.Constant.URL + "/common/photo/" + work.NewNote.Photos.Split(",")[0]
                : Constant.Constant.URL + "/common/photo/" + Constant.Constant.BLANK_KEY},
                {"href", Constant.Constant.INFO_HREF + work.NewNote.Id}
            };
            _mailUtil.sendMail(Constant.Constant.BASE_DIR + "/send_subscription.html", _email,
            parameters, "Travel Note Subscription Alert");
        }
        private string _email;
        private MailUtil _mailUtil;
        public SubscribeReceiver(string email, MailUtil mailUtil)
        {
            this._email = email;
            this._mailUtil = mailUtil;
        }
    }
}