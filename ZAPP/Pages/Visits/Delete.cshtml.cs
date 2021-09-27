using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ZAPP.Models;

namespace ZAPP.Pages.Visits
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ZAPP.Data.ZAPPContext _context;

        public DeleteModel(ZAPP.Data.ZAPPContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Visit = await _context.Visits.FindAsync(id);

            if (Visit != null)
            {
                _context.Visits.Remove(Visit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
