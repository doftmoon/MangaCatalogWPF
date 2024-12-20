using MangaCatalog.Model;
using System;
using System.Linq;
using System.Windows;

namespace MangaCatalog
{
	public partial class LoginWindow : Window
	{
		public event EventHandler<AuthenticationEventArgs> Authenticated;

		public LoginWindow()
		{
			InitializeComponent();
		}

		private void submitButton_Click(object sender, RoutedEventArgs e)
		{
			string login = loginTextBox.Text;
			string password = passwordTextBox.Text;

			if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
			{
				int userId = AuthenticateUser(login, password);
				if (userId != -1)
				{
					OnAuthenticated(userId);
				}
				else
				{
					MessageBox.Show("Invalid login or password.");
				}
				this.Close();
			}
			else
			{
				MessageBox.Show("Please fill in all fields.");
			}
		}

		private int AuthenticateUser(string login, string password)
		{
			Users user = DataManager.Instance.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
			return user?.Id ?? -1;
		}

		private void OnAuthenticated(int userId)
		{
			Authenticated?.Invoke(this, new AuthenticationEventArgs(userId));
		}

		public class AuthenticationEventArgs : EventArgs
		{
			public int UserId { get; }

			public AuthenticationEventArgs(int userId)
			{
				UserId = userId;
			}
		}

		private void closeWindow_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void loginTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			if (loginTextBox.Text == "Login")
			{
				loginTextBox.Text = string.Empty;
			}
		}

		private void loginTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(loginTextBox.Text))
			{
				loginTextBox.Text = "Login";
			}
		}

		private void passwordTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			if (passwordTextBox.Text == "Password")
			{
				passwordTextBox.Text = string.Empty;
			}
		}

		private void passwordTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
			{
				passwordTextBox.Text = "Password";
			}
		}
	}
}