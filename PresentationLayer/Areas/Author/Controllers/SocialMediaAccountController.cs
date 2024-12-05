using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")]
    public class SocialMediaAccountController : Controller
    {
        private readonly ISocialMediaAccountService _socialMediaAccountService;

        public SocialMediaAccountController(ISocialMediaAccountService socialMediaAccountService)
        {
            _socialMediaAccountService = socialMediaAccountService;
        }

        public IActionResult MySocialMediaAccounts()
        {
            return View();
        }
    }
}
