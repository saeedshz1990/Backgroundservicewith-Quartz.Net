using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using EmailsManagements.infrastructure.EFCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace WebApplication6.Jobs
{
    [DisallowConcurrentExecution]
    public class EmailsSentasyn : IJob
    {
        static bool mailSent = false;
        public Task Execute(IJobExecutionContext context)
        {
            var option = new DbContextOptionsBuilder<EmailsContext>();
            option.UseSqlServer(@"Data Source=.; Initial Catalog=EmailsTest; Integrated Security =True");

            using (EmailsContext _ctx = new EmailsContext(option.Options))
            {
                var adminemail = "green.kolah@gmail.com";
                var email = _ctx.Emails.AsNoTracking().ToList();
                var subject = "this is a test";
                var messsage = "This is a Test";
                //var email = _ctx.Emails.ToList();
                foreach (var emailsent in email)
                {
                    var emaildetails = _ctx.Emails.ToList();
                    foreach (var detail in emaildetails)
                    {
                        Collection<string> EmailAddresses = new Collection<string>();
                        SqlConnection con = new SqlConnection(@"Data Source=.; Initial Catalog=EmailsTest; Integrated Security =True");
                        SqlCommand cmd = new SqlCommand("Select Email from Emails", con);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string emailsender = (string)reader["Email"];
                                EmailAddresses.Add(emailsender);
                            }
                        }
                        reader.Close();
                        cmd.Dispose();
                        con.Close();
                        var task = new List<Task>();
                        foreach (string emailsender in EmailAddresses)
                        {
                            task.Add(SendEmailTOAllUser("email", subject, messsage)
                                .ContinueWith(x => Console.WriteLine("Completed!!!!")));
                            //Thread.Sleep(1000);//300000
                        }
                    }
                }
                _ctx.SaveChanges();
            }
            return Task.CompletedTask;
        }
        public static async Task SendEmailTOAllUser(string toEmailAddress, string emailSubject, string emailMessage)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("green.kolah@gmail.com", "Admin");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            mail.To.Add(toEmailAddress);
            mail.Subject = emailSubject;
            mail.Body = emailMessage;
            mail.IsBodyHtml = true;
            //send the message
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential("green.kolah@gmail.com", "Sa1234567890");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}
//MailMessage mail = new MailMessage();
//mail.From = new MailAddress("green.kolah@gmail.com", "Admin");
//SmtpClient smtp = new SmtpClient("smtp.gmail.com");
//mail.To.Add("green.kolah@gmail.com");
//mail.Subject = "Email test With Quartz.Net";
//mail.Body = "This is email for test with Background Service and Quartz.Net";
//mail.IsBodyHtml = true;
////send the message
//smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
//smtp.Credentials = new NetworkCredential("green.kolah@gmail.com", "Sa1234567890");
//smtp.Port = 587;
//smtp.UseDefaultCredentials = false;
//smtp.EnableSsl = true;
//smtp.Send(mail);