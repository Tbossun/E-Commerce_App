using E_Coms_Razor.Data;
using E_Coms_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Coms_Razor.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;
    
        public Category Category { get; set; }

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
               _context.Categories.Add(Category);
            _context.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToPage("Index");
        }
    }
}
