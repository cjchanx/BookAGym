using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webservice.Pages
{
    public class AdminAnnouncementModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("AccountName") != "Admin")
            {
                Console.WriteLine("Not logged in");
                return RedirectToPage("/Home");
            }
            else {
                return null;
            }
        }
    }
}
