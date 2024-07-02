using Microsoft.AspNetCore.Mvc;
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
	}
}
