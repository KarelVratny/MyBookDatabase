using MyBookDatabase.Models;

namespace MyBookDatabase.DTO {
	public class GenreDTO {
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Book> Books { get; set; }
	}
}
