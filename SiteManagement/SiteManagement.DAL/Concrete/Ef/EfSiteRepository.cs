using SiteManagement.DAL.Abstract;
using SiteManagement.DAL.DbContexts;
using SiteManagement.DAL.EfBase;
using SiteManagement.Model.Entities;

namespace SiteManagement.DAL.Concrete.Ef
{
    public class EfSiteRepository : EfBaseRepository<SiteEntity, SiteManagementDbContext>, ISiteRepository
    {
        public EfSiteRepository(SiteManagementDbContext context) : base (context)
        {

        }
    }
}
