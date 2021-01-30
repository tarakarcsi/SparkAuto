using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Model;

namespace SparkAuto.Pages.Users
{
    public class DeleteModel : PageModel
    {
        public ApplicationDbContext _db;

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id.Trim().Length == 0)
                return NotFound();

            ApplicationUser = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == id);

            if(ApplicationUser == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userFromDb = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == ApplicationUser.Id);

            _db.Remove(userFromDb);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
