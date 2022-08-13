using SiteManagement.DAL.EfBase;
using SiteManagement.Model.Entities;

namespace SiteManagement.DAL.Abstract
{
    public interface IUserRepository : IEfBaseRepository<UserEntity>
    {
        UserEntity GetUserWithPassword(string email);

        UserEntity GetUserWithBlock(string email);
    }
}
