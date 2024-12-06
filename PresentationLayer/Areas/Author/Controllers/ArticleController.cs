using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules.ArticleValidationRules;
using BusinessLayer.ValidationRules.CategoryValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

        public ArticleController(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }

        public IActionResult MyArticles()
        {
            var values = _articleService.TGetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categoryList = _categoryService.TGetActiveCategoriesSortedDescending();
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            ModelState.Clear();

            article.ArticleStatus = ArticleStatus.AwaitingApproval;
            article.Status = true;
            article.CreatedAt = DateTime.Now;
            article.ViewCount = 0;

            CreateArticleValidator validationRules = new CreateArticleValidator();
            ValidationResult result = validationRules.Validate(article);

            if (result.IsValid)
            {
                _articleService.TInsert(article);
                return Redirect("/Author/Article/MyArticles");
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
            var article = _articleService.TGetById(id);
            article.Status = false;
            article.DeletedAt = DateTime.Now;
            _articleService.TUpdate(article);
            return Redirect("/Author/Article/MyArticles");
        }
    }
}