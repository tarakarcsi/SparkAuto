using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Model;

namespace SparkAuto.Pages.ServiceTypes
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _context { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ServiceType> ServiceTypes { get; set; }

        public async Task<IActionResult> OnGet()
        {
            ServiceTypes = await _context.ServiceType.ToListAsync();

            return Page();
        }
    }
}
