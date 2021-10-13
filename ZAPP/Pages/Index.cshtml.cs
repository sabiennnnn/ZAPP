using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ZAPP.Models;

namespace ZAPP.Pages
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        private readonly ZAPP.Data.ZAPPContext _context;

        public IndexModel(ZAPP.Data.ZAPPContext context)
        {
            _context = context;
        }

        public IList<Visit> Visit { get; set; }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            Visit = await _context.Visits
                .Include(v => v.Customer)
                .Include(v => v.Employee).ToListAsync();
        }
    }
}
