using Villa.DataAccess.Abstract;
using Villa.DataAccess.Context;
using Villa.DataAccess.Repositories;
using Villa.Entity.Entities;

namespace Villa.DataAccess.EntityFramework
{
    public class EfVideoDal : GenericRepository<Video>, IVideoDal
    {
        public EfVideoDal(VillaContext context) : base(context)
        {
        }
    }
}
