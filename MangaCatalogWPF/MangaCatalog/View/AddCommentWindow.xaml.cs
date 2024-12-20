using MangaCatalog.Model;
using System;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MangaCatalog.View
{
	/// <summary>
	/// Interaction logic for AddCommentWindow.xaml
	/// </summary>
	public partial class AddCommentWindow : Window
	{
		int mangaId;
		int userId;
		public AddCommentWindow(int manga, int user)
		{
			InitializeComponent();
			mangaId = manga;
			userId = user;
		}

		private void addCommentButton_Click(object sender, RoutedEventArgs e)
		{
			string comment = CommentTextBox.Text;

			if (!string.IsNullOrEmpty(comment))
			{
				DataManager.Instance.AddComment(mangaId, userId, comment, "Today");
				this.Close();
			}
			else
			{
				MessageBox.Show("Please fill in all fields.");
			}
		}
	}
}