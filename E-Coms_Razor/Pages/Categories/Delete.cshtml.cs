using E_Coms_Razor.Data;
using E_Coms_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Coms_Razor.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public Category Category { get; set; }

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _context.Categories.Find(id);
            }

        }

        public IActionResult OnPost()
        {
            Category cat = _context.Categories.Find(Category.Id);
            if (cat == null)
            {
                return NotFound();                            
            }
            _context.Categories.Remove(cat);
            _context.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");

        }
    }
}
