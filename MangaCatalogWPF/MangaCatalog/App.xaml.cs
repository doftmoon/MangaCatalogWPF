using System.Configuration;
using System.Data;
using System.Windows;

namespace MangaCatalog
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			LoadInitialData();
		}

		private void LoadInitialData()
		{
			DataManager.Instance.AddManga("Sweet House", "Manhwa", 2017, 9.5, "Carnby", "How much does it take for a hikikomori to be happy? Just sit within your own four walls, drive everyone away and immerse yourself in your computer. But what if suddenly your parents and sister die? Well, let them leave “kopecks”.", "D:\\!Univercity\\MangaCatalogWPF\\MangaCatalogWPF\\MangaCatalog\\Resources\\dom.jpg");
			DataManager.Instance.AddManga("Designer", "Manhwa", 2021, 9.7, "Lee Hyun", "Civil engineer Kim Su Ho has become an aristocrat on the pages of a novel. But here's the problem! His estate is on the verge of bankruptcy. In such a situation, he needs to save his lands. Design, build and sell - that's his path. [This is a unique opportunity that the entire continent has been waiting for! Ideal transportation links, the best school district, a picturesque forest area, as well as Baron Frontera, the owner of exclusive premium real estate, await you. The conclusion of the purchase and sale agreement occurs in turn!]", "D:\\!Univercity\\MangaCatalogWPF\\MangaCatalogWPF\\MangaCatalog\\Resources\\archetect.jpg");
			DataManager.Instance.AddManga("Strongest Professor", "Manhwa", 2022, 9.3, "Sol", "Having become a professor at the prestigious Theon Academy, I found myself in this position due to some misunderstanding... or was I mistaken for someone else?... With my powerful magical abilities and skills as a knight, it wasn't that difficult for me to pretend to be a teacher, but it was much more difficult than I expected. Now I'm in a difficult situation, trying to balance on two chairs and collecting information. Where will this dangerous game of walking on the edge of a cliff take me?", "D:\\!Univercity\\MangaCatalogWPF\\MangaCatalogWPF\\MangaCatalog\\Resources\\professor.jpg");
			DataManager.Instance.AddManga("The boxer", "Manhwa", 2019, 8.1, "Callisto", "A unique gift that no one can resist! Is it a gift or a curse - what is its true nature?!", "D:\\!Univercity\\MangaCatalogWPF\\MangaCatalogWPF\\MangaCatalog\\Resources\\boxer.jpg");
			DataManager.Instance.AddManga("Saint demon", "Manga", 2020, 7.2, "Ken", "\"Only your actions maintain harmony in life... It is on them that you must rely!..\" The successor of the Artful Spear Sect and his disciple Hyuk Un-Seong were caught studying the forbidden Demonic art and were subsequently sentenced to death. \"Pathetic hypocrites, adhering to the principles of their sect!..\" However, when Hyuk Un-Seong found himself before the gates of hell, the artifact of the Artful Spear Sect began to emit a strange light, gifting the young man with a new life. Two opposites: a sect that professes only goodness, and a sect deep in the study of demonic techniques. Accepting his fate and remembering all the malice that has accumulated within him, Un-Seong begins his path to becoming a martial artist, in order to ultimately take revenge... Take revenge on those who betrayed him! A story about life and death, about good and evil, about chance encounters and luck... It begins!", "D:\\!Univercity\\MangaCatalogWPF\\MangaCatalogWPF\\MangaCatalog\\Resources\\demon.jpg");
			DataManager.Instance.AddManga("Deadly mist", "Manhwa", 2021, 8.8, "Sol", "The fire in Gangnam left him blind and his parents dead. All he could see was a being called Kkamjang. Is Kkamjang an illusion or something more? \"Your wounds, your eyes, even... your power! I can change everything for you.\"", "D:\\!Univercity\\MangaCatalogWPF\\MangaCatalogWPF\\MangaCatalog\\Resources\\mgla.jpg");
			DataManager.Instance.AddManga("Medical Reincarnation", "Manhwa", 2019, 9.3, "Yuin", "Kim Ji Hoon leads the life of a failed surgeon, but suddenly he has the opportunity to start over. He returns to his school days, determined to become an outstanding dermatologist and earn big money!", "D:\\!Univercity\\MangaCatalogWPF\\MangaCatalogWPF\\MangaCatalog\\Resources\\med.jpg");
			DataManager.Instance.AddManga("The Immortal Emperor Luo Wuji Has Returned", "Manhua", 2021, 8.6, "Da Mowang", "The immortal Luo Wuji is reborn in the modern era, during the period when he was still a teenager.", "D:\\!Univercity\\MangaCatalogWPF\\MangaCatalogWPF\\MangaCatalog\\Resources\\immortal.jpg");
			DataManager.Instance.AddManga("Dungeon Seeker", "Manga", 2016, 8.3, "Sakomoto", "fafafajfoafafionafainoggdrwwrwffafia", "D:\\!Univercity\\MangaCatalogWPF\\MangaCatalogWPF\\MangaCatalog\\Resources\\dungeon.jpg");
			DataManager.Instance.AddUser("Artem", "admin", "1234", 2);
			DataManager.Instance.AddUser("Dasha", "dasha", "12", 1);
			DataManager.Instance.AddUser("Pepega", "pepega", "12", 1);
			DataManager.Instance.AddUser("Deez nuts", "deez", "12", 1);
			DataManager.Instance.AddBookmark(2, 2);
			DataManager.Instance.AddBookmark(2, 5);
			DataManager.Instance.AddBookmark(2, 7);
			DataManager.Instance.AddBookmark(3, 1);
			DataManager.Instance.AddBookmark(3, 5);
			DataManager.Instance.AddBookmark(4, 3);
			DataManager.Instance.AddBookmark(4, 5);
			DataManager.Instance.AddComment(1, 2, "Aint no way I'm the first to comment", DateTime.Now.ToString());
			DataManager.Instance.AddComment(3, 1, "it it even a comment", DateTime.Now.ToString());
			DataManager.Instance.AddComment(5, 2, "Aint no way I'm the the comment", DateTime.Now.ToString());
			DataManager.Instance.AddComment(3, 2, "Aint no way I'm the first", DateTime.Now.ToString());
			DataManager.Instance.AddComment(5, 2, "I WILL DESCRIBE THE TITLE BRIEFLY, RISK 7/10, PLOT 9/10, AND OVERALL I WOULD GIVE IT 10/10 POINTS, BECAUSE ONLY ONE PERSON WORKED ON THE MANGA, OUT OF RESPECT FOR YOUR WORK I GIVE THIS ASSESSMENT, AND IN 2 WEEKS THE AUTHOR PROMISED THAT SOMETHING INTERESTING WOULD COME OUT, I WILL WAIT. YOUR FAVORITE FAN", DateTime.Now.ToString());
			DataManager.Instance.AddComment(3, 1, "it it even a comment", DateTime.Now.ToString());
			DataManager.Instance.AddComment(5, 3, "Aint no way I'm the the comment", DateTime.Now.ToString());
			DataManager.Instance.AddComment(3, 4, "Aint no way I'm the first", DateTime.Now.ToString());
			DataManager.Instance.AddComment(5, 3, "Aint no way I'm the first to comment", DateTime.Now.ToString());
			DataManager.Instance.AddComment(4, 4, "it it even a comment", DateTime.Now.ToString());
			DataManager.Instance.AddComment(6, 4, "Aint no way I'm the the comment", DateTime.Now.ToString());
			DataManager.Instance.AddComment(3, 3, "Aint no way I'm the first", DateTime.Now.ToString());
		}
	}

}
