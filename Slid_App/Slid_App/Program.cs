using Microsoft.EntityFrameworkCore;
using Slid_App.Models;
using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore.Metadata;
using Slid_App.Models.Interfse;
using Slid_App.Models.Servicse;

namespace Slid_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            string? connString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<SlideAppDbContext>(options => options.UseSqlServer(connString));
            builder.Services.AddControllers();
            builder.Services.AddTransient<IUser, UserServices>();
            builder.Services.AddTransient<ISlid, SlidServices>();
            builder.Services.AddTransient<IPage, PageServices>();
            builder.Services.AddTransient<IUFile, UFileServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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