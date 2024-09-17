using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.DataAccess.Abstract;
using Villa.Entity.Entities;

namespace Villa.Business.Concrete
{
    public class DealManager : GenericManager<Deal>
    {
        public DealManager(IGenericDal<Deal> genericDal) : base(genericDal)
        {
        }
    }
}
