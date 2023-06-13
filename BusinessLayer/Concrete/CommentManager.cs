using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TAdd(Comment T)
        {
            _commentDal.Insert(T);
        }

        public void TDelete(Comment T)
        {
            _commentDal.Delete(T);
        }

        public Comment? TGetByID(int id)
        {
            return _commentDal.GetById(id);
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetList();
        }
        public List<Comment> TGetDestinationById(int Id)
        {
            return _commentDal.GetListByFilter(x => x.DestinationID == Id);
        }
        public void TUpdate(Comment T)
        {
            _commentDal.Update(T);
        }

        public List<Comment> TGetListCommentWithDestination()
        {
            return _commentDal.GetListCommentWithDestination();
        }

        public List<Comment> TGetListCommentWithDestinationAndUser(int Id)
        {
            return _commentDal.GetListCommentWithDestinationAndUser(Id);
        }
    }
}
