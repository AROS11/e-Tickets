using e_Tickets.Data;
using e_Tickets.Data.Services;
using eTickets.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace e_Tickets
{
    public class Program
    {
        private static object services;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
           
            
            //Service Configurations
            builder.Services.AddScoped<IActorsService, ActorsService>();
            var app = builder.Build();
            services.AddScoped<IMoviesService, MoviesService>();
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
            //app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Movies}/{action=Index}/{id?}");
            //Seed database
            AppDbInitializer.Seed(app);

            app.Run();





        }
    }
}