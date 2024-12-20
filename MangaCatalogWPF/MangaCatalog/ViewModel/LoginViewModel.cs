using System;
using MangaCatalog.Model;
using System.Linq;

namespace MangaCatalog.ViewModel
{
	internal class LoginViewModel
	{
		public bool AuthenticateUser(string login, string password)
		{
			using (var dbContext = new YourDbContext())
			{
				var user = dbContext.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
				return user != null;
			}
		}
	}
}