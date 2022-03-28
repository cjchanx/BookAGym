using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webservice.ContextHelpers;
using Webservice.Core;
using Webservice.Models;
using Webservice.DatabaseHelper;

namespace Webservice.Pages
{
    public class AdminEditAnnouncementModel : PageModel
    {

        private readonly DatabaseContextHelper _context;

        public AdminEditAnnouncementModel(DatabaseContextHelper context)
        {
            _context = context;
        }

        [BindProperty]
        public UpdateAnnoucement UpdateAnnoucement { get; set; }
        public IActionResult OnGet(int id)
        {
            Announcement announcement = Announcement_db.getAnnouncement(id, _context.DBContext);
            UpdateAnnoucement = new UpdateAnnoucement();
            UpdateAnnoucement.Id = @announcement.Id;
            UpdateAnnoucement.Header = @announcement.Header;
            UpdateAnnoucement.Comment = @announcement.Comment;
            return null;
        }

        public IActionResult OnPost()
        {
            Announcement_db.editAnnouncement(UpdateAnnoucement.Id, UpdateAnnoucement.Header, UpdateAnnoucement.Comment, _context.DBContext);
            return RedirectToPage("/AdminAnnouncement");
        }
    }

    public class UpdateAnnoucement
    {

        [System.ComponentModel.DataAnnotations.Required]
        public string Header { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Comment { get; set; }
        public int Id { get; set; }
    }
}
