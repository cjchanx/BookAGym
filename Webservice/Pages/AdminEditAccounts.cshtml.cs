using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webservice.ContextHelpers;
using Webservice.Core;
using Webservice.Models;
using Webservice.DatabaseHelper;

namespace Webservice.Pages
{
    public class AdminEditAccountsModel : PageModel
    {

        private readonly DatabaseContextHelper _context;

        public AdminEditAccountsModel(DatabaseContextHelper context)
        {
            _context = context;
        }

        [BindProperty]
        public UpdateAdminAccount UpdateAdminAccount { get; set; }
        public IActionResult OnGet(int id)
        {
            Users user = UsersDB.getAccount(id, _context.DBContext);
            UpdateAdminAccount = new UpdateAdminAccount();
            UpdateAdminAccount.UserName = @user.UserName;
            UpdateAdminAccount.Password = @user.Password;
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

        public IActionResult OnPost() {
            UsersDB.EditAccount(UpdateAdminAccount.UserName, UpdateAdminAccount.Password, _context.DBContext);
            return RedirectToPage("/AdminHome");
        }
    }

    public class UpdateAdminAccount
    {

        [System.ComponentModel.DataAnnotations.Required]
        public string UserName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Password { get; set; }
    }
}
