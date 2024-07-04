using Microsoft.EntityFrameworkCore;
using MyBookDatabase.DTO;
using MyBookDatabase.Models;

namespace MyBookDatabase.Services {
	public class AuthorService {
		private ApplicationDbContext _dbContext;
		public AuthorService(ApplicationDbContext dbContext) {
			this._dbContext = dbContext;
		}
		public async Task<ICollection<AuthorDTO>> GetAllAsync() {
			var allAuthors = await _dbContext.Authors.Include(author => author.Books).ToListAsync();
			var authorDtos = new List<AuthorDTO>();
			foreach (var item in allAuthors) {
				authorDtos.Add(ModelToDto(item));
			}
			return authorDtos;
		}
		public async Task CreateAsync(AuthorDTO newAuthor) {
			await _dbContext.Authors.AddAsync(DtoToModel(newAuthor));
			await _dbContext.SaveChangesAsync();
		}
		public async Task<AuthorDTO> GetByIdAsync(int id) {
			var author = await _dbContext.Authors.FirstOrDefaultAsync(author => author.Id == id);
			if (author == null) {
				return null;
			}
			return ModelToDto(author);
		}
		public async Task UpdateAsync(int id, AuthorDTO authorToEdit) {
			_dbContext.Update(DtoToModel(authorToEdit));
			await _dbContext.SaveChangesAsync();
		}
		internal async Task DeleteAsync(int id) {
			var authorToDelete = await _dbContext.Authors.FirstOrDefaultAsync(author => author.Id == id);
			_dbContext.Authors.Remove(authorToDelete);
			await _dbContext.SaveChangesAsync();
		}
		private Author DtoToModel(AuthorDTO item) {
			return new Author() {
				Id = item.Id,
				Name = item.Name,
				Bio = item.Bio,
				DateOfBirth = item.DateOfBirth,
				DateOfDeath = item.DateOfDeath,
				Books = item.Books
			};
		}
		private AuthorDTO ModelToDto(Author item) {
			return new AuthorDTO() {
				Id = item.Id,
				Name = item.Name,
				Bio = item.Bio,
				DateOfBirth = item.DateOfBirth,
				DateOfDeath = item.DateOfDeath,
				Books = item.Books
			};
		}
	}
}
