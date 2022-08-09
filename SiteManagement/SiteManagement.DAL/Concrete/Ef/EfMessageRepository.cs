using SiteManagement.DAL.Abstract;
using SiteManagement.DAL.DbContexts;
using SiteManagement.DAL.EfBase;
using SiteManagement.Model.Entities;

namespace SiteManagement.DAL.Concrete.Ef
{
    public class EfMessageRepository : EfBaseRepository<MessageEntity, SiteManagementDbContext>, IMessageRepository
    {
        public EfMessageRepository(SiteManagementDbContext context) : base(context)
        {

        }
    }
}
