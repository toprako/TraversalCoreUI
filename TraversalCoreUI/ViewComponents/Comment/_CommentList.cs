using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.ViewComponents.Comment
{
    public class _CommentList: ViewComponent
    {
        readonly CommentManager commentManager = new(new EfCommentDal());
        public IViewComponentResult Invoke(Guid Id)
        {
            var filterData = commentManager.TGetDestinationById(Id);
            return View(filterData);
        }
    }
}
