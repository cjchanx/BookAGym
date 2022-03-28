using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webservice.ContextHelpers;
using Webservice.Core;
using Webservice.DatabaseHelper;
using Webservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Webservice.Pages
{
    public class ForumPageModel : PageModel
    {
        private readonly DatabaseContextHelper _context;

        public ForumPageModel(DatabaseContextHelper context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        public List<Announcement> ViewAnnouncement()
        {
            return Announcement_db.AllAnnouncement(_context.DBContext);
        }
    }

}
