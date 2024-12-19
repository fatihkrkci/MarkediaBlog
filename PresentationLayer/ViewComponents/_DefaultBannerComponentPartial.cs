using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _DefaultBannerComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _DefaultBannerComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetLastArticle();
            return View(values);
        }
    }
}
