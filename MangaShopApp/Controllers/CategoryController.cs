using Manga.DataAccess.Data;
using Manga.Models;
using Microsoft.AspNetCore.Mvc;

namespace MangaWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString()) 
            { 
                ModelState.AddModelError("name", "You cannot name the display Order the same name as the category."); 
            }

            if (ModelState.IsValid && category != null)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["Success"] = "Category created successfully";

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            Category? category = _db.Categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "You cannot name the display Order the same name as the category.");
            }

            if (ModelState.IsValid && category != null) 
            { 
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["Success"] = "Category updated successfully";

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Delete(int id)
        {
            Category? category = _db.Categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category) 
        {
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
                TempData["Success"] = "Category deleted successfully";

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }
    }
}