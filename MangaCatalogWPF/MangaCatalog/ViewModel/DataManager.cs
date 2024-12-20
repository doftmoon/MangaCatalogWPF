using MangaCatalog.Model;
using System.Collections.ObjectModel;
using System.Linq;

public class DataManager
{
	public event EventHandler MangaUpdated;
	public event EventHandler CommentsUpdated;
	private static DataManager _instance;
	private ObservableCollection<Users> _users;
	private ObservableCollection<Manga> _mangas;
	private ObservableCollection<Bookmarks> _bookmarks;
	private ObservableCollection<Comments> _comments;

	private DataManager()
	{
		_users = new ObservableCollection<Users>();
		_mangas = new ObservableCollection<Manga>();
		_bookmarks = new ObservableCollection<Bookmarks>();
		_comments = new ObservableCollection<Comments>();
	}

	public static DataManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new DataManager();
			}
			return _instance;
		}
	}

	public ObservableCollection<Users> Users => _users;
	public ObservableCollection<Manga> Mangas => _mangas;
	public ObservableCollection<Bookmarks> Bookmarks => _bookmarks;
	public ObservableCollection<Comments> Comments => _comments;

	public void AddUser(string username, string login, string password, int role)
	{
		Users.Add(new Users(username, login, password, role));
	}

	public void RemoveUser(int userId)
	{
		var userToRemove = Users.FirstOrDefault(u => u.Id == userId);
		if (userToRemove != null)
		{
			Users.Remove(userToRemove);
		}
	}

	public void AddManga(string title, string type, int year, double rate, string author, string description, string imagePath)
	{
		Mangas.Add(new Manga(title, type, year, rate, author, description, imagePath));
		if (MangaUpdated != null)
		{
			MangaUpdated.Invoke(this, EventArgs.Empty);
		}
	}

	public void EditManga(Manga updatedManga)
	{
		var existingManga = Mangas.FirstOrDefault(m => m.Id == updatedManga.Id);
		if (existingManga != null)
		{
			existingManga.Title = updatedManga.Title;
			existingManga.Type = updatedManga.Type;
			existingManga.Year = updatedManga.Year;
			existingManga.Rate = updatedManga.Rate;
			existingManga.Author = updatedManga.Author;
			existingManga.Description = updatedManga.Description;
			existingManga.ImagePath = updatedManga.ImagePath;
		}
		if (MangaUpdated != null)
		{
			MangaUpdated.Invoke(this, EventArgs.Empty);
		}
	}

	public void RemoveManga(int mangaId)
	{
		var mangaToRemove = Mangas.FirstOrDefault(m => m.Id == mangaId);
		if (mangaToRemove != null)
		{
			Mangas.Remove(mangaToRemove);
			if (MangaUpdated != null)
			{
				MangaUpdated.Invoke(this, EventArgs.Empty);
			}
		}
	}

	public void AddBookmark(int userId, int mangaId)
	{
		Bookmarks.Add(new Bookmarks(userId, mangaId));
	}

	public void RemoveBookmark(int userId, int mangaId)
	{
		var bookmarkToRemove = Bookmarks.FirstOrDefault(b => b.UserId == userId && b.MangaId == mangaId);
		if (bookmarkToRemove != null)
		{
			Bookmarks.Remove(bookmarkToRemove);
		}
	}

	public bool HasBookmark(int userId, int mangaId)
	{
		return Bookmarks.Any(b => b.UserId == userId && b.MangaId == mangaId);
	}

	public void AddComment(int mangaId, int userId, string comment, string date)
	{
		Comments.Add(new Comments(mangaId, userId, comment, date));
		if (CommentsUpdated != null)
		{
			CommentsUpdated.Invoke(this, EventArgs.Empty);
		}
	}

	public void RemoveComment(int commentId)
	{
		var commentToRemove = Comments.FirstOrDefault(c => c.Id == commentId);
		if (commentToRemove != null)
		{
			Comments.Remove(commentToRemove);
			if (CommentsUpdated != null)
			{
				CommentsUpdated.Invoke(this, EventArgs.Empty);
			}
		}
	}

	public Manga GetMangaById(int mangaId)
	{
		return Mangas.FirstOrDefault(m => m.Id == mangaId);
	}

	public Comments GetCommentsByMangaId(int mangaId)
	{
		return Comments.FirstOrDefault(c => c.Id == mangaId);
	}

	public string GetUsernameById(int userId)
	{
		return Users.FirstOrDefault(u => u.Id == userId)?.Username;
	}
}