using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")]
    public class DashboardController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(IArticleService articleService, ICommentService commentService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var myArticlesCount = _articleService.TGetArticlesByAppUserId(user.Id).Count().ToString();
            ViewBag.ArticlesCount = myArticlesCount;

            var myCommentCount = _commentService.TGetCommentsByAppUserId(user.Id).Count().ToString();
            ViewBag.CommentCount = myCommentCount;

            var categoryOfMyLastArticle = _articleService.TGetLastArticleByAppUserIdWithCategory(user.Id);
            ViewBag.CategoryOfArticle = categoryOfMyLastArticle.Category.Name;

            var nameOfMyLastArticle = _articleService.TGetLastArticleByAppUserIdWithCategory(user.Id);
            ViewBag.NameOfMyLastArticle = nameOfMyLastArticle.Title;

            return View();
        }
    }
}
