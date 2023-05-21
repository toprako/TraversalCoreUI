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
    public class ReservationManager : IReservationService
    {
        readonly IReservationDal reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            this.reservationDal = reservationDal;
        }

        public List<Reservation> GetListWithReservationByAccepted(Guid Id)
        {
            return reservationDal.GetListWithReservationByAccepted(Id);
        }

        public List<Reservation> GetListWithReservationByPrevious(Guid Id)
        {
            return reservationDal.GetListWithReservationByPrevious(Id);
        }

        public List<Reservation> GetListWithReservationByWaitAprroval(Guid Id)
        {
            return reservationDal.GetListWithReservationByWaitAprroval(Id);
        }

        public void TAdd(Reservation T)
        {
            reservationDal.Insert(T);
        }

        public void TDelete(Reservation T)
        {
            throw new NotImplementedException();
        }

        public Reservation? TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Reservation T)
        {
            throw new NotImplementedException();
        }
    }
}
