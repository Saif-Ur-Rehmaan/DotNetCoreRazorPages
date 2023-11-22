using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp__Saif.Data;
using WebApp__Saif.Model;

namespace WebApp__Saif.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Category> CategoriesTable;
		public IndexModel(ApplicationDbContext db) => _db = db;

		public void OnGet()
        {
            CategoriesTable = _db.Category;
		}
	}
}
