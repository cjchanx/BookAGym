using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webservice.ContextHelpers;
using Webservice.DatabaseHelper;
using Webservice.Models;
namespace Webservice.Pages
{
    public class AdminAnnouncementModel : Controller
    {
        private readonly DatabaseContextHelper _context;
        public AdminAnnouncementModel(DatabaseContextHelper context)
        {
            _context = context;
        }
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

        public IActionResult Delete(int id)
        {
            Announcement_db.ForceDelete(_context.DBContext, id);
            return RedirectToPage("/AdminAnnouncement");
        }
    }
}
