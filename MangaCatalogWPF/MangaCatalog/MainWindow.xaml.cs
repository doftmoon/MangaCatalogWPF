using MangaCatalog.Model;
using MangaCatalog.View;
using MangaCatalog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using static MangaCatalog.LoginWindow;

namespace MangaCatalog
{
	public partial class MainWindow : Window
	{
		private PageManager _pageManager;
		private CatalogPage _catalogPage;
		public int userid;
		private bool isLogged = false;
		private bool isAdmin = false;
		public bool DoRemoveManga { get; set; }

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
			DoRemoveManga = false;
			_catalogPage = new CatalogPage();
			_catalogPage.GoToMangaPage += ChangePageToMangaPage_GoToMangaPage;

			_pageManager = new PageManager(PageContainer);
			_pageManager.NavigateTo(_catalogPage);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			LoginWindow loginWindow = new();
			loginWindow.Authenticated += LoginWindow_Authenticated;
			loginWindow.ShowDialog();
		}

		private void buttonRegister_Click(object sender, RoutedEventArgs e)
		{
			RegisterWindow registerWindow = new();
			registerWindow.ShowDialog();
		}

		private void LoginWindow_Authenticated(object sender, AuthenticationEventArgs e)
		{
			int userId = e.UserId;
			if (userId != -1)
			{
				Users user = DataManager.Instance.Users.FirstOrDefault(u => u.Id == userId);

				if (user != null)
				{
					if (user.Role == 1)
					{
						userid = userId;
						isLogged = true;
						isAdmin = false;
						guessNav.Visibility = Visibility.Hidden;
						userNav.Visibility = Visibility.Visible;
					}
					else if (user.Role == 2)
					{
						userid = userId;
						isLogged = true;
						isAdmin = true;
						guessNav.Visibility = Visibility.Hidden;
						userNav.Visibility = Visibility.Visible;
						adminNav.Visibility = Visibility.Visible;
					}
				}
			}
			else
			{
				MessageBox.Show("Invalid login or password.");
			}
		}

		private void buttonCatalog_Click(object sender, RoutedEventArgs e)
		{
			_pageManager.NavigateTo(_catalogPage);
		}

		private void ChangePageToMangaPage_GoToMangaPage(object sender, int mangaId)
		{
			Manga selectedManga = DataManager.Instance.GetMangaById(mangaId);
			if (selectedManga != null)
			{
				MangaPage mangaPage = new MangaPage(selectedManga, userid, isLogged, isAdmin);
				_pageManager.NavigateTo(mangaPage);
			}
		}

		private void buttonLogout_Click(object sender, RoutedEventArgs e)
		{
			userid = 0;
			isLogged = false;
			isAdmin = false;
			guessNav.Visibility = Visibility.Visible;
			userNav.Visibility = Visibility.Hidden;
			adminNav.Visibility = Visibility.Hidden;
		}

		private void AddManga_Click(object sender, RoutedEventArgs e)
		{
			AddMangaWindow addMangaWindow = new();
			addMangaWindow.ShowDialog();
		}

		private void ToggleRemoveMangaFlag_Click(object sender, RoutedEventArgs e)
		{
			if (DataContext is MainWindow mainWindow)
			{
				mainWindow.DoRemoveManga = !mainWindow.DoRemoveManga;
				if (mainWindow.DoRemoveManga == true)
				{
					buttonRemoveManga.Content = "Toggle off remove";
				}
				else
				{
					buttonRemoveManga.Content = "ToggleRemove";
				}
			}
		}

		private void AddMangaWindow_NewMangaAdded(object sender, EventArgs e)
		{
			_pageManager.NavigateTo(_catalogPage);
		}

		private void buttonBookmarks_Click(object sender, RoutedEventArgs e)
		{
			BookmarksPage bookmarksPage = new(userid);
			_pageManager.NavigateTo(bookmarksPage);
		}

		private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (_catalogPage != null)
			{
				_catalogPage.FilterMangaList(searchTextBox.Text);
			}
		}

		private void searchTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			if (searchTextBox.Text == "Search")
			{
				searchTextBox.Text = string.Empty;
			}
		}

		private void searchTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(searchTextBox.Text))
			{
				searchTextBox.Text = "Search";
			}
		}
	}
}