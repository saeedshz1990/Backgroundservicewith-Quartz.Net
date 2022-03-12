using System.Collections.Generic;
using EmailsManagements.Application.Contracts.EmailsApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication6.Pages
{
    public class IndexModel : PageModel
    {
        public CreateEmail Command;
        public List<EmailViewModel> Emails;
        private readonly IEmailApplication _emailApplication;

        public IndexModel(IEmailApplication emailApplication)
        {
            _emailApplication = emailApplication;
        }

        public void OnGet()
        {
            Emails = _emailApplication.GetList();
        }

        public IActionResult OnPost(CreateEmail command)
        {
            var result = _emailApplication.CreateEmail(command);
            return RedirectToPage("Index");
        }
    }
}
