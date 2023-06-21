using E_Coms_DataAccess.Data;
using E_Coms_DataAccess.Repository.IRepository;
using E_Coms_Models.Models;
using E_Coms_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce_Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;   
        }

        public IActionResult Index()
        {
            List<Product> productList = _unitOfWork.Product.GetAll(includeProps : "Category").ToList();
            
            return View(productList);
        }

        public IActionResult UpSert(int? id)
        {
            /*IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().
                Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });*/
            // ViewBag.CategoryList = CategoryList;
            ProductVM productVM = new ProductVM
            {
                CategoryList = _unitOfWork.Category.GetAll().
                Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
               // CategoryList = CategoryList,
                Product = new Product()
            };
            if (id == null || id == 0)
            {
                 return View(productVM);
            }
            else
            {
                 productVM.Product = _unitOfWork.Product.Get(u => u.ProductId == id);
                return View(productVM); 
            }
        }

        /*[HttpPost]
        public IActionResult Create(ProductVM product)
        {
            *//*if (product.product == product.product.ProductName.ToString())
            {
                ModelState.AddModelError("name", "Order cannot be the same with the Name");
            }*//*
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(product.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            *//*else
            {
                product.CategoryList = _unitOfWork.Category.GetAll().Select(u => new
                SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });
                return View(product);
            }*//*
             return View();
        }*/

        [HttpPost]
        public IActionResult UpSert(ProductVM productVM,IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName   = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\products");

                    if(!string.IsNullOrEmpty(productVM.Product.ProductImage))
                    {
                           var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ProductImage.TrimStart('\\'));
                        
                        if(System.IO.File.Exists(oldImagePath))
                        {
                             System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var filestream = new FileStream(Path.Combine(productPath, fileName),FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    productVM.Product.ProductImage = @"\images\products\" + fileName;
                }
                
                if(productVM.Product.ProductId == 0)
                {
                    _unitOfWork.Product.Add(productVM.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(productVM.Product);
                }
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
         
            productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(productVM);
        }


        /*public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var product = _unitOfWork.Product.Get(c => c.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }*/

        /*[HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                TempData["success"] = "product updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
*/
        


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var product = _unitOfWork.Product.Get(c => c.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteProduct(int? id)
        {
            Product product = _unitOfWork.Product.Get(c => c.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }



        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> productList = _unitOfWork.Product.GetAll(includeProps: "Category").ToList();

            return Json(new { data = productList });
        }
        #endregion
    }

}
