using MangaCatalog.Model;
using MangaCatalog.View;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MangaCatalog
{
	/// <summary>
	/// Interaction logic for MangaPage.xaml
	/// </summary>
	public partial class MangaPage : Page
	{
		public Manga SelectedManga { get; set; }
		public ObservableCollection<CommentItem> CommentsList { get; set; }
		public int user;
		private bool isLogged = false;
		private bool isAdmin = false;

		public MangaPage(Manga selectedManga, int userId, bool isUserLogged, bool isUserAdmin)
		{
			InitializeComponent();

			SelectedManga = selectedManga;
			user = userId;
			isLogged = isUserLogged;
			isAdmin = isUserAdmin;
			RefreshManga();

			CommentsList = new ObservableCollection<CommentItem>();
			DataManager.Instance.CommentsUpdated += DataManager_CommentsUpdated;
			RefreshComments();

			if (isLogged)
			{
				if (DataManager.Instance.HasBookmark(user, SelectedManga.Id))
				{
					addBookmarkButton.Content = "Remove Bookmark";
				}
				else
				{
					addBookmarkButton.Content = "Add Bookmark";
				}

				addBookmarkButton.Visibility = Visibility.Visible;
				addCommentButton.Visibility = Visibility.Visible;
			}
			else
			{
				addBookmarkButton.Visibility = Visibility.Collapsed;
				addCommentButton.Visibility = Visibility.Collapsed;
			}

			if (isAdmin)
			{
				editMangaButton.Visibility = Visibility.Visible;
			}
			else
			{
				editMangaButton.Visibility = Visibility.Collapsed;
			}

			DataContext = this;
		}

		private void RefreshManga()
		{
			BitmapImage bitmap = new BitmapImage();
			bitmap.BeginInit();
			bitmap.UriSource = new Uri(SelectedManga.ImagePath, UriKind.RelativeOrAbsolute);
			bitmap.EndInit();

			coverImage.Source = bitmap;
			typeTextBox.Text = SelectedManga.Type;
			yearTextBlock.Text = SelectedManga.Year.ToString();
			titleTextBlock.Text = SelectedManga.Title;
			authorTextBlock.Text = SelectedManga.Author;
			rateTextBlock.Text = SelectedManga.Rate.ToString();
			descriptionTextBlock.Text = SelectedManga.Description;
		}

		private void DataManager_CommentsUpdated(object sender, EventArgs e)
		{
			RefreshComments();
		}

		private void RefreshComments()
		{
			CommentsList.Clear();

			foreach (var comment in DataManager.Instance.Comments)
			{
				if (SelectedManga.Id == comment.MangaId)
				{
					Visibility rc;
					if (comment.UserId == user || isAdmin)
					{
						rc = Visibility.Visible;
					}
					else
					{
						rc = Visibility.Hidden;
					}
					CommentsList.Add(new CommentItem(comment, rc, DataManager.Instance.GetUsernameById(comment.UserId)));
				}
			}
		}

		private void addCommentButton_Click(object sender, RoutedEventArgs e)
		{
			int mangaId = SelectedManga.Id;
			int userId = user;
			AddCommentWindow addCommentWindow = new AddCommentWindow(mangaId, userId);
			addCommentWindow.ShowDialog();
		}

		private void editMangaButton_Click(object sender, RoutedEventArgs e)
		{
			EditManga editManga = new EditManga(SelectedManga);
			editManga.ShowDialog();
		}

		private void DeleteComment_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			if (button != null)
			{
				CommentItem comment = button.DataContext as CommentItem;
				if (comment != null)
				{
					DataManager.Instance.RemoveComment(comment.Comment.Id);
				}
			}
		}

		private void addBookmarkButton_Click(object sender, RoutedEventArgs e)
		{
			if (DataManager.Instance.HasBookmark(user, SelectedManga.Id))
			{
				DataManager.Instance.RemoveBookmark(user, SelectedManga.Id);
				addBookmarkButton.Content = "Add to Bookmarks";
			}
			else
			{
				DataManager.Instance.AddBookmark(user, SelectedManga.Id);
				addBookmarkButton.Content = "Remove from Bookmarks";
			}
		}

		public class CommentItem
		{
			public CommentItem(Comments comment, Visibility showDeleteButton, string username)
			{
				Comment = comment;
				ButtVis = showDeleteButton;
				Username = username;
			}

			public Comments Comment { get; set; }
			public Visibility ButtVis { get; set; }
			public string Username { get; set; }
		}
	}
}