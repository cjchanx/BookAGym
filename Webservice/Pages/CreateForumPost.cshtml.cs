using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webservice.ContextHelpers;
using Webservice.Core;
using Webservice.Models;
using Webservice.DatabaseHelper;
namespace Webservice.Pages
{
    public class CreateForumPostModel : PageModel
    {
        private readonly DatabaseContextHelper _context;

        public CreateForumPostModel(DatabaseContextHelper context)
        {
            _context = context;
        }

        [BindProperty]
        public CreatePost CreatePost { get; set; }

        public IActionResult OnPost()
        {
            Announcement_db.AddAnnouncement(CreatePost.Header, CreatePost.Comment, _context.DBContext);
            return RedirectToPage("/ForumPage");
        }
    }
    public class CreatePost
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Header { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Comment { get; set; }

    }
}
