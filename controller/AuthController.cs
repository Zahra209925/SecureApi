using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SecureAPI.Services; // Lisää tämä
using SecureAPI.Models;  // Lisää tämä

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
	private readonly UserService _userService;

	public AuthController()
	{
		_userService = new UserService();
	}

	[HttpPost("login")]
	public IActionResult Login([FromBody] User user)
	{
		if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
		{
			return BadRequest(new { message = "Username and password are required" });
		}

		var authenticatedUser = _userService.Authenticate(user.Username, user.Password);

		if (authenticatedUser == null)
		{
			return Unauthorized(new { message = "Invalid username or password" });
		}

		return Ok(new { message = "Login successful", user = authenticatedUser });
	}
}