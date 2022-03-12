using System;
using System.Linq;
using System.Threading.Tasks;
using EmailsManagements.infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace EmailsSent.Jobs
{
    [DisallowConcurrentExecution]
    public class EmailsSentasyn : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
           var option = new DbContextOptionsBuilder<EmailsContext>();
            option.UseSqlServer(@"Data Source=.; Initial Catalog=EmailsTest; Integrated Security =True");
           
            using (EmailsContext _ctx =new EmailsContext(option.Options))
            {
                var email = _ctx.Emails.ToList();
                foreach (var emailsent in email)
                {
                    var emaildetails = _ctx.Emails.ToList();
                    foreach (var detail in emaildetails)
                    {
                        _ctx.Remove(detail);
                    }

                    
                }

                _ctx.SaveChanges();
            }
            return Task.CompletedTask;
        }
    }
}
