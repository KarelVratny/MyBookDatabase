using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBookDatabase.DTO;
using MyBookDatabase.Services;

namespace MyBookDatabase.Controllers {
	public class BooksController : Controller {

		private BookService _service;
		public BooksController(BookService service) {
			this._service = service;
		}
		public async Task<IActionResult> Index() {
			var allBooks = await _service.GetAllViewModelsAsync();
			return View(allBooks);
		}
		public async Task<IActionResult> CreateAsync() {
			await FillSelectsAsync();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(BookDTO bookDTO) {
			await _service.CreateAsync(bookDTO);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Update(int id) {
			var bookToEdit = await _service.GetByIdAsync(id);
			if (bookToEdit == null) {
				return View("NotFound");
			}
			var bookDTO = await _service.ModelToDto(bookToEdit);
			await FillSelectsAsync();
			return View(bookDTO);
		}
		[HttpPost]
		public async Task<IActionResult> Update(int id, BookDTO book) {
			await _service.UpdateAsync(id, book);
			return RedirectToAction("Index");
		}
		private async Task FillSelectsAsync() {
			var booksDropdownsData = await _service.GetNewBooksDropdownsValues();
			ViewBag.Authors = new SelectList(booksDropdownsData.Authors, "Id", "Name");
			ViewBag.Genres = new SelectList(booksDropdownsData.Genres, "Id", "Name");
		}
	}
}
