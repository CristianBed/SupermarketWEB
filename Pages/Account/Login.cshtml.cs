using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperMarketWEB.Data;
using SuperMarketWEB.Models;
using System.Security.Claims;

namespace SuperMarketWEB.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SupermarketContext _context;
        public LoginModel(SupermarketContext context)
        {
            _context = context;
        }


        public void OnGet()
        {
        }

        [BindProperty]
        public User User { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var user = await _context.Users.FirstOrDefaultAsync(u =>
            u.EmailAddress == User.EmailAddress && u.Password == User.Password);

            if (user != null)
            {
                //se crea los claim, datos a almacenar en la cookie
                var claims = new List<Claim>
                {
                    new Claim (ClaimTypes.Name, " "),
                    new Claim(ClaimTypes.Email,User.EmailAddress),
                };

                //se asocia a los claims creados a un nombre de una cokkie 
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                //Se agrega la  identidad creada al claimsprincipal de la aplicacion 
                ClaimsPrincipal claimsprincipal = new ClaimsPrincipal(identity);

                //se registra exitosamente la autenticacion y se crea la cookie en el navegador
                await HttpContext.SignInAsync("MyCookieAuth", claimsprincipal);


                return RedirectToPage("/Index");

            }

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}