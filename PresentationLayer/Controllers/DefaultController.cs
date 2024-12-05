using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IArticleService _articleService;

        public DefaultController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            var articles = _articleService.TArticleListWithCategoryAndAppUser();
            return View(articles);
        }

        public IActionResult ArticleDetail(int id)
        {
            var value = _articleService.TGetArticleDetails(id);
            return View(value);
        }
    }
}
