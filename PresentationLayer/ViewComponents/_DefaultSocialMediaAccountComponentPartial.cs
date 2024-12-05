using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _DefaultSocialMediaAccountComponentPartial : ViewComponent
    {
        private readonly ISocialMediaAccountService _socialMediaAccountService;

        public _DefaultSocialMediaAccountComponentPartial(ISocialMediaAccountService socialMediaAccountService)
        {
            _socialMediaAccountService = socialMediaAccountService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _socialMediaAccountService.TGetActiveSocialMediaAccounts();
            return View(values);
        }
    }
}
