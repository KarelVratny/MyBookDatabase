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
			var allAuthors = await _dbContext.Authors.ToListAsync();
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
