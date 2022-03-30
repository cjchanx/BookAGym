using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webservice.Core;
using Webservice.DatabaseHelper;
using Webservice.ContextHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Webservice.Pages
{
    public class ChangeBookingModel : PageModel
    {

        private readonly DatabaseContextHelper _context;
        public ChangeBookingModel(DatabaseContextHelper context)
        {
            _context = context;
        }
        [BindProperty]
        public DateUserChange DateUserChange { get; set; }

        public List<SelectListItem> Times { get; set; }

        public List<SelectListItem> Bookings { get; set; }
        public void OnGet()
        {
            Times = new List<SelectListItem>();
            Bookings = new List<SelectListItem>();
            DateUserChange = new DateUserChange();
            foreach (var item in Booking_db.getCollection(HttpContext.Session.GetString("AccountName"), _context.DBContext)) {
                Bookings.Add(new SelectListItem { Text = item.TimeBooked.ToString(), Value = item.Id.ToString() });
                Console.WriteLine(int.Parse(item.Id.ToString()));
            }
            Console.WriteLine(HttpContext.Session.GetString("SelectedDate"));
            DateUserChange.NewDate = DateTime.Parse(HttpContext.Session.GetString("SelectedDate"));

            int available_booking = 0;
            DateTime now = DateTime.Now;
            DateTime temp = DateUserChange.NewDate;
            available_booking = Booking_db.bookingsAvailable(temp, _context.DBContext);
            if (available_booking > 0 && now <= temp)
            {
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
            HttpContext.Session.SetString("SelectedDate", DateUserChange.NewDate.ToString());
            return RedirectToPage("/ChangeBooking");
        }

        public IActionResult OnPost()
        {
            Console.WriteLine(DateUserChange.CurrentSelection);
            Console.WriteLine(DateTime.Parse(DateUserChange.NewTime));
            Console.WriteLine(HttpContext.Session.GetString("AccountName"));
            if (DateUserChange.NewTime != null)
            {
                Booking_db.Update(int.Parse(DateUserChange.CurrentSelection), DateTime.Parse(DateUserChange.NewTime), _context.DBContext);
                return RedirectToPage("/BookingPage");
            }
            else {
                return RedirectToPage("/ChangeBooking");
            }
               
        }
    }

    public class DateUserChange
    {


        [System.ComponentModel.DataAnnotations.Required]
        public DateTime NewDate { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string NewTime { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string CurrentSelection { get; set; }
    }

}
