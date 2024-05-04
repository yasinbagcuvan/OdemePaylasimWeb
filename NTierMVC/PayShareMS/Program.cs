using Microsoft.EntityFrameworkCore;
using PayShare.DAL.Context;
using PayShare.DAL.Repositories.Concrete;
using PayShare.DAL.Services.Concrete;
using PayShareMS.BLL.Managers.Abstract;
using PayShareMS.BLL.Managers.Concrete;




namespace PayShareMS
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<PayShareDbContext>(opts =>
			{
				opts.UseSqlServer("Data Source=DESKTOP-SNI2HD0\\MSSQLSERVERYASN;Initial Catalog=PayShareDB;Integrated Security=True;Encrypt=False;");
			});

			builder.Services.AddControllersWithViews();

			builder.Services.AddSingleton<PersonManager>();
			builder.Services.AddSingleton<PersonRepo>();
			builder.Services.AddSingleton<PersonService>();

			builder.Services.AddSingleton<ProductManager>();
			builder.Services.AddSingleton<ProductRepo>();
			builder.Services.AddSingleton<ProductService>();

			builder.Services.AddSingleton<GeneralLedgerManager>();
			builder.Services.AddSingleton<GeneralLedgerRepo>();
			builder.Services.AddSingleton<GeneralLedgerService>();

			builder.Services.AddSingleton<EventManager>();
			builder.Services.AddSingleton<EventRepo>();
			builder.Services.AddSingleton<EventService>();




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
