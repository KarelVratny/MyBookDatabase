using Microsoft.AspNetCore.Mvc;
using MyBookDatabase.DTO;
using MyBookDatabase.Services;

namespace MyBookDatabase.Controllers {
	public class GenresController : Controller {

		private GenreService _service;
		public GenresController(GenreService service) {
			this._service = service;
		}
		public async Task<IActionResult> Index() {
			var allGenres = await _service.GetAllAsync();
			return View(allGenres);
		}
		public IActionResult Create() {
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(GenreDTO newGenre) {
			await _service.CreateAsync(newGenre);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> UpdateAsync(int id) {
			var genreToEdit = await _service.GetByIdAsync(id);
			if (genreToEdit == null) {
				return View("NotFound");
			}
			return View(genreToEdit);
		}
		[HttpPost]
		public async Task<IActionResult> Update(int id, GenreDTO genreToEdit) {
			await _service.UpdateAsync(id, genreToEdit);
			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<IActionResult> Delete(int id) {
			var authorToDelete = await _service.GetByIdAsync(id);
			if (authorToDelete == null) {
				return View("NotFound");
			}
			await _service.DeleteAsync(id);
			return RedirectToAction("Index");
		}
	}
}
