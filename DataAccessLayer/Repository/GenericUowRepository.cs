using DataAccessLayer.Abstract.AbstractUow;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericUowRepository<T> : IGenericUowDal<T> where T : class
    {
        private readonly Context _context;

        public GenericUowRepository(Context context)
        {
            _context = context;
        }

        public T GetById(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public void Insert(T t)
        {
            _context.Add(t);
        }

        public void MultiUpdate(List<T> models)
        {
            _context.UpdateRange(models);
        }

        public void Update(T t)
        {
            _context.Update(t);
        }
    }
}
