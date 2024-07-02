using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBookDatabase.DTO;
using MyBookDatabase.Services;

namespace MyBookDatabase.Controllers {
	public class AuthorsController : Controller {
		private AuthorService _service;
		public AuthorsController(AuthorService service) {
			this._service = service;
		}
		public async Task<IActionResult> Index() {
			var allAuthors = await _service.GetAllAsync();
			return View(allAuthors);
		}
		public IActionResult Create() {
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(AuthorDTO newAuthor) {
			await _service.CreateAsync(newAuthor);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> UpdateAsync(int id) {
			var authorToEdit = await _service.GetByIdAsync(id);
			if (authorToEdit == null) {
				return View("NotFound");
			}
			return View(authorToEdit);
		}
		[HttpPost]
		public async Task<IActionResult> Update(int id, AuthorDTO authorToEdit) {
			await _service.UpdateAsync(id, authorToEdit);
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
