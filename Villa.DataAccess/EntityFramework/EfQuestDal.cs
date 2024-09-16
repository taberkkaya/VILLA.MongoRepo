using Villa.DataAccess.Abstract;
using Villa.DataAccess.Context;
using Villa.DataAccess.Repositories;
using Villa.Entity.Entities;

namespace Villa.DataAccess.EntityFramework
{
    public class EfQuestDal : GenericRepository<Quest>, IQuestDal
    {
        public EfQuestDal(VillaContext context) : base(context)
        {
        }
    }
}
