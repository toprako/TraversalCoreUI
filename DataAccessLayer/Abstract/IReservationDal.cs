using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        List<Reservation> GetListWithReservationByWaitAprroval(Guid Id);
        List<Reservation> GetListWithReservationByAccepted(Guid Id);
        List<Reservation> GetListWithReservationByPrevious(Guid Id);

    }
}
