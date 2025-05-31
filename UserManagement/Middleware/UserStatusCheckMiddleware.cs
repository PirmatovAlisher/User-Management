using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using UserManagement.Infrastructure.MsSql.Data;

namespace UserManagement.Middleware
{
	public class UserStatusCheckMiddleware
	{
		private readonly RequestDelegate _next;

		public UserStatusCheckMiddleware(RequestDelegate next) => _next = next;

		public async Task InvokeAsync(HttpContext context, UserDbContext dbContext)
		{
			var path = context.Request.Path;
			if (path.StartsWithSegments("/Account/Login") ||
				path.StartsWithSegments("/Account/Register") ||
				path.StartsWithSegments("/css") ||
				path.StartsWithSegments("/js") ||
				path.StartsWithSegments("/lib"))
			{
				await _next(context);
				return;
			}

			if (context.User.Identity.IsAuthenticated)
			{
				var userId = int.Parse(context.User.FindFirstValue(ClaimTypes.NameIdentifier));
				var user = await dbContext.Users.FindAsync(userId);

				if (user == null || !user.IsActive)
				{
					await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
					context.Response.Redirect("/Account/Login");
					return;
				}
			}
			await _next(context);
		}
	}
}
