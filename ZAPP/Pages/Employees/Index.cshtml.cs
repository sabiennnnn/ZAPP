using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ZAPP.Models;

namespace ZAPP.Pages.Employees
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ZAPP.Data.ZAPPContext _context;

        public IndexModel(ZAPP.Data.ZAPPContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            Employee = await _context.Employees.ToListAsync();
        }
    }
}
