using Microsoft.AspNetCore.Mvc;
using Shop.DAL.DB;
using Shop.DAL.Models;
using Shop.DAL.Repository.Abstraction;

namespace ShopHub.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ShopDbContext _db;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(ShopDbContext db, IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var categories = _unitOfWork.CategoryRepo.GetAll();
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
                _unitOfWork.CategoryRepo.Add(category);
                _unitOfWork.Save();

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
            //var categoryIndb = _db.Categories.Find(id);
            var categoryIndb = _unitOfWork.CategoryRepo.Get(c => c.Id == id);

            return View(categoryIndb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepo.Edite(category);

                _unitOfWork.Save();

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
            _unitOfWork.CategoryRepo.Remove(categoryIndb);
            _unitOfWork.Save();

            TempData["Delete"] = "Item has Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
