using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.Net.Mime;
using System.Threading;
using EmailsManagements.infrastructure.EFCore;

namespace EmailsSent
{
    public class EmailsSendAsynchronous
    {
        static bool mailSent = false;

        //private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        //{
        //    // Get the unique identifier for this asynchronous operation.
        //    String token = (string)e.UserState;

        //    if (e.Cancelled)
        //    {
        //        Console.WriteLine("[{0}] Send canceled.", token);
        //    }
        //    if (e.Error != null)
        //    {
        //        Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
        //    }
        //    else
        //    {
        //        Console.WriteLine("Message sent.");
        //    }
        //    mailSent = true;
        //}
        //public static void Main(string[] args)
        //{
        //    SmtpClient client = new SmtpClient(args[0]);
        //    MailAddress from = new MailAddress("green.kolah@gmail.com",
        //       "Saeed " + (char)0xD8 + " Ansari",Encoding.UTF8);
        //    // Set destinations for the email message.
        //    MailAddress to = new MailAddress("_context.Emails.Tostring()");
        //    // Specify the message content.
        //    MailMessage message = new MailMessage(from, to);
        //    message.Body = "This is a test email message sent by an application. ";
        //    // Include some non-ASCII characters in body and subject.
        //    string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
        //    message.Body += Environment.NewLine + someArrows;
        //    message.BodyEncoding = Encoding.UTF8;
        //    message.Subject = "test message 1" + someArrows;
        //    message.SubjectEncoding = Encoding.UTF8;
        //    // Set the method that is called back when the send operation ends.
        //    client.SendCompleted += new
        //    SendCompletedEventHandler(SendCompletedCallback);
        //    // The userState can be any object that allows your callback
        //    // method to identify this send operation.
        //    // For this example, the userToken is a string constant.
        //    string userState = "test message1";
        //    client.SendAsync(message, userState);
        //    Console.WriteLine("Sending message... press c to cancel mail. Press any other key to exit.");
        //    string answer = Console.ReadLine();
        //    // If the user canceled the send, and mail hasn't been sent yet,
        //    // then cancel the pending operation.
        //    if (answer.StartsWith("c") && mailSent == false)
        //    {
        //        client.SendAsyncCancel();
        //    }
        //    // Clean up.
        //    message.Dispose();
        //    Console.WriteLine("Goodbye.");
        //}

        protected static void SendEmail(string toAddress, string fromAddress, string MailSubject, string Messagebody, bool isBodyHtml)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromAddress, "Site Admin");
                mail.To.Add(toAddress);
                mail.Subject = MailSubject;
                mail.Body = "This is email for test with Background Servie";
                mail.IsBodyHtml = isBodyHtml;
                //send the message
                SmtpClient smtp = new SmtpClient("Your smtp server address.");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("smtp user name", "smtp password");
                smtp.Port = 25;
                smtp.Send(mail);
            }
            catch (System.Exception ex)
            {

            }
        }

        protected void SendEmailTOAllUser()
        {
            Collection<string> EmailAddresses = new Collection<string>();
            SqlConnection con = new SqlConnection("connection string");
            SqlCommand cmd = new SqlCommand("Select UserID,UserEmail From UserTable Order BY UserEmail", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string email = (string)reader["UserEmail"];
                    EmailAddresses.Add(email);
                }
            }
            reader.Close();
            cmd.Dispose();
            con.Close();
            foreach (string email in EmailAddresses)
            {
                SendEmail(email, "Admin email address", "Notification Email Subject", "this is a test", true);
                Thread.Sleep(300000);
            }
        }
    }
}
