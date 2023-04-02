using ITI_Project.Models;
using ITI_Project.reprosatories;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace ITI_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession();

            builder.Services.AddDbContext<CourseSystem>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
           );

            builder.Services.AddScoped<ICourseReprosatory, CourseReprosatory>();
            builder.Services.AddScoped<IDepartementReprosatory, DepartementReprosatory>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}