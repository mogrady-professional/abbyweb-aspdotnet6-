using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.name", "Display Order cannot be the same as the Name");
            }
            if (ModelState.IsValid)
            {
            await _db.Category.AddAsync(Category);
            await _db.SaveChangesAsync();
                TempData["Success"] = "Category created successfully";
                return RedirectToPage("Index");                
            }
            return Page();
        }
    }
}
