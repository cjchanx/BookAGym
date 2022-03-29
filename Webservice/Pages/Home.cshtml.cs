using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webservice.Pages
{
    public class HomeModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.SetString("AccountName", "-1");
        }
    }
}
