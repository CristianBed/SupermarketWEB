using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperMarketWEB.Data;
using SuperMarketWEB.Models;

namespace SuperMarketWEB.Pages.Products
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;

        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                Products = await _context.Products.ToListAsync();
            }
        }
    }
}
