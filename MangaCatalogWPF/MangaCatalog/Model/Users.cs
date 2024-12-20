namespace MangaCatalog.Model
{
	public class Users
	{
		private static int nextId = 1;

		public int Id { get; private set; }
		public string Login { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public int Role { get; set; }

		public Users(string username, string login, string password, int role)
		{
			Id = GetNextId();
			Username = username;
			Login = login;
			Password = password;
			Role = role;
		}

		private int GetNextId()
		{
			return nextId++;
		}
	}
}