using System.Collections.Generic;
using EmailsManagements.Application.Contracts.EmailsApplication;
using Framework.Base;

namespace EmailsManagents.Domain
{
    public interface IEmailsRepository : IRepository<long, Emails>
    {
        List<EmailViewModel> GetEmails();
        List<EmailViewModel> GetList();
    }
}
