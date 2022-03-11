using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webservice.ContextHelpers;
using Webservice.Core;
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
                    return RedirectToPage("/ClientPage");

           }
    }

    public class Credential
    {

        [System.ComponentModel.DataAnnotations.Required]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
