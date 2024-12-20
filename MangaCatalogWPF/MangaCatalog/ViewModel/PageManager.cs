using System.Windows.Controls;

namespace MangaCatalog.ViewModel
{
	internal class PageManager
	{
		private Frame _frame;
		private Page _currentPage;

		public Page CurrentPage => _currentPage; // Добавление свойства CurrentPage для доступа к текущей странице

		public PageManager(Frame frame)
		{
			_frame = frame;
		}

		public void NavigateTo(Page page)
		{
			if (_currentPage != null && _currentPage.GetType() == page.GetType())
			{
				return;
			}

			if (_currentPage != null)
			{
				_frame.Content = null;
				_currentPage = null;
			}

			_frame.Content = page;
			_currentPage = page;
		}
	}
}