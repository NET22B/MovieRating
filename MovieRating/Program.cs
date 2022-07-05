using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieRating.Data;
using MovieRating.Services;

namespace MovieRating
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MovieRatingContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MovieRatingContext") ?? throw new InvalidOperationException("Connection string 'MovieRatingContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddSingleton  samma instans för alla
            //builder.Services.AddScoped samma instans för hela requestet
            //builder.Services.AddTransient ny instans varje gång nån vill ha den

            builder.Services.AddScoped<IGenreSelectListService, GenreSelectListService>();



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
                pattern: "{controller=Movies}/{action=Index}/{id?}");

            app.Run();
        }
    }
}