using Angular7CRUDOperation.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Angular7CRUDOperation.BalCommonCode
{
    public class CommonFunctionNIAS
    {
        public static bool SendEmail(EmailModel emailModel)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.To.Add(emailModel.ToEmailID);
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                message.From = new System.Net.Mail.MailAddress("info@nirmanias.com", " Nirman IAS Academy ENQUIRY");
                message.Bcc.Add("nirmanias07@gmail.com");
                message.Bcc.Add("enquiry@nirmanias.com");
                message.Bcc.Add("info@codelovertechnology.com");
                message.Subject = "  Nirman IAS Academy ENQUIRY by : " + emailModel.UserName;
                message.Body = "Hi " + emailModel.UserName + ", " + System.Environment.NewLine + System.Environment.NewLine
                    + "======================================================================================== "
                    + System.Environment.NewLine + "  Name : " + emailModel.UserName + System.Environment.NewLine
                    + "  Contact No : " + emailModel.ContactNo + System.Environment.NewLine + "  Email ID : " + emailModel.ToEmailID
                    + System.Environment.NewLine + "  Description : " + emailModel.MailBody + System.Environment.NewLine
                    + " ======================================================================================== "
                    + System.Environment.NewLine + System.Environment.NewLine
                    + System.Environment.NewLine
                    + System.Environment.NewLine
                    + "Thanks & Regards," + System.Environment.NewLine
                   + "Nirman IAS Academy," + System.Environment.NewLine
                   + "Head Office - Delhi ," + System.Environment.NewLine
                   + "Branch Office - Allahabad,Gwalior,Jaipur" + System.Environment.NewLine
                   + "Email ID : info@nirmanias.com/nirmanias07@gmail.com" + System.Environment.NewLine
                   + "Contact No : (+91) 9717767797" + System.Environment.NewLine;
                message.IsBodyHtml = false;
                SmtpClient client = new SmtpClient();
                client.Host = "mail.nirmanias.com";
                client.Port = 25;
                client.Credentials = new System.Net.NetworkCredential("info@nirmanias.com", "Nirman@123$");
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool SendSMS(string ContactList, string NirmanMessage)
        {
            try
            {          
                var uname = "Nirmanias07";
                var password = "nirman2007";
                string strGet;
                var sender = "NIRMAN";
                string url = "http://bhashsms.com/api/sendmsg.php?user=Nirmanias07&pass=nirman2007&sender=NIRMAN&phone=" + ContactList + "&text=" + NirmanMessage + "&priority=ndnd&stype=normal";
                strGet = url + "username=" + uname + "&password=" + password + "&message=" + System.Web.HttpUtility.UrlEncode(NirmanMessage) + "&sender=" + sender + "&numbers=" + ContactList;
                System.Net.WebClient webClient = new System.Net.WebClient();
                string result = webClient.DownloadString(url);
                Console.WriteLine(result);

                //string strUrl = "http://trans.smsfresh.co/api/sendmsg.php?user=Nirmanias07&pass=nirman2007&sender=NIRMAN&phone=" + ContactList + "&text=" + NirmanMessage + "&priority=normal&stype=ndnd";
                //WebRequest request = HttpWebRequest.Create(strUrl);
                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //Stream s = (Stream)response.GetResponseStream();
                //StreamReader readStream = new StreamReader(s);
                //string dataString = readStream.ReadToEnd();
                //response.Close();
                //s.Close();
                //readStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    //public enum CurrentAffairsCategory
    //{
    //    CURRENT = 6,
    //    HINDU = 7,
    //    NIAS2017 = 8,
    //    MCQS = 9,
    //    INDIAYEARBOOK = 10
    //}
}
