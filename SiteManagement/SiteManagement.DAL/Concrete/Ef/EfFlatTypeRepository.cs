using SiteManagement.DAL.Abstract;
using SiteManagement.DAL.DbContexts;
using SiteManagement.DAL.EfBase;
using SiteManagement.Model.Entities;

namespace SiteManagement.DAL.Concrete.Ef
{
    public class EfFlatTypeRepository : EfBaseRepository<FlatTypeEntity, SiteManagementDbContext>, IFlatTypeRepository
    {

        public EfFlatTypeRepository(SiteManagementDbContext context) : base(context)
        {

        }
    }
}
