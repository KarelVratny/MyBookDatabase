﻿namespace MyBookDatabase.Models {
	public class Book {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime PublicationDate { get; set; }
		public int Isbn { get; set; }
		public int AuthorId { get; set; }
		public Author Author { get; set; }
		public int GenreId { get; set; }
		public Genre Genre { get; set; }
	}
}
