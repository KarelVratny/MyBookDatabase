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
				authorDtos.Add(modelToDto(item));
			}
			return authorDtos;
		}

		private AuthorDTO modelToDto(Author item) {
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
