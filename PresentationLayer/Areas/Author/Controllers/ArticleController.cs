using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules.ArticleValidationRules;
using BusinessLayer.ValidationRules.CategoryValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICategoryService _categoryService;

        public ArticleController(IArticleService articleService, UserManager<AppUser> userManager, ICategoryService categoryService)
        {
            _articleService = articleService;
            _userManager = userManager;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> MyArticles()
        {
            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesByAppUserId(userValue.Id);
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
        public async Task<IActionResult> Create(Article article)
        {
            ModelState.Clear();

            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);

            article.AppUserId = userValue.Id;
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

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _articleService.TGetById(id);

            var categoryList = _categoryService.TGetActiveCategoriesSortedDescending();
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Article article)
        {
            ModelState.Clear();

            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);

            var existingArticle = _articleService.TGetById(article.ArticleId);

            article.AppUserId = userValue.Id;
            article.Title = existingArticle.Title;
            article.Content = existingArticle.Content;
            article.ImageUrl = existingArticle.ImageUrl;
            article.ArticleStatus = existingArticle.ArticleStatus;
            article.CategoryId = existingArticle.CategoryId;
            article.CreatedAt = existingArticle.CreatedAt;
            article.ViewCount = existingArticle.ViewCount;
            article.Status = existingArticle.Status;
            article.UpdatedAt = DateTime.Now;

            _articleService.TUpdate(article);

            return Redirect("/Author/Article/MyArticles");
        }

    }
}