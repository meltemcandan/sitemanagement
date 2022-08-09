using SiteManagement.DAL.Abstract;
using SiteManagement.DAL.DbContexts;
using SiteManagement.DAL.EfBase;
using SiteManagement.Model.Entities;

namespace SiteManagement.DAL.Concrete.Ef
{
    public class EfDebtRepository : EfBaseRepository<DebtEntity, SiteManagementDbContext>, IDebtRepository
    {
        public EfDebtRepository(SiteManagementDbContext context) : base(context)
        {

        }
    }
}
