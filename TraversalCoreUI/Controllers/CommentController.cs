using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.Controllers
{
    public class CommentController : Controller
    {
        readonly CommentManager commentManager = new(new EfCommentDal());
        private readonly UserManager<AppUser> _userManager;

        public CommentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddCommentAsync(Comment comment)
        {
            comment.Date = DateTime.Now;
            comment.State = true;
            comment.CommentId = new();
            comment.Content = comment.Content ?? "";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            comment.NameSurname = user.Name + " " +user.Surname;
            commentManager.TAdd(comment);
            return RedirectToAction("Index");
        }
    }
}
