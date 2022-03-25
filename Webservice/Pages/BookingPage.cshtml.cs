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
        public void OnPost()
        {
            int type = Booking_db.bookingsAvailable(_context.DBContext ,DateUserSelected.date);


        }

    }

    public class DateUserSelected
    {

        [System.ComponentModel.DataAnnotations.Required]
        public DateTime date { get; set; }
    }
}
