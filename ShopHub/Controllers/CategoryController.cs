using Microsoft.AspNetCore.Mvc;
using Shop.DAL.DB;
using Shop.DAL.Models;

namespace ShopHub.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ShopDbContext _db;

        public CategoryController(ShopDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var categories = _db.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["Create"] = "Item has Created Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null | id == 0)
            {
                NotFound();
            }
            var categoryIndb = _db.Categories.Find(id);

            return View(categoryIndb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);

                _db.SaveChanges();
                TempData["Update"] = "Data has Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null | id == 0)
            {
                NotFound();
            }
            var categoryIndb = _db.Categories.Where(x => x.Id == id).FirstOrDefault();

            return View(categoryIndb);
        }

        [HttpPost]
        public IActionResult DeleteCategory(int? id)
        {
            var categoryIndb = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (categoryIndb == null)
            {
                NotFound();
            }
            _db.Categories.Remove(categoryIndb);
            _db.SaveChanges();
            TempData["Delete"] = "Item has Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
