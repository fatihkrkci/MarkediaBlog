using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _DefaultFooterPopularArticlesList : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _DefaultFooterPopularArticlesList(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var articles = _articleService.TGetPopularArticles();
            return View(articles);
        }
    }
}
