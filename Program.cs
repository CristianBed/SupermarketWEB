using Microsoft.EntityFrameworkCore;
using SuperMarketWEB.Data;

namespace SuperMarketWEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthentication().AddCookie("MyCookieAuth", options =>
            {
                options.Cookie.Name = "MyCokkieAuth";
                options.LoginPath = "/Account/Login";// Si no esta autenticado, cargue la pagina login
            });

            // Add services to the container.
            builder.Services.AddRazorPages();

            //Agregando el contexto de supermarketContext a la aplicacion
            builder.Services.AddDbContext<SupermarketContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("SupermarketDB"))
               );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
