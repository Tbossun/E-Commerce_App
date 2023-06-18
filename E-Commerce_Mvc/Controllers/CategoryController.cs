using E_Commerce_Mvc.Data;
using E_Commerce_Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> categorList = _context.Categories.ToList();
            return View(categorList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category cat)
        {   
            if(cat.Name == cat.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Order cannot be the same with the Name"); 
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Add(cat);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
              return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                  return NotFound();
            }
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                  return NotFound();
            }
            return View(category);
        }


        [HttpPost]
        public IActionResult Edit(Category cat)
        {
            if (ModelState.IsValid)
            {
                 _context.Categories.Update(cat);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCategory(int? id)
        {
            Category cat = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (cat == null)
            {
                return NotFound();
            }
                _context.Categories.Remove(cat);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}                                                            
