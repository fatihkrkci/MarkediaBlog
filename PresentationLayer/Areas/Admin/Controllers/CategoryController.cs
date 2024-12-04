using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetActiveCategoriesSortedDescending();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            category.CreatedAt = DateTime.Now;
            category.Status = true;

            _categoryService.TInsert(category);
            return Redirect("/Admin/Category/CategoryList");
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryService.TGetById(id);
            category.DeletedAt = DateTime.Now;
            category.Status = false;
            _categoryService.TUpdate(category);
            return Redirect("/Admin/Category/CategoryList");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _categoryService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            category.UpdatedAt = DateTime.Now;
            _categoryService.TUpdate(category);
            return Redirect("/Admin/Category/CategoryList");
        }
    }
}
