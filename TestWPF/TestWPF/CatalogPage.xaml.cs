using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWPF
{
	/// <summary>
	/// Логика взаимодействия для CatalogPage.xaml
	/// </summary>
	public partial class CatalogPage : Page
	{
		MainWindow mainWindow;
		public ObservableCollection<Manga> MangaList { get; set; }

		public CatalogPage(MainWindow mainWindow)
		{
			InitializeComponent();
			this.mainWindow = mainWindow;
			MangaList = new ObservableCollection<Manga>
			{
				new Manga { Title = "Manga 1", Type = "Manga", Rating = 4.5, ImagePath = "manga.jpg" },
				new Manga { Title = "Manga 2", Type = "Manhwa", Rating = 4.0, ImagePath = "manga.jpg" },
				new Manga { Title = "Manga 3", Type = "Manga", Rating = 7.5, ImagePath = "manga.jpg" },
				new Manga { Title = "Manga 4", Type = "Manhwa", Rating = 4.0, ImagePath = "manga.jpg" },
				new Manga { Title = "Manga 5", Type = "Manga", Rating = 3.5, ImagePath = "manga.jpg" },
				new Manga { Title = "Manga 6", Type = "Manhwa", Rating = 1.0, ImagePath = "manga.jpg" },
			};
			DataContext = this;
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
}
