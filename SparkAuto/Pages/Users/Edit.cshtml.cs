using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Model;
using System.Threading.Tasks;

namespace SparkAuto.Pages.Users
{
    public class EditModel : PageModel
    {
        public ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            if (id.Trim().Length == 0)
                return NotFound();

            ApplicationUser = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == id);

            if (ApplicationUser == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var userFromDb = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == ApplicationUser.Id);

            userFromDb.Name = ApplicationUser.Name;
            userFromDb.PhoneNumber = ApplicationUser.PhoneNumber;
            userFromDb.PostalCode = ApplicationUser.PostalCode;
            userFromDb.Address = ApplicationUser.Address;
            userFromDb.City = ApplicationUser.City;

            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
