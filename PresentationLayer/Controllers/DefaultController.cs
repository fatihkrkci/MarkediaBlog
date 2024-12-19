using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly INewsLetterService _newsletterService;

        public DefaultController(IArticleService articleService, INewsLetterService newsletterService)
        {
            _articleService = articleService;
            _newsletterService = newsletterService;
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

        [HttpPost]
        public IActionResult Subscribe(NewsLetter newsLetter)
        {
            _newsletterService.TInsert(newsLetter);

            // Success mesajı ekliyoruz
            TempData["SuccessMessage"] = "Bültenimize başarıyla abone oldunuz!";

            return RedirectToAction("Index");
        }

    }
}
