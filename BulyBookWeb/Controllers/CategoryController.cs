using BulyBookWeb.Data;
using BulyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BulyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        // GET:
        public IActionResult Create()
        { 
            return View();
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category added successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET:
        public IActionResult Edit(int? id)
        {
            if(id == 0 || id == null)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDb = _db.Categories.SingleOrDefault(u=>u.Id == id);
            return View(categoryFromDb);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category edited successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        // GET:
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDb = _db.Categories.SingleOrDefault(u=>u.Id == id);
            return View(categoryFromDb);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
