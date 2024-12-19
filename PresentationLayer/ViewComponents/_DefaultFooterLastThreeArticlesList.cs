using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _DefaultFooterLastThreeArticlesList : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _DefaultFooterLastThreeArticlesList(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetLastThreeArticles();
            return View(values);
        }
    }
}
