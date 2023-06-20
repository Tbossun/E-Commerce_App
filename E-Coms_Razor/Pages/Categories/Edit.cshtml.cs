using E_Coms_Razor.Data;
using E_Coms_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Coms_Razor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public Category Category { get; set; }

        public EditModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            if(id != null && id != 0 )
            {
                Category = _context.Categories.Find(id);
            }

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(Category);
                _context.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
           return  Page();
            
        }
    }
}
