using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webservice.ContextHelpers;
using Webservice.Core;
using Webservice.Models;
using Webservice.DatabaseHelper;
namespace Webservice.Pages
{
    public class CreateModel : PageModel
    {
        private readonly DatabaseContextHelper _context;

        public CreateModel(DatabaseContextHelper context)
        {
            _context = context;
        }

        [BindProperty]
        public CreateAccount CreateAccount { get; set; }

        public IActionResult OnPost()
        {
            UsersDB.AddAccount(CreateAccount.UserName, CreateAccount.Password, _context.DBContext);
            return RedirectToPage("/AdminPage");
        }
    }
}
