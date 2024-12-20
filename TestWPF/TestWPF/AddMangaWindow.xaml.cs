using System;
using System.Windows;
using TestWPF;

namespace TestWPF
{
	public partial class AddMangaWindow : Window
	{
		private CatalogPage catalogPage;

		public AddMangaWindow(CatalogPage main)
		{
			InitializeComponent();
			catalogPage = main;
		}

		private void AddManga_Click(object sender, RoutedEventArgs e)
		{
			if (double.TryParse(txtRating.Text, out double rating))
			{
				Manga newManga = new Manga
				{
					Title = txtTitle.Text,
					Author = txtAuthor.Text,
					Rating = rating,
					ImagePath = "manga.jpg"
				};

				catalogPage.MangaList.Add(newManga);
				Close();
			}
			else
			{
				MessageBox.Show("Please enter a valid rating.");
			}
		}
	}
}