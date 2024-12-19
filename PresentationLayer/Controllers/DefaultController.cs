using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IArticleService _articleService;

        public DefaultController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index(int page = 1)
        {
            const int pageSize = 3;

            var articles = _articleService.TArticleListWithCategoryAndAppUser();

            var pagedArticles = articles.ToPagedList(page, pageSize);

            return View(pagedArticles);
        }

        public IActionResult ArticleDetail(int id)
        {
            _articleService.TArticleViewCountIncrease(id);

            var value = _articleService.TGetArticleDetails(id);
            return View(value);
        }
    }
}
