using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UserManagement.Core.Models;
using UserManagement.Infrastructure.MsSql.Data;
using UserManagement.Services;
using UserManagement.ViewModels;

namespace UserManagement.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserDbContext _context;

		public AccountController(UserDbContext context) => _context = context;

		[HttpGet]
		public IActionResult Login() => View();

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
				if (user != null && user.PasswordHash == PasswordService.HashPassword(model.Password))
				{
					if (!user.IsActive)
					{
						ModelState.AddModelError("", "Your account is blocked.");
						return View(model);
					}

					user.LastLoginTime = DateTime.UtcNow;
					_context.Users.Update(user);
					await _context.SaveChangesAsync();

					var claims = new List<Claim>
					{
						new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
						new Claim(ClaimTypes.Name, user.Name),
						new Claim(ClaimTypes.Email, user.Email)
					};

					var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					var principal = new ClaimsPrincipal(identity);

					await HttpContext.SignInAsync(principal);
					return RedirectToAction("Index", "Admin");
				}
				ModelState.AddModelError("", "Invalid login attempt.");
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult Register() => View();

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new User
				{
					Name = model.Name,
					Email = model.Email,
					PasswordHash = PasswordService.HashPassword(model.Password)
				};

				_context.Users.Add(user);
				try
				{
					await _context.SaveChangesAsync();
					return RedirectToAction("Login");
				}
				catch (DbUpdateException)
				{
					ModelState.AddModelError("Email", "Email already exists");
				}
			}
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("Login");
		}
	}
}
