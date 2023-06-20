using E_Coms_Razor.Data;
using E_Coms_Razor.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Coms_Razor.Pages.Categories
{
    public class CategoriesModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<Category> CategoryList { get; set; }

        public CategoriesModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            CategoryList = _context.Categories.ToList();
        }
    }
}
