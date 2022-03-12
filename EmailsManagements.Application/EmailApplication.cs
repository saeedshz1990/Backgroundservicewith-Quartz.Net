using System;
using System.Collections.Generic;
using EmailsManagements.Application.Contracts.EmailsApplication;
using EmailsManagents.Domain;

namespace EmailsManagements.Application
{
    public class EmailApplication : IEmailApplication
    {
        private readonly IEmailsRepository _repository;

        public EmailApplication(IEmailsRepository repository)
        {
            _repository = repository;
        }

        public string CreateEmail(CreateEmail command)
        {
            if (_repository.Exists(x => x.Email == command.Email))
                return "ایمیل تکراری می باشد" ;

            var email = new Emails(command.Email);
            _repository.Create(email);
            _repository.SaveChanges();
            return "عملیات با موفقیت انجام شد";
        }

        public EmailViewModel GetEmailBy(long id)
        {
            var email = _repository.Get(id);
            return new EmailViewModel()
            {
                Email = email.Email
            };
        }

        public List<EmailViewModel> GetList()
        {
            return _repository.GetList();
        }
    }
}
