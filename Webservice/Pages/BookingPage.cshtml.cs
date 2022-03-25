using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webservice.ContextHelpers;
using Webservice.Core;
using Webservice.DatabaseHelper;
using Webservice.Helpers;

namespace Webservice.Pages
{


    public class BookingPageModel : PageModel
    {
        private readonly DatabaseContextHelper _context;
        public BookingPageModel(DatabaseContextHelper context)
        {
            _context = context;
        }
        public DateUserSelected DateUserSelected { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            //int avaialbleBooking = Booking_db.bookingsAvailable(_context.DBContext ,DateUserSelected.date);
            return RedirectToAction("/Home");
        }

    }

    public class DateUserSelected
    {

        [System.ComponentModel.DataAnnotations.Required]
        public DateTime date { get; set; }
    }
}
