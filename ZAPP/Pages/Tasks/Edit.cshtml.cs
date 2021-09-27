using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZAPP.Models;

namespace ZAPP.Pages.Tasks
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
        public Models.Task Task { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Task = await _context.Tasks
                .Include(t => t.Visit).FirstOrDefaultAsync(m => m.TaskID == id);

            if (Task == null)
            {
                return NotFound();
            }
           ViewData["VisitID"] = new SelectList(_context.Visits, "VisitID", "VisitID");
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

            _context.Attach(Task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(Task.TaskID))
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

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.TaskID == id);
        }
    }
}
