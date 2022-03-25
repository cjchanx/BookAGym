using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webservice.ContextHelpers;
using Webservice.Core;
using Webservice.Models;
using Webservice.DatabaseHelper;
namespace Webservice.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly DatabaseContextHelper _context;

        public SignUpModel(DatabaseContextHelper context)
        {
            _context = context;
        }

        [BindProperty]
        public CreateAccount CreateAccount { get; set; }

        public IActionResult OnPost()
        {
            UsersDB.AddAccount(CreateAccount.UserName, CreateAccount.Password, _context.DBContext);
            return RedirectToPage("/Home");
        }
    }

    public class CreateAccount
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string UserName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Password { get; set; }

    }
}
