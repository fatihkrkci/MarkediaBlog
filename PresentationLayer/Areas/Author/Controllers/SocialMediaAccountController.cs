using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules.ArticleValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PresentationLayer.Areas.Author.Controllers
{
    [Area("Author")]
    public class SocialMediaAccountController : Controller
    {
        private readonly ISocialMediaAccountService _socialMediaAccountService;
        private readonly UserManager<AppUser> _userManager;

        public SocialMediaAccountController(ISocialMediaAccountService socialMediaAccountService, UserManager<AppUser> userManager)
        {
            _socialMediaAccountService = socialMediaAccountService;
            _userManager = userManager;
        }

        public async Task<IActionResult> MySocialMediaAccounts()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = await _socialMediaAccountService.TGetSocialMediaAccountsByAppUserIdAsync(user.Id);
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SocialMediaAccount socialMediaAccount)
        {
            ModelState.Clear();

            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);

            socialMediaAccount.AppUserId = userValue.Id;
            socialMediaAccount.Status = true;
            socialMediaAccount.CreatedAt = DateTime.Now;

            _socialMediaAccountService.TInsert(socialMediaAccount);
            return Redirect("/Author/SocialMediaAccount/MySocialMediaAccounts/");
        }

        public IActionResult Delete(int id)
        {
            var socialMediaAccount = _socialMediaAccountService.TGetById(id);
            socialMediaAccount.Status = false;
            socialMediaAccount.DeletedAt = DateTime.Now;
            _socialMediaAccountService.TUpdate(socialMediaAccount);
            return Redirect("/Author/SocialMediaAccount/MySocialMediaAccounts/");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _socialMediaAccountService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SocialMediaAccount socialMediaAccount)
        {
            ModelState.Clear();

            var userValue = await _userManager.FindByNameAsync(User.Identity.Name);

            var existingSocialMediaAccount = _socialMediaAccountService.TGetById(socialMediaAccount.SocialMediaAccountId);

            socialMediaAccount.AppUserId = userValue.Id;
            socialMediaAccount.Name = existingSocialMediaAccount.Name;
            socialMediaAccount.Url = existingSocialMediaAccount.Url;
            socialMediaAccount.Icon = existingSocialMediaAccount.Icon;
            socialMediaAccount.CreatedAt = existingSocialMediaAccount.CreatedAt;
            socialMediaAccount.Status = existingSocialMediaAccount.Status;
            socialMediaAccount.UpdatedAt = DateTime.Now;

            _socialMediaAccountService.TUpdate(socialMediaAccount);

            return Redirect("/Author/SocialMediaAccount/MySocialMediaAccounts/");
        }
    }
}
