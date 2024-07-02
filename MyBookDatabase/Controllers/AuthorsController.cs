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
	}
}
