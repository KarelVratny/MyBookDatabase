using MyBookDatabase.Models;
using System.ComponentModel.DataAnnotations;

namespace MyBookDatabase.DTO {
	public class AuthorDTO {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Bio { get; set; }
		public DateTime DateOfBirth { get; set; }
		public DateTime? DateOfDeath { get; set; }
		public ICollection<Book> Books { get; set; }
	}
}
