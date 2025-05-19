using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperMarketWEB.Data;
using SuperMarketWEB.Models;

namespace SuperMarketWEB.Pages.Products
{
    [Authorize]
    public class EditModel : PageModel
    {


        private readonly SupermarketContext _context;

        public EditModel(SupermarketContext context)
        {
            _context = context;
        }
        [BindProperty]


        public Product Product { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Product.Id))
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

        private bool CategoryExists(int id)
        {
            return (_context.Products?.Any(o => o.Id == id)).GetValueOrDefault();
        }

    }
}