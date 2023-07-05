using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using backend.Repository.Common;

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

        public async void sendMail(string toAddress, Dictionary<string, string> parameters)
        {
            MailAddress addressFrom = new MailAddress(_configuration
            .GetSection("AppSettings:email_username").Value);
            MailAddress addressTo = new MailAddress(toAddress);
            MailMessage message = new MailMessage(addressFrom, addressTo);
            message.Subject = _configuration
            .GetSection("AppSettings:email_title_reset_pwd").Value;
            message.IsBodyHtml = true;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            string htmlString = ReadHtml(Constant.Constant.BASE_DIR + "/reset_pwd.html", parameters);

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

        public string ReadHtml(string filePath, Dictionary<string, string> parameters)
        {
            Stream myStream = new FileStream(filePath, FileMode.Open);
            Encoding encode = System.Text.Encoding.GetEncoding("gb2312");//若是格式为utf-8的需要将gb2312替换
            StreamReader myStreamReader = new StreamReader(myStream, encode);
            string strhtml = myStreamReader.ReadToEnd();
            myStream.Close();
            string stroutput = strhtml;
            foreach (var param in parameters)
            {
                stroutput = stroutput.Replace("$" + param.Key + "$", param.Value);
            }
            return stroutput;
        }
    }
}