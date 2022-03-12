using System.Collections.Generic;

namespace EmailsManagements.Application.Contracts.EmailsApplication
{
    public interface IEmailApplication
    {
        string CreateEmail(CreateEmail command);
        EmailViewModel GetEmailBy(long id);
        List<EmailViewModel> GetList();

    }
}
