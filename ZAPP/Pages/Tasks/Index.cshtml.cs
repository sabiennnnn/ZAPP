using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ZAPP.Pages.Tasks
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ZAPP.Data.ZAPPContext _context;

        public IndexModel(ZAPP.Data.ZAPPContext context)
        {
            _context = context;
        }

        public IList<Models.Task> Task { get;set; }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            Task = await _context.Tasks
                .Include(t => t.Visit).ToListAsync();
        }
    }
}
