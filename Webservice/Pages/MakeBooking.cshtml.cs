using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webservice.Core;
using Webservice.DatabaseHelper;
using Webservice.ContextHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Webservice.Pages
{
    public class MakeBookingModel : PageModel
    {
        private readonly DatabaseContextHelper _context;
        public MakeBookingModel(DatabaseContextHelper context)
        {
            _context = context;
        }
        [BindProperty]
        public DateUserSelected DateUserSelected { get; set; }

        public List<SelectListItem> Times { get; set; }
        public void OnGet()
        {
            DateUserSelected = new DateUserSelected();
            Console.WriteLine(DateUserSelected.Date);
            DateUserSelected.Date = DateTime.Parse(HttpContext.Session.GetString("SelectedDate"));
            
            Times = new List<SelectListItem>();
            int available_booking = 0;
            DateTime now = DateTime.Now;
            DateTime temp = DateUserSelected.Date;
            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp) { 
                Times.Add(new SelectListItem { Text = "12 AM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "1 AM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "2 AM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "3 AM : " + available_booking, Value = temp.ToString() });
            }

            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "4 AM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "5 AM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "6 AM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "7 AM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "8 AM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "9 AM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "10 AM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "11 AM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "12 PM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "1 PM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "2 PM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "3 PM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "4 PM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "5 PM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "6 PM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "7 PM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "8 PM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);
            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "9 PM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "10 PM : " + available_booking, Value = temp.ToString() });
            }
            temp = temp.AddHours(1);

            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
                Times.Add(new SelectListItem { Text = "11 PM : " + available_booking, Value = temp.ToString() });
            }


        }

        public IActionResult OnPostDateChange()
        {
           HttpContext.Session.SetString("SelectedDate", DateUserSelected.Date.ToString());
            return RedirectToPage("/MakeBooking");
        }

        public IActionResult OnPost()
        {
            if (DateUserSelected.Time != null)
            {
                Booking_db.Add(DateTime.Parse(DateUserSelected.Time), HttpContext.Session.GetString("AccountName"), _context.DBContext);
                return RedirectToPage("/BookingPage");
            }
            else {
                return RedirectToPage("/MakeBooking");
            }
            
        }

    }
    public class DateUserSelected
    {

        [System.ComponentModel.DataAnnotations.Required]
        public DateTime Date { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Time { get; set; }
    }
}
