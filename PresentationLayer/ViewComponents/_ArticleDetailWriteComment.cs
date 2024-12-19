using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _ArticleDetailWriteComment : ViewComponent
    {
        public IViewComponentResult Invoke(int articleId)
        {
            ViewData["ArticleId"] = articleId;
            return View(new Comment());
        }
    }

}
