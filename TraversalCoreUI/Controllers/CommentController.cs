using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.Controllers
{
    public class CommentController : Controller
    {
        readonly CommentManager commentManager = new(new EfCommentDal());

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.Date = DateTime.Now;
            comment.State = true;
            comment.CommentId = new();
            commentManager.TAdd(comment);
            return RedirectToAction("Index","Destination");
        }
    }
}
