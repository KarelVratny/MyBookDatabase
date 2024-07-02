namespace MyBookDatabase.Models {
	public class Author {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Bio { get; set; }
		public DateTime DateOfBirth { get; set; }
		public DateTime? DateOfDeath { get; set; }
		public ICollection<Book> Books { get; set; } = new List<Book>();
	}
}
