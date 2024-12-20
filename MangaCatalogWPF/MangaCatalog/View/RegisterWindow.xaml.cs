using MangaCatalog.Model;
using System;
using System.Windows;

namespace MangaCatalog
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                DataManager.Instance.AddUser(username, login, password, 1);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
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

		private void usernameTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			if (usernameTextBox.Text == "Username")
			{
				usernameTextBox.Text = string.Empty;
			}
		}

		private void usernameTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(usernameTextBox.Text))
			{
				usernameTextBox.Text = "Username";
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