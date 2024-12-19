using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using X.PagedList.Extensions;

namespace PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly INewsLetterService _newsletterService;
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public DefaultController(IArticleService articleService, INewsLetterService newsletterService, ICommentService commentService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _newsletterService = newsletterService;
            _commentService = commentService;
            _userManager = userManager;
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

            TempData["SuccessMessage"] = "Bültenimize başarıyla abone oldunuz!";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            comment.AppUserId = user.Id;
            comment.CreatedAt = DateTime.Now;
            comment.Status = true;

            _commentService.TInsert(comment);

            return RedirectToAction("Index", "Default");
        }
    }
}
