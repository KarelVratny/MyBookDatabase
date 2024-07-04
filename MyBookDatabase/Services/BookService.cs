using Microsoft.EntityFrameworkCore;
using MyBookDatabase.DTO;
using MyBookDatabase.Models;
using MyBookDatabase.ViewModels;
using System.Diagnostics;

namespace MyBookDatabase.Services {
	public class BookService {
		private ApplicationDbContext _dbContext;
		public BookService(ApplicationDbContext dbContext) {
			this._dbContext = dbContext;
		}
		public async Task CreateAsync(BookDTO bookDTO) {
			Book bookToInsert = await DtoToModel(bookDTO);
			await _dbContext.AddAsync(bookToInsert);
			await _dbContext.SaveChangesAsync();
		}
		public async Task UpdateAsync(int id, BookDTO updatedBook) {
			Book bookToUpgrade = await DtoToModel(updatedBook);
			_dbContext.Books.Update(bookToUpgrade);
			await _dbContext.SaveChangesAsync();
		}
		public async Task DeleteAsync(int id) {
			var bookToDelete = _dbContext.Books.FirstOrDefault(book => book.Id == id);
			_dbContext.Books.Remove(bookToDelete);
			_dbContext.SaveChanges();
		}
		public async Task<BooksDropdownViewModel> GetNewBooksDropdownsValues() {
			var booksDropdownsData = new BooksDropdownViewModel() {
				Authors = await _dbContext.Authors.OrderBy(author =>
				author.Name).ToListAsync(),
				Genres = await _dbContext.Genres.OrderBy(genre =>
				genre.Name).ToListAsync(),
			};
			return booksDropdownsData;
		}
		public async Task<Book> GetByIdAsync(int id) {
			return await _dbContext.Books.Include(book => book.Author).Include(book => book.Genre).FirstOrDefaultAsync(book => book.Id == id);
		}
		public async Task<IEnumerable<BooksViewModel>> GetAllViewModelsAsync() {
			List<Book> books = await _dbContext.Books.Include(book => book.Author).Include(book => book.Genre).ToListAsync();
			List<BooksViewModel> booksViewModels = new List<BooksViewModel>();
			foreach (var book in books) {
				booksViewModels.Add(ModelToViewModel(book));
			}
			return booksViewModels;
		}
		private async Task<Book> DtoToModel(BookDTO bookDTO) {
			return new Book() {
				Id = bookDTO.Id,
				Title = bookDTO.Title,
				Description = bookDTO.Description,
				PublicationDate = bookDTO.PublicationDate,
				Isbn = bookDTO.Isbn,
				AuthorId = bookDTO.AuthorId,
				Author = await _dbContext.Authors.FirstOrDefaultAsync(author => author.Id == bookDTO.AuthorId),
				GenreId = bookDTO.GenreId,
				Genre = await _dbContext.Genres.FirstOrDefaultAsync(genre => genre.Id == bookDTO.GenreId)
			};
		}
		public async Task<BookDTO> ModelToDto(Book book) {
			return new BookDTO() {
				Id = book.Id,
				Title = book.Title,
				Description = book.Description,
				PublicationDate = book.PublicationDate,
				Isbn = book.Isbn,
				AuthorId = book.AuthorId,
				GenreId = book.GenreId
			};
		}
		private BooksViewModel ModelToViewModel(Book book) {
			return new BooksViewModel {
				Id = book.Id,
				Title = book.Title,
				Description = book.Description,
				PublicationDate = book.PublicationDate,
				Isbn = book.Isbn,
				AuthorName = book.Author.Name,
				AuthorId = book.Author.Id,
				GenreName = book.Genre.Name
			};
		}
	}
}
