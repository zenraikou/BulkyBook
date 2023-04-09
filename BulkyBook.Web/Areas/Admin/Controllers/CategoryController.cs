using BulkyBook.Data.IRepositories;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _db;

        public CategoryController(IUnitOfWork db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult List()
        {
            IEnumerable<Category> categories = _db.Categories.List();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
                ModelState.AddModelError("DisplayOrder", "Name and Category should not be the same.");

            if (ModelState.IsValid)
            {
                _db.Categories.Create(category);
                _db.Save();
                return RedirectToAction("List");
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Read(int? id)
        {
            if (id is null)
                return NotFound();


            var category = _db.Categories.GetFirstOrDefault(c => c.Id == id);

            if (category is null)
                return NotFound();

            return View(category);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id is null)
                return NotFound();

            var category = _db.Categories.GetFirstOrDefault(c => c.Id == id);

            if (category is null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
                ModelState.AddModelError("DisplayOrder", "Name and Category should not be the same.");

            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.Save();
                return RedirectToAction("List");
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var category = _db.Categories.GetFirstOrDefault(c => c.Id == id);

            if (category is null)
                return NotFound();

            _db.Categories.Delete(category);
            _db.Save();
            return RedirectToAction("List");
        }
    }
}
