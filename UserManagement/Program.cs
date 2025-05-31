using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserManagement.Core.Interfaces;
using UserManagement.Infrastructure.MsSql.Data;
using UserManagement.Infrastructure.MsSql.Repositories;
using UserManagement.Middleware;
using UserManagement.Services.UserServices;

namespace UserManagement
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();


			builder.Services.AddDbContext<UserDbContext>(options =>
			options.UseSqlite("Data Source=usermgmt.db"));

			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.LoginPath = "/Account/Login";
					options.LogoutPath = "/Account/Logout";
				});

			var app = builder.Build();

			// Ensures Data base creation and Applies pending migrations
			using (var scope = app.Services.CreateScope())
			{
				var dbContext = scope.ServiceProvider.GetRequiredService<UserDbContext>();
				dbContext.Database.Migrate();
			}

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
			app.UseAuthorization();

			app.UseMiddleware<UserStatusCheckMiddleware>();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Account}/{action=Login}/{id?}");

			app.Run();
		}
	}
}
