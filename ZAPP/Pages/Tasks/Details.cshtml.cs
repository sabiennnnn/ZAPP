using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ZAPP.Pages.Tasks
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly ZAPP.Data.ZAPPContext _context;

        public DetailsModel(ZAPP.Data.ZAPPContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
