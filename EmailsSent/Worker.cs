using System;
using System.ComponentModel;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmailsSent
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HttpClient client;
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            client = new HttpClient();
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //var result = await client.GetAsync("https://stackoverflow.com");
                await Task.Delay(1000, stoppingToken);
            }
        }
        //static bool mailSent = false;
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
        //       "Saeed " + (char)0xD8 + " Ansari", Encoding.UTF8);
        //    // Set destinations for the email message.
        //    MailAddress to = new MailAddress("green.kolah@gmail.com");
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
    }
}
