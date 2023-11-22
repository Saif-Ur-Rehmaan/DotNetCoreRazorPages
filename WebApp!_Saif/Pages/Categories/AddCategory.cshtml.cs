using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp__Saif.Data;
using WebApp__Saif.Model;

namespace WebApp__Saif.Pages.Categories
{
    public class AddCategoryModel : PageModel
    {
        public string CustomMessage;
        private ApplicationDbContext _db;
        [BindProperty]
        public Category category { get; set; }
        private IEnumerable<Category> AllCategoriesFromDb;
        public AddCategoryModel(ApplicationDbContext db)
        {
            _db=db;
            AllCategoriesFromDb = _db.Category;
            
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() {
 
            if (ModelState.IsValid)
            {
                try
                {
                    if (!category.Name.Equals(category.DisplayOrder.ToString()))
                    {
                        foreach (var item in AllCategoriesFromDb)
                        {
                            if (item.Name.Equals(category.Name)&& item.DisplayOrder.Equals(category.DisplayOrder))
                            {
                                 CustomMessage = $"Data Already Exist In Db ";
                                return Page();
                            }
                        }

                            await _db.AddAsync(category);
                            await _db.SaveChangesAsync();
                            return RedirectToPage("index");

                        
                         

                    }
                    else
                    {
                        CustomMessage = "Category Name And Display Order Cannot Be Exactly Same"+$"  {category.Name}   {category.DisplayOrder}";

                    }

                }
                catch (Exception ex)
                {

                    CustomMessage = ex.Message;

                }



            }
            return Page();
        }

    }
}
