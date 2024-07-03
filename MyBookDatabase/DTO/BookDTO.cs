using MyBookDatabase.Models;
using System.ComponentModel;

namespace MyBookDatabase.DTO {
	public class BookDTO {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		[DisplayName("Publication Date")]
		public DateTime PublicationDate { get; set; }
		public string Isbn { get; set; }
		[DisplayName("Author")]
		public int AuthorId { get; set; }
		[DisplayName("Genre")]
		public int GenreId { get; set; }
	}
}
