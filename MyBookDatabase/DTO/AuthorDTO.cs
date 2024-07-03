using MyBookDatabase.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyBookDatabase.DTO {
	public class AuthorDTO {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Bio { get; set; }
		[DisplayName("Date of birth")]
		public DateTime DateOfBirth { get; set; }
		[DisplayName("Date of death")]
		public DateTime? DateOfDeath { get; set; }
		public ICollection<Book> Books { get; set; }
	}
}
