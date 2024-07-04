using MyBookDatabase.DTO;
using MyBookDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace MyBookDatabase.Services {
	public class GenreService {

		private ApplicationDbContext _dbContext;
		public GenreService(ApplicationDbContext dbContext) {
			this._dbContext = dbContext;
		}
		public async Task<ICollection<GenreDTO>> GetAllAsync() {
			var allGenres = await _dbContext.Genres.Include(genre => genre.Books).ThenInclude(book => book.Author).ToListAsync();
			var genreDtos = new List<GenreDTO>();
			foreach (var item in allGenres) {
				genreDtos.Add(ModelToDto(item));
			}
			return genreDtos;
		}
		public async Task CreateAsync(GenreDTO newGenre) {
			await _dbContext.Genres.AddAsync(DtoToModel(newGenre));
			await _dbContext.SaveChangesAsync();
		}
		public async Task<GenreDTO> GetByIdAsync(int id) {
			var genre = await _dbContext.Genres.FirstOrDefaultAsync(genre => genre.Id == id);
			if (genre == null) {
				return null;
			}
			return ModelToDto(genre);
		}
		public async Task UpdateAsync(int id, GenreDTO genreToEdit) {
			_dbContext.Update(DtoToModel(genreToEdit));
			await _dbContext.SaveChangesAsync();
		}
		internal async Task DeleteAsync(int id) {
			var genreToDelete = await _dbContext.Genres.FirstOrDefaultAsync(genre => genre.Id == id);
			_dbContext.Genres.Remove(genreToDelete);
			await _dbContext.SaveChangesAsync();
		}
		private Genre DtoToModel(GenreDTO item) {
			return new Genre() {
				Id = item.Id,
				Name = item.Name,
				Books = item.Books
			};
		}
		private GenreDTO ModelToDto(Genre item) {
			return new GenreDTO() {
				Id = item.Id,
				Name = item.Name,
				Books = item.Books
			};
		}
	}
}
