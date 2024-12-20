using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(IArticleService articleService, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        [Area("Admin")]
        public IActionResult Index()
        {
            var totalCategoryCount = _categoryService.TGetAll().Count().ToString();
            ViewBag.TotalCategoryCount = totalCategoryCount;

            var awaitingApprovalArticleCount = _articleService.TAwaitingApprovalArticles().Count().ToString();
            ViewBag.AwaitingApprovalArticleCount = awaitingApprovalArticleCount;

            var approvedArticleCount = _articleService.TApprovedArticles().Count().ToString();
            ViewBag.ApprovedArticleCount = approvedArticleCount;

            var mostWrittenCategory = _articleService.TGetArticleCountGroupedByCategory();

            return View();
        }
    }
}
