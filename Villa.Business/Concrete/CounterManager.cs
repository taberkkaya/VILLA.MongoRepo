using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.DataAccess.Abstract;
using Villa.Entity.Entities;

namespace Villa.Business.Concrete
{
    public class CounterManager : GenericManager<Counter>
    {
        public CounterManager(IGenericDal<Counter> genericDal) : base(genericDal)
        {
        }
    }
}
