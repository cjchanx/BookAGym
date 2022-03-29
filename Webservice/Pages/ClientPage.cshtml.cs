using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webservice.Pages
{
    public class ClientPageModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.SetString("SelectedDate", DateTime.Today.ToString());
        }
    }
}
