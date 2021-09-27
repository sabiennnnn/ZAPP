using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ZAPP.Models;

namespace ZAPP.Pages.Customers
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ZAPP.Data.ZAPPContext _context;

        public IndexModel(ZAPP.Data.ZAPPContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
