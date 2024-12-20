using MangaCatalog.Model;
using System;
using System.Windows;

namespace MangaCatalog.View
{
	/// <summary>
	/// Interaction logic for AddMangaWindow.xaml
	/// </summary>
	public partial class AddMangaWindow : Window
	{
		public AddMangaWindow()
		{
			InitializeComponent();
		}

		private void addMangaButton_Click(object sender, RoutedEventArgs e)
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
				string imagePath = "D:\\!Univercity\\MangaCatalogWPF\\MangaCatalogWPF\\MangaCatalog\\Resources\\manga.jpg";
				DataManager.Instance.AddManga(title, type, year, rate, author, description, imagePath);
				this.Close();
			}
			else
			{
				MessageBox.Show("Please fill in all fields with correct data types.");
			}
		}

		private void TitleTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			if (TitleTextBox.Text == "Title")
			{
				TitleTextBox.Text = string.Empty;
			}
		}

		private void TitleTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
			{
				TitleTextBox.Text = "Title";
			}
		}

		private void TypeTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			if (TypeTextBox.Text == "Type")
			{
				TypeTextBox.Text = string.Empty;
			}
		}

		private void TypeTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(TypeTextBox.Text))
			{
				TypeTextBox.Text = "Type";
			}
		}

		private void YearTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			if (YearTextBox.Text == "Year")
			{
				YearTextBox.Text = string.Empty;
			}
		}

		private void YearTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(YearTextBox.Text))
			{
				YearTextBox.Text = "Year";
			}
		}

		private void RateTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			if (RateTextBox.Text == "Rate")
			{
				RateTextBox.Text = string.Empty;
			}
		}

		private void RateTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(RateTextBox.Text))
			{
				RateTextBox.Text = "Rate";
			}
		}

		private void AuthorTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			if (AuthorTextBox.Text == "Author")
			{
				AuthorTextBox.Text = string.Empty;
			}
		}

		private void AuthorTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(AuthorTextBox.Text))
			{
				AuthorTextBox.Text = "Author";
			}
		}

		private void DescriptionTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			if (DescriptionTextBox.Text == "Description")
			{
				DescriptionTextBox.Text = string.Empty;
			}
		}

		private void DescriptionTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
			{
				DescriptionTextBox.Text = "Description";
			}
		}
	}
}