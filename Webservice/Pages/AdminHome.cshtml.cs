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
    public class AdminPageModel : PageModel
    {
        private readonly DatabaseContextHelper _context;

        public AdminPageModel(DatabaseContextHelper context)
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
            else
            {
                return null;
            }
        }

        public List<Users> ViewUsers()
        {
            return UsersDB.AllAccounts(_context.DBContext);
        }
    }
}
