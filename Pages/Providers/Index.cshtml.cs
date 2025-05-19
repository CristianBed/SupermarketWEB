using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperMarketWEB.Data;
using SuperMarketWEB.Models;

namespace SupermarketWEB.Pages.Provider
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;

        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }

        public IList<Providers> Provider { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // condición para las categorias
            if (_context.Providers != null)
            {
                Provider = await _context.Providers.ToListAsync();
            }
        }
    }
}