using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> 
    {
        void TAdd(T T);
        void TDelete(T T);
        void TUpdate(T T);
        List<T> TGetList();
        T? TGetByID(int id);
        //List<T> GetByFilter(Expression<Func<T, bool>> filter);
    }
}
