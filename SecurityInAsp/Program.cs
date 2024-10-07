using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tutorial.AspNetSecurity.RouxAcademy.DataServices;

namespace SecurityInAsp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region DB Context

            builder.Services.AddDbContext<StudentDataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("RouxAcademy"));
            });

            #endregion

            #region Identity DB Context

            builder.Services.AddDbContext<IdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("RouxAcademy"),
                    optionBuilder =>
                    {
                        optionBuilder.MigrationsAssembly("SecurityInAsp");
                    });
            });

            #endregion

            #region Add Identity 

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            #endregion

            #region Authorization

            builder.Services.AddAuthorization(
                options =>
            {
                options.AddPolicy("Master", policy => policy.RequireClaim("FacultyNumber"));
            });

            #endregion

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
