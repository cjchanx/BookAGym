using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webservice.ContextHelpers;
using Webservice.Core;
using Webservice.Models;
using Webservice.DatabaseHelper;
namespace Webservice.Pages
{
    public class AdminCreateAnnouncementModel : PageModel
    {
        private readonly DatabaseContextHelper _context;

        public AdminCreateAnnouncementModel(DatabaseContextHelper context)
        {
            _context = context;
        }

        [BindProperty]
        public CreateAnnouncement CreateAnnouncement { get; set; }

        public IActionResult onGet() {
            if (HttpContext.Session.GetString("AccountName") != "Admin")
            {
                Console.WriteLine("Not logged in");
                return RedirectToPage("/Home");
            }
            else
            {
                return null;
            }
        }
        public IActionResult OnPost()
        {
            Announcement_db.AddAnnouncement(CreateAnnouncement.Header, CreateAnnouncement.Comment, _context.DBContext);
            return RedirectToPage("/AdminAnnouncement");
        }
    }

    public class CreateAnnouncement
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Header { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Comment { get; set; }

    }
}
