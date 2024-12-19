using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _DefaultLast3ArticleComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _DefaultLast3ArticleComponentPartial(IArticleService articleService)
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
