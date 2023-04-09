using BulkyBook.Data.IRepositories;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _db;

        public CoverTypeController(IUnitOfWork db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult List()
        {
            var coverTypes = _db.CoverTypes.List();
            return View(coverTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                _db.CoverTypes.Create(coverType);
                _db.Save();
                return RedirectToAction("List");
            }

            ModelState.AddModelError("Name", "Name must be less than 50 characters.");

            return View(coverType);
        }

        [HttpGet]
        public IActionResult Read(int? id)
        {
            if (id is null)
                return NotFound();

            var coverType = _db.CoverTypes.GetFirstOrDefault(c => c.Id == id);

            if (coverType is null)
                return NotFound();

            return View(coverType);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id is null)
                return NotFound();

            var coverType = _db.CoverTypes.GetFirstOrDefault(c => c.Id == id);

            if (coverType is null)
                return NotFound();

            return View(coverType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                _db.CoverTypes.Update(coverType);
                _db.Save();
                return RedirectToAction("List");
            }

            ModelState.AddModelError("Name", "Name must be less than 50 characters.");

            return View(coverType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var coverType = _db.CoverTypes.GetFirstOrDefault(c => c.Id == id);

            if (coverType is null)
                return NotFound();

            _db.CoverTypes.Delete(coverType);
            _db.Save();
            return RedirectToAction("List");
        }
    }
}
