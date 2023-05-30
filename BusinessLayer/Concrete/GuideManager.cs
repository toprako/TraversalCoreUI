using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GuideManager : IGuideService
    {
        IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public void TAdd(Guide T)
        {
            _guideDal.Insert(T);
        }

        public void TChangeToFalseByGuide(int Id)
        {
            _guideDal.TChangeToFalseByGuide(Id);
        }

        public void TChangeToTrueByGuide(int Id)
        {
            _guideDal.TChangeToTrueByGuide(Id);
        }

        public void TDelete(Guide T)
        {
            _guideDal.Delete(T);
        }

        public Guide? TGetByID(int id)
        {
           return _guideDal.GetById(id);
        }

        public List<Guide> TGetList()
        {
            return _guideDal.GetList();
        }

        public void TUpdate(Guide T)
        {
            _guideDal.Update(T);
        }
    }
}
