using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webservice.Pages
{
    public class ClientPageModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.SetString("SelectedDate", DateTime.Today.ToString());
            if (HttpContext.Session.GetString("AccountName") == "-1")
            {
                Console.WriteLine("Not logged in");
                return RedirectToPage("/Home");
            }
            else {
                Console.WriteLine("Logged in");
                return null;
            }
        }
    }
}
