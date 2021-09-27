using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZAPP.Models;

namespace ZAPP.Pages.Visits
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ZAPP.Data.ZAPPContext _context;

        public EditModel(ZAPP.Data.ZAPPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Visit Visit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Visit = await _context.Visits
                .Include(v => v.Customer)
                .Include(v => v.Employee).FirstOrDefaultAsync(m => m.VisitID == id);

            if (Visit == null)
            {
                return NotFound();
            }
           ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "Name");
           ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Visit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitExists(Visit.VisitID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VisitExists(int id)
        {
            return _context.Visits.Any(e => e.VisitID == id);
        }
    }
}
