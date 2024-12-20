using MangaCatalog.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MangaCatalog
{
	/// <summary>
	/// Interaction logic for BookmarksPage.xaml
	/// </summary>
	public partial class BookmarksPage : Page
	{
		public event EventHandler<int> GoToMangaPage;
		public ObservableCollection<Manga> BookmarksList { get; set; }
		private int userId;

		public BookmarksPage(int id)
		{
			InitializeComponent();
			userId = id;
			BookmarksList = new ObservableCollection<Manga>();
			PopulateBookmarksList();

			DataContext = this;
		}

		private void PopulateBookmarksList()
		{
			BookmarksList.Clear();
			foreach (var bookmark in DataManager.Instance.Bookmarks.Where(b => b.UserId == userId))
			{
				var manga = DataManager.Instance.GetMangaById(bookmark.MangaId);
				if (manga != null)
				{
					BookmarksList.Add(manga);
				}
			}
		}

		private void MangaItem_Click(object sender, MouseButtonEventArgs e)
		{
			Manga selectedManga = (sender as FrameworkElement)?.DataContext as Manga;
			if (selectedManga != null)
			{
				GoToMangaPage?.Invoke(this, selectedManga.Id);
			}
		}
	}
}