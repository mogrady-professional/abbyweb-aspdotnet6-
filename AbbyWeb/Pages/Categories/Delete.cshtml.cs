using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id); // find the category with the id (pk)
            //Category = _db.Category.FirstOrDefault(u => u.Id == id);
            //Category = _db.Category.SingleOrDefault(u => u.Id == id);
            //Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();

        }

        public async Task<IActionResult> OnPost()
        {
                var categoryFromDb = _db.Category.Find(Category.Id);
                if (categoryFromDb != null)
                {
                    _db.Category.Remove(categoryFromDb);  
                    await _db.SaveChangesAsync();
                    TempData["Success"] = "Category deleted successfully!";
                    return RedirectToPage("Index");
                }
                return Page();
        }
    }
}
