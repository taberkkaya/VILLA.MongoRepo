using Villa.DataAccess.Abstract;
using Villa.DataAccess.Context;
using Villa.DataAccess.Repositories;
using Villa.Entity.Entities;

namespace Villa.DataAccess.EntityFramework
{
    public class EfDealDal : GenericRepository<Deal>, IDealDal
    {
        public EfDealDal(VillaContext context) : base(context)
        {
        }
    }
}
