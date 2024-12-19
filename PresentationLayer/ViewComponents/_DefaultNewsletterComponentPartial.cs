using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

public class _DefaultNewsletterComponentPartial : ViewComponent
{
    private readonly INewsLetterService _newsletterService;

    public _DefaultNewsletterComponentPartial(INewsLetterService newsletterService)
    {
        _newsletterService = newsletterService;
    }

    public IViewComponentResult Invoke()
    {
        var newsletter = new NewsLetter();
        return View(newsletter);
    }
}
