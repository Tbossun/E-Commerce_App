using E_Coms_DataAccess.Data;
using E_Coms_DataAccess.Repository.IRepository;
using E_Coms_Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            List<Category> categorList = _categoryRepo.GetAll().ToList();
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
                _categoryRepo.Add(cat);
                _categoryRepo.Save();
                TempData["success"] = "Category created successfully";
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
            var category = _categoryRepo.Get(c => c.Id == id);
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
                 _categoryRepo.Update(cat);
                _categoryRepo.Save();
                TempData["success"] = "Category updated successfully";
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
            var category = _categoryRepo.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCategory(int? id)
        {
            Category cat = _categoryRepo.Get(c => c.Id == id);
            if (cat == null)
            {
                return NotFound();
            }
                _categoryRepo.Remove(cat);
                _categoryRepo.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}                                                            
