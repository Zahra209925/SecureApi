using SecureAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace SecureAPI.Services
{
	public class UserService
	{
		private static List<User> users = new()
		{
			new User { Id = 1, Username = "admin", Password = "1234", Role = "Admin" },
			new User { Id = 2, Username = "user1", Password = "password", Role = "User" }
		};

		public User Authenticate(string username, string password)
		{
			Console.WriteLine($" Authenticating: username = {username}, password = {password}");
			var user = users.FirstOrDefault(u =>
			 u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
			 u.Password == password);
			if (user == null)
			{
				Console.WriteLine(" Authentication failed: User not found!");
			}
			else
			{
				Console.WriteLine($" Authentication successful: {user.Username}");
			}
			return user;
		}
		public List<User> GetAllUsers() => users;
		public void AddUser(User user) => users.Add(user);
		public bool DeleteUser(int id)
		{
			var user = users.FirstOrDefault(u => u.Id == id);
			if (user != null)
			{
				users.Remove(user);
				return true;
			}
			return false;
		}
	}
}