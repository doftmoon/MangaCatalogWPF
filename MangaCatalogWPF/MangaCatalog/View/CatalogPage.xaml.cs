using MangaCatalog.Model;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MangaCatalog
{
	/// <summary>
	/// Interaction logic for CatalogPage.xaml
	/// </summary>
	public partial class CatalogPage : Page
	{
		public event EventHandler<int> GoToMangaPage; // Событие передачи Id манги

		public ObservableCollection<Manga> MangaList { get; set; }

		public CatalogPage()
		{
			InitializeComponent();

			MangaList = new ObservableCollection<Manga>();
			DataManager.Instance.MangaUpdated += DataManager_MangaUpdated;
			RefreshMangaList();

			DataContext = this;
		}

		private void DataManager_MangaUpdated(object sender, EventArgs e)
		{
			RefreshMangaList();
		}

		private void RefreshMangaList()
		{
			MangaList.Clear();

			foreach (var manga in DataManager.Instance.Mangas)
			{
				MangaList.Add(manga);
			}
		}

		private void MangaItem_Click(object sender, MouseButtonEventArgs e)
		{
			Manga selectedManga = (sender as FrameworkElement)?.DataContext as Manga;
			if (selectedManga != null)
			{
				MainWindow mainWindow = Application.Current.MainWindow as MainWindow; // Получаем экземпляр MainWindow

				if (mainWindow != null && mainWindow.DoRemoveManga)
				{
					MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this manga?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
					if (result == MessageBoxResult.Yes)
					{
						DataManager.Instance.RemoveManga(selectedManga.Id);
						RefreshMangaList(); // Предполагая, что RefreshMangaList обновляет список манг
					}
				}
				else
				{
					GoToMangaPage?.Invoke(this, selectedManga.Id); // Передача Id манги
				}
			}
		}

		public void FilterMangaList(string searchText)
		{
			MangaList.Clear();

			foreach (var manga in DataManager.Instance.Mangas)
			{
				if (manga.Title.ToLower().Contains(searchText.ToLower()))
				{
					MangaList.Add(manga);
				}
			}
		}

		private void applyFiltersButton_Click(object sender, RoutedEventArgs e)
		{
			int fromYear, toYear;
			double fromRate, toRate;

			if (!int.TryParse(fromYearTextBox.Text, out fromYear))
			{
				fromYear = 1970;
			}

			if (!int.TryParse(toYearTextBox.Text, out toYear))
			{
				toYear = DateTime.Now.Year;
			}

			if (!double.TryParse(fromRateTextBox.Text, out fromRate))
			{
				fromRate = 0;
			}

			if (!double.TryParse(toRateTextBox.Text, out toRate))
			{
				toRate = 10;
			}

			MangaList.Clear();

			foreach (var manga in DataManager.Instance.Mangas)
			{
				if ((manga.Year >= fromYear && manga.Year <= toYear) && (manga.Rate >= fromRate && manga.Rate <= toRate))
				{
					MangaList.Add(manga);
				}
			}
		}
	}
}