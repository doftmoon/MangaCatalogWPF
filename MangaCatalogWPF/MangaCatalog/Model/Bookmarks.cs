namespace MangaCatalog.Model
{
	public class Bookmarks
	{
		private static int nextId = 1;

		public int Id { get; set; }
		public int UserId { get; set; }
		public int MangaId { get; set; }

		public Bookmarks(int userId, int mangaId)
		{
			Id = GetNextId();
			UserId = userId;
			MangaId = mangaId;
		}

		private int GetNextId()
		{
			return nextId++;
		}
	}
}