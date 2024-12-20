using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
	public class Manga
	{
		public Manga(string title, string type, double rating, string imagePath)
		{
			Title = title;
			Type = type;
			Rating = rating;
			ImagePath = imagePath;
		}

		public Manga()
		{
		}

		public string Title { get; set; }
		public string Type { get; set; }
		public double Rating { get; set; }
		public string? Author { get; set; }
		public string? Description { get; set; }
		public string ImagePath { get; set; }
	}
}
