using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureAPI.Models;
using SecureAPI.Services;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
	private readonly UserService _userService;
	public UserController()
	{
		_userService = new UserService();
	}
	[HttpPost("register")]
	public IActionResult Register([FromBody] User user)
	{
		if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
			return BadRequest("Username and password are required");
		user.Id = _userService.GetAllUsers().Count + 1;
		user.Role = "User";
		_userService.AddUser(user);
		return Ok("User registered successfully");
	}
	[Authorize(Roles = "Admin")]
	[HttpGet]
	public IActionResult GetUsers()
	{
		return Ok(_userService.GetAllUsers());
	}
	[Authorize(Roles = "Admin")]
	[HttpDelete("{id}")]
	public IActionResult DeleteUser(int id)
	{
		if (_userService.DeleteUser(id))
			return Ok("User deleted successfully");
		return NotFound("User not found");
	}
}