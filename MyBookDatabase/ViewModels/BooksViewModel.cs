using System.ComponentModel;

namespace MyBookDatabase.ViewModels {
	public class BooksViewModel {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime PublicationDate { get; set; }
		public string Isbn { get; set; }
		public string AuthorName { get; set; }
		public int AuthorId { get; set; }
		public string GenreName { get; set; }
	}
}
