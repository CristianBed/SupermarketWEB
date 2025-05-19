using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuperMarketWEB.Data;
using SuperMarketWEB.Models;

namespace SuperMarketWEB.Pages.Products
{
    [Authorize]
    public class CreateModel : PageModel
    {

        private readonly SupermarketContext _context;
        public CreateModel(SupermarketContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Products == null || Product == null)
            {
                return Page();

            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
