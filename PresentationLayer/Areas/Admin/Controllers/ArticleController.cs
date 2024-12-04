using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult AwaitingApproval()
        {
            var values = _articleService.TAwaitingApprovalArticles();
            return View(values);
        }

        public IActionResult Approved()
        {
            var values = _articleService.TApprovedArticles();
            return View(values);
        }

        public IActionResult Disapproved()
        {
            var values = _articleService.TDisapprovedArticles();
            return View(values);
        }

        public IActionResult Approve(int id)
        {
            var article = _articleService.TGetById(id);
            article.ArticleStatus = ArticleStatus.Approved;
            _articleService.TUpdate(article);
            return Redirect("/Admin/Article/Approved");
        }

        public IActionResult Disapprove(int id)
        {
            var article = _articleService.TGetById(id);
            article.ArticleStatus = ArticleStatus.Disapproved;
            _articleService.TUpdate(article);
            return Redirect("/Admin/Article/Disapproved");
        }
    }
}
