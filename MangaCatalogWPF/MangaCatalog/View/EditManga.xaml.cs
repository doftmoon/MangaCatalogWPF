using MangaCatalog.Model;
using System;
using System.Windows;

namespace MangaCatalog.View
{
	/// <summary>
	/// Interaction logic for EditManga.xaml
	/// </summary>
	public partial class EditManga : Window
	{
		Manga manga;
		public EditManga(Manga mangaIn)
		{
			InitializeComponent();
			manga = mangaIn;
		}

		private void editMangaButton_Click(object sender, RoutedEventArgs e)
		{
			string title = TitleTextBox.Text;
			string type = TypeTextBox.Text;
			int year;
			double rate;
			string author = AuthorTextBox.Text;
			string description = DescriptionTextBox.Text;

			if (int.TryParse(YearTextBox.Text, out year) && double.TryParse(RateTextBox.Text, out rate) &&
				!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(author) && !string.IsNullOrEmpty(description))
			{
				manga.Title = title;
				manga.Type = type;
				manga.Year = year;
				manga.Rate = rate;
				manga.Author = author;
				manga.Description = description;
				DataManager.Instance.EditManga(manga);
				this.Close();
			}
			else
			{
				MessageBox.Show("Please fill in all fields with correct data types.");
			}
		}
	}
}