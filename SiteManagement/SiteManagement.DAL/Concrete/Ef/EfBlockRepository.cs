using Microsoft.EntityFrameworkCore;
using SiteManagement.DAL.Abstract;
using SiteManagement.DAL.DbContexts;
using SiteManagement.DAL.EfBase;
using SiteManagement.Model.Entities;
using System.Linq;

namespace SiteManagement.DAL.Concrete.Ef
{
    public class EfBlockRepository : EfBaseRepository<BlockEntity, SiteManagementDbContext>,
        IBlockRepository
    {
        public EfBlockRepository(SiteManagementDbContext context) : base(context)
        {

        }

        public BlockEntity GetBlockWithSite(int id)
        {
            return _context.Blocks.Include(x => x.Site).SingleOrDefault(x => x.Id == id);
        }
    }
}
