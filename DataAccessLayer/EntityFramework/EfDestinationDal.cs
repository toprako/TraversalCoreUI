﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public Destination GetDestinationWithGuide(int Id)
        {
            using (var context = new Context())
            {
                return context.Destinations.Where(x => x.DestinationID == Id).Include(x => x.Guide).FirstOrDefault();
            }
        }

        public List<Destination> GetLastFourDestinations()
        {
            using (var context = new Context())
            {
                var destinations = context.Destinations.Take(4).OrderByDescending(x => x.DestinationID).ToList();
                return destinations;
            }
        }
    }
}
