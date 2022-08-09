using SiteManagement.DAL.Abstract;
using SiteManagement.DAL.DbContexts;
using SiteManagement.DAL.EfBase;
using SiteManagement.Model.Entities;

namespace SiteManagement.DAL.Concrete.Ef
{
    public class EfBlockRepository : EfBaseRepository<BlockEntity, SiteManagementDbContext>,
        IBlockRepository
    {
        public EfBlockRepository(SiteManagementDbContext context) : base(context)
        {

        }
    }
}
