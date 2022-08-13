using Microsoft.EntityFrameworkCore;
using SiteManagement.DAL.Abstract;
using SiteManagement.DAL.DbContexts;
using SiteManagement.DAL.EfBase;
using SiteManagement.Model.Entities;
using System.Linq;

namespace SiteManagement.DAL.Concrete.Ef
{
    public class EfUserRepository : EfBaseRepository<UserEntity, SiteManagementDbContext>, IUserRepository
    {
        public EfUserRepository(SiteManagementDbContext context) : base(context)
        {

        }

        public UserEntity GetUserWithPassword(string email)
        {
            return _context.Users
                .Include(x => x.UserPassword)
                .FirstOrDefault(x => x.Email == email);
        }

        public UserEntity GetUserWithBlock(string email)
        {
            return _context.Users
                .Include(x => x.Flat)
                .ThenInclude(y=> y.Block)
                .FirstOrDefault(x => x.Email == email);
        }
    }
}
