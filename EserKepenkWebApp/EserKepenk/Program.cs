using EserKepenk.BLL.Managers.Concrete;
using EserKepenk.DAL.Context;
using EserKepenk.DAL.Repositories.Concrete;
using EserKepenk.DAL.Services.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EserKepenk
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<EserKepenkDbContext>(options => {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("EserKepenkConStr"));
            }, ServiceLifetime.Singleton);


            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<ProductRepo>();
            builder.Services.AddSingleton<ProductService>();
            builder.Services.AddSingleton<ProductManager>();

            // City Implimentation
            builder.Services.AddSingleton<CategoryRepo>();
            builder.Services.AddSingleton<CategoryService>();
            builder.Services.AddSingleton<CategoryManager>();

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
