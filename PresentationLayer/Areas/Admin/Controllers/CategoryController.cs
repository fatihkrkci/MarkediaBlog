using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules.CategoryValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
            ModelState.Clear();

            category.CreatedAt = DateTime.Now;
            category.Status = true;

            CreateCategoryValidator validationRules = new CreateCategoryValidator();
            ValidationResult result = validationRules.Validate(category);

            if (result.IsValid)
            {
                _categoryService.TInsert(category);
                return Redirect("/Admin/Category/CategoryList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
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
            ModelState.Clear();

            category.UpdatedAt = DateTime.Now;

            UpdateCategoryValidator validationRules = new UpdateCategoryValidator();
            ValidationResult result = validationRules.Validate(category);

            if (result.IsValid)
            {
                _categoryService.TUpdate(category);
                return Redirect("/Admin/Category/CategoryList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}
