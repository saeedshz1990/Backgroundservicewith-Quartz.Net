using System.Collections.Generic;
using System.Linq;
using EmailsManagements.Application.Contracts.EmailsApplication;
using EmailsManagents.Domain;
using Framework.Base;

namespace EmailsManagements.infrastructure.EFCore.Repository
{
    public class EmailsRepository : RepositoryBase<long, Emails>, IEmailsRepository
    {
        private readonly EmailsContext _context;

        public EmailsRepository(EmailsContext context) :base(context)
        {
            _context = context;
        }

        public List<EmailViewModel> GetEmails()
        {
            return _context.Emails.Select(x => new EmailViewModel()
            {
                Id = x.Id,
                Email = x.Email
            }).ToList();
        }

        public List<EmailViewModel> GetList()
        {
            return _context.Emails.Select(x => new EmailViewModel
            {
                Id = x.Id,
                Email = x.Email
            }).ToList();
        }
    }
}
