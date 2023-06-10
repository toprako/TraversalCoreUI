using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public DateTime Date { get; set; }
    }
}
