using BulkyBook.Data.IRepositories;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IUnitOfWork db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult List()
        {
            var products = _db.Products.List();
            return View(products);
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Products.Create(product);
        //        _db.Save();
        //        return RedirectToAction("List");
        //    }

        //    return View(product);
        //}

        [HttpGet]
        public IActionResult Read(int? id)
        {
            if (id is null)
                return NotFound();

            var product = _db.Products.GetFirstOrDefault(p => p.Id == id);

            if (product is null)
                return NotFound();

            return View(product);
        }

        //[HttpGet]
        //public IActionResult Update(int? id)
        //{
        //    if (id is null)
        //        return NotFound();

        //    var product = _db.Products.GetFirstOrDefault(p => p.Id == id);

        //    if (product is null)
        //        return NotFound();

        //    return View(product);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Update(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Products.Update(product);
        //        _db.Save();
        //        return RedirectToAction("List");
        //    }

        //    return View(product);
        //}

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            var productVM = new ProductVM()
            {
                Product = new(),
                Categories = _db.Categories.List().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                CoverTypes = _db.CoverTypes.List().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };

            if (id is null)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _db.Products.GetFirstOrDefault(p => p.Id == id);
                return View(productVM);
            }

            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    var fileName = Guid.NewGuid().ToString();
                    var extension = Path.GetExtension(file.FileName);
                    var uploads = Path.Combine(wwwRootPath, @"images/products");

                    if (productVM.Product.ImgUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImgUrl);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }

                    productVM.Product.ImgUrl = $@"/images/products/{fileName + extension}";
                }

                if (productVM.Product.Id == 0)
                {
                    _db.Products.Create(productVM.Product);

                }
                else
                {
                    _db.Products.Update(productVM.Product);

                }
                _db.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("List");
            }

            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var product = _db.Products.GetFirstOrDefault(p => p.Id == id);

            if (product is null)
                return NotFound();

            _db.Products.Delete(product);
            _db.Save();
            return RedirectToAction("List");
        }
    }
}
