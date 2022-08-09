using SiteManagement.DAL.EfBase;
using SiteManagement.Model.Entities;

namespace SiteManagement.DAL.Abstract
{
    public interface IMessageRepository : IEfBaseRepository<MessageEntity>
    {
    }
}
