using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webservice.ContextHelpers;
using Webservice.DatabaseHelper;
using Webservice.Models;
namespace Webservice.Pages
{


    public class BookingPageModel : Controller
    {
        private readonly DatabaseContextHelper _context;
        public BookingPageModel(DatabaseContextHelper context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            HttpContext.Session.SetString("SelectedDate", DateTime.Today.ToString());
            if (HttpContext.Session.GetString("AccountName") == "-1")
            {
                return RedirectToPage("/Login");
            }
            else
            {
                return null;
            }
        }

        public IActionResult Cancel(int id)
        {
            Booking_db.ForceDelete(_context.DBContext, id);
            return RedirectToPage("/BookingPage");
        }


    }

}
