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
			MainFrame.Navigate(new CatalogPage(this));
		}

		private void SortByTitle_Click(object sender, RoutedEventArgs e)
		{
			MangaList = new ObservableCollection<Manga>(MangaList.OrderBy(m => m.Title));
		}

		private void SortByAuthor_Click(object sender, RoutedEventArgs e)
		{
			MangaList = new ObservableCollection<Manga>(MangaList.OrderBy(m => m.Author));
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

		private void AddManga_Click(object sender, RoutedEventArgs e)
		{
			AddMangaWindow addMangaWindow = new AddMangaWindow(new CatalogPage(this));
			addMangaWindow.ShowDialog();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			guessPanel.Visibility = Visibility.Hidden;
			userPanel.Visibility = Visibility.Visible;
		}

		private void Button2_Click(object sender, RoutedEventArgs e)
		{
			guessPanel.Visibility = Visibility.Visible;
			userPanel.Visibility = Visibility.Hidden;
		}

		private void buttonRegister_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}