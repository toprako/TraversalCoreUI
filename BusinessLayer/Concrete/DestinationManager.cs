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
    public class DestinationManager : IDestinationService
    {
        readonly IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public Destination TGetDestinationWithGuide(int Id)
        {
            return _destinationDal.GetDestinationWithGuide(Id);
        }

        public void TAdd(Destination T)
        {
            _destinationDal.Insert(T);
        }

        public void TDelete(Destination T)
        {
            _destinationDal.Delete(T);
        }

        public Destination? TGetByID(int id)
        {
            return _destinationDal.GetById(id);
        }

        public List<Destination> TGetList()
        {
            return _destinationDal.GetList();
        }

        public void TUpdate(Destination T)
        {
            _destinationDal.Update(T);
        }

        public List<Destination> TGetLastFourDestinations()
        {
            return _destinationDal.GetLastFourDestinations();
        }
    }
}
