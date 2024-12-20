namespace MangaCatalog.Model
{
	public class Manga
	{
		private static int nextId = 1;

		public int Id { get; set; }
		public string Title { get; set; }
		public string Type { get; set; }
		public int Year { get; set; }
		public double Rate { get; set; }
		public string Author { get; set; }
		public string Description { get; set; }
		public string ImagePath { get; set; }

		public Manga(string title, string type, int year, double rate, string author, string description, string imagePath)
		{
			Id = GetNextId();
			Title = title;
			Type = type;
			Year = year;
			Rate = rate;
			Author = author;
			Description = description;
			ImagePath = imagePath;
		}

		private int GetNextId()
		{
			return nextId++;
		}
	}
}