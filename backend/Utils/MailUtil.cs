using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using backend.Repository.Common;
using HtmlAgilityPack;

namespace backend.Utils
{
    public class MailUtil
    {
        private string? _password;
        private IConfiguration _configuration;
        public MailUtil(IPasswordRepository passwordRepository, IConfiguration configuration)
        {
            _password = passwordRepository.GetEmailPwd();
            _configuration = configuration;
        }

        public async void sendMail(string filePath, string toAddress,
        Dictionary<string, string> parameters)
        {
            MailAddress addressFrom = new MailAddress(_configuration
            .GetSection("AppSettings:email_username").Value, "Travel Note");
            MailAddress addressTo = new MailAddress(toAddress);
            MailMessage message = new MailMessage(addressFrom, addressTo);
            message.Subject = _configuration
            .GetSection("AppSettings:email_title_reset_pwd").Value;
            message.IsBodyHtml = true;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            string htmlString = ReadHtml(filePath, parameters);

            message.Body = htmlString;

            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.Host = _configuration
            .GetSection("AppSettings:email_host").Value;
            client.Port = Int32.Parse(_configuration
            .GetSection("AppSettings:email_port").Value);
            client.Credentials = new System.Net.NetworkCredential(addressFrom.Address, _password);
            try
            {
                var task = Task.Factory.StartNew(() => { client.Send(message); });
                await task;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        private string ReadHtml(string filePath, Dictionary<string, string> parameters)
        {
            HtmlWeb webClient = new HtmlWeb();
            HtmlDocument doc = webClient.Load(filePath);
            foreach (var key in parameters.Keys)
            {
                if (key == "href")
                {
                    HtmlNodeCollection hrefList = doc.DocumentNode.SelectNodes(".//a[@href]");
                    if (hrefList != null)
                    {
                        foreach (HtmlNode href in hrefList)
                        {
                            href.SetAttributeValue("href", parameters[key]);
                        }
                    }
                }
                else if (key == "src")
                {
                    HtmlNodeCollection imgList = doc.DocumentNode.SelectNodes(".//img[@src]");
                    if (imgList != null)
                    {
                        foreach (HtmlNode img in imgList)
                        {
                            img.SetAttributeValue("src", parameters[key]);
                        }
                    }
                }
                else
                {
                    HtmlNode node = doc.GetElementbyId(key);
                    node.InnerHtml = parameters[key];
                }
            }
            return doc.DocumentNode.OuterHtml;
        }
    }
}