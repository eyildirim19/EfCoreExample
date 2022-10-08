using EfCoreExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(c =>

            //c.UseSqlServer(@"Server=.\mssqlexpress;Database=Northwind;uid=sa;pwd=123")
            c.UseSqlServer(builder.Configuration.GetConnectionString("constr")) // constr appsettings.json dosyasýndaki connectionstring içerisindeki key'sdir. getConnectionString metodu bu json'daki value'yý getirir..
            ); // AppDbContext instance'ni bekleyen bütün ctorlara instance buradan gönder..

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}