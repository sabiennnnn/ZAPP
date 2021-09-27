using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZAPP.Pages.Tasks
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
        ViewData["VisitID"] = new SelectList(_context.Visits, "VisitID", "VisitID");
            return Page();
        }

        [BindProperty]
        public Models.Task Task { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tasks.Add(Task);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
