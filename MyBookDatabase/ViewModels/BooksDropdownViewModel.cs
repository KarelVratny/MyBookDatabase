using MyBookDatabase.Models;

namespace MyBookDatabase.ViewModels {
	public class BooksDropdownViewModel {
		public List<Author> Authors { get; set; }
		public List<Genre> Genres { get; set; }
		public BooksDropdownViewModel() {
			Authors = new List<Author>();
			Genres = new List<Genre>();
		}
	}
}
