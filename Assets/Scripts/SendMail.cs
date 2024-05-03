using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SendMail : MonoBehaviour
{

    private string bodyMessage = "";
    private string recipientEmail = "tohercoingame@gmail.com";

    public void SendEmail(string name)
    {
        bodyMessage = name + " just got the special coin!";

        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        SmtpServer.Timeout = 10000;
        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        SmtpServer.UseDefaultCredentials = false;
        SmtpServer.Port = 587;

        mail.From = new MailAddress("tohercoingame@gmail.com");
        mail.To.Add(new MailAddress(recipientEmail));

        mail.Subject = "Someone just got the Special Coin!";
        mail.Body = bodyMessage;


        SmtpServer.Credentials = new System.Net.NetworkCredential("tohercoingame@gmail.com", "mkef indl arak dghs") as ICredentialsByHost; SmtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };

        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpServer.Send(mail);
    }
}
