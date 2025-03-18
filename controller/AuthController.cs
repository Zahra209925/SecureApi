using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
	[HttpPost("login")]
	public IActionResult Login(string username, string password)
	{
		if (username == "admin" && password == "password")
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes("Your_Secret_Key_Here");
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }),
				Expires = DateTime.UtcNow.AddHours(1),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return Ok(new { Token = tokenHandler.WriteToken(token) });
		}
		return Unauthorized();
	}
}