namespace MangaCatalog.Model
{
	public class Comments
	{
		private static int nextId = 1;

		public int Id { get; set; }
		public int MangaId { get; set; }
		public int UserId { get; set; }
		public string Comment { get; set; }
		public string Date { get; set; }

		public Comments(int mangaId, int userId, string comment, string date)
		{
			Id = GetNextId();
			MangaId = mangaId;
			UserId = userId;
			Comment = comment;
			Date = date;
		}

		private int GetNextId()
		{
			return nextId++;
		}
	}
}