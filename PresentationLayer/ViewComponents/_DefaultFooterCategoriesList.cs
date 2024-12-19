using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _DefaultFooterCategoriesList : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _DefaultFooterCategoriesList(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetArticleCountGroupedByCategory();
            return View(values);
        }
    }
}
