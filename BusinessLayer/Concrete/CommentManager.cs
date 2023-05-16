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
            throw new NotImplementedException();
        }

        public Comment? TGetByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> TGetList()
        {
            throw new NotImplementedException();
        }
        public List<Comment> TGetDestinationById(Guid Id)
        {
            return _commentDal.GetListByFilter(x => x.DestinationID == Id);
        }
        public void TUpdate(Comment T)
        {
            throw new NotImplementedException();
        }
    }
}
