﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract.AbstractUow
{
    public interface IGenericUowDal<T>
    {
        void Insert(T t);
        void Update(T t);
        void MultiUpdate(List<T> models);
        T GetById(int Id);
    }
}
