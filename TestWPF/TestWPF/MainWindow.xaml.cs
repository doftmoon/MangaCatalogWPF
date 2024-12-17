using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using System;
using System.Windows.Input;

namespace TestWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public ObservableCollection<Manga> MangaList { get; set; }

		public MainWindow()
		{
			InitializeComponent();
			MangaList = new ObservableCollection<Manga>
			{
				new Manga { Title = "Manga 1", Author = "Author 1", Rating = 4.5, ImagePath = "manga.jpg" },
				new Manga { Title = "Manga 2", Author = "Author 2", Rating = 4.0, ImagePath = "manga.jpg" },
                // Добавьте другие манги здесь
            };
			DataContext = this;
		}

		private void SortByTitle_Click(object sender, RoutedEventArgs e)
		{
			MangaList = new ObservableCollection<Manga>(MangaList.OrderBy(m => m.Title));
		}

		private void SortByAuthor_Click(object sender, RoutedEventArgs e)
		{
			MangaList = new ObservableCollection<Manga>(MangaList.OrderBy(m => m.Author));
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			AddMangaWindow addMangaWindow = new AddMangaWindow(this);
			addMangaWindow.ShowDialog();
		}

		private void MangaItem_Click(object sender, MouseButtonEventArgs e)
		{
			var selectedManga = (sender as FrameworkElement)?.DataContext as Manga;
			if (selectedManga != null)
			{
				// Открываем новое окно или страницу с подробной информацией о выбранной манге
				MangaDetailWindow mangaDetailWindow = new MangaDetailWindow(selectedManga);
				mangaDetailWindow.ShowDialog();
			}
		}
	}

	public class Manga
	{
		public string Title { get; set; }
		public string Author { get; set; }
		public double Rating { get; set; }
		public string ImagePath { get; set; }
	}
}