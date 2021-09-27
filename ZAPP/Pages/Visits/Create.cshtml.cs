using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZAPP.Models;

namespace ZAPP.Pages.Visits
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ZAPP.Data.ZAPPContext _context;

        public CreateModel(ZAPP.Data.ZAPPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "Name");
        ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "Name");
            return Page();
        }

        [BindProperty]
        public Visit Visit { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Visits.Add(Visit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
