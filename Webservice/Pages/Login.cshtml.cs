using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webservice.ContextHelpers;
using Webservice.Core;
using Webservice.DatabaseHelper;
namespace Webservice.Pages
{
    public class LoginModel : PageModel
    {
        private readonly DatabaseContextHelper _context;
        public LoginModel (DatabaseContextHelper context)
        {
            _context = context;
        }

        [BindProperty]
        public Credential Credential { get; set; }
        public void OnGet()
        {
            HttpContext.Session.SetString("AccountName", "-1");
        }

          public IActionResult OnPost()
          {
            int type = UsersDB.ValidateLogin(_context.DBContext, Credential.Username, Credential.Password);
            if (type == 1)
            {
                HttpContext.Session.SetString("AccountName", Credential.Username);
                return RedirectToPage("/ClientPage");
            }
            else if (type == 2) {
                HttpContext.Session.SetString("AccountName", Credential.Username);
                return RedirectToPage("/AdminHome");
            }
            else
            {
                HttpContext.Session.SetString("AccountName", "-1");
                return RedirectToPage("/Login");
            }


        }
    }

    public class Credential
    {

        [System.ComponentModel.DataAnnotations.Required]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
