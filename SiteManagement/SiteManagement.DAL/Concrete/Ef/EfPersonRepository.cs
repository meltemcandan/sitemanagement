using SiteManagement.DAL.Abstract;
using SiteManagement.DAL.DbContexts;
using SiteManagement.DAL.EfBase;
using SiteManagement.Model.Entities;

namespace SiteManagement.DAL.Concrete.Ef
{
    public class EfPersonRepository : EfBaseRepository<PersonEntity, SiteManagementDbContext>, IPersonRepository
    {
        public EfPersonRepository(SiteManagementDbContext context) : base(context)
        {

        }
    }
}
