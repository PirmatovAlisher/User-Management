using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Core.Interfaces;
using UserManagement.Core.Models;
using UserManagement.Dtos;
using UserManagement.Extensions;

namespace UserManagement.Controllers
{
	[Authorize]
	public class AdminController : Controller
	{
		private readonly IUserService _userService;
		private readonly IMapper _mapper;

		public AdminController(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var users = await _userService.GetAllUsersAsync();

			// Map to DTO
			var userDtos = users.Select(u => new UserDto
			{
				Id = u.Id,
				Name = u.Name,
				Email = u.Email,
				RegistrationTime = u.RegistrationTime,
				LastLoginTime = u.LastLoginTime,
				IsActive = u.IsActive,
				ActivityTimestamps = u.ActivityTimestamps
			}).
			OrderByDescending(u => u.LastLoginTime).
			ToList();


			// Generate sample activity data for demonstration
			foreach (var user in userDtos)
			{
				if (!user.ActivityTimestamps.Any())
				{
					user.ActivityTimestamps = GenerateFakeData.GenerateActivityTimestamps(user.LastLoginTime);
				}
			}

			return View(userDtos);
		}

		[HttpPost]
		public async Task<IActionResult> BlockUsers([FromBody] List<int> selectedUserIds)
		{
			await _userService.BlockUsersAsync(selectedUserIds);

			return Ok("Users blocked successfully");
		}

		[HttpPost]
		public async Task<IActionResult> UnblockUsers([FromBody] List<int> selectedUserIds)
		{
			await _userService.UnBlockUsersAsync(selectedUserIds);

			return Ok("Users unblocked  successfully");

		}

		[HttpPost]
		public async Task<IActionResult> DeleteUsers([FromBody] List<int> selectedUserIds)
		{
			await _userService.DeleteUsersAsync(selectedUserIds);
			return Ok("Users deleted successfully");
		}

	}
}
