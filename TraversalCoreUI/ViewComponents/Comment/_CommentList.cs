using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.ViewComponents.Comment
{
    public class _CommentList: ViewComponent
    {
        readonly CommentManager commentManager = new(new EfCommentDal());
        public IViewComponentResult Invoke(int Id)
        {
            var filterData = commentManager.TGetListCommentWithDestinationAndUser(Id);

            return View(filterData);
        }
    }
}
