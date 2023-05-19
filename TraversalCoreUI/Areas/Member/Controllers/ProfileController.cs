using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreUI.Areas.Member.Models.Profile;

namespace TraversalCoreUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Name = user.Name;
            userEditViewModel.Surname = user.Surname;
            userEditViewModel.PhoneNumber = user.PhoneNumber;
            userEditViewModel.Mail = user.Email;
            return View(userEditViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            var user = await userManager.FindByNameAsync(User.Identity?.Name);
            if (model.Image is not null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var imageName = Guid.NewGuid().ToString() + extension;
                var saveLocation = resource + "/wwwroot/UserImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await model.Image.CopyToAsync(stream);
                model.ImageUrl = imageName;
            }
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Mail;
            user.ImageUrl = model.ImageUrl;
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, model.Password);
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }          
            return View(model);
        }
    }
}
