using SiteManagement.Business.Configuration.Response;
using SiteManagement.DTO.User;

namespace SiteManagement.Business.Abstract
{
    public interface IUserService
    {
        CommandResponse Add(AddUserDto dto);

        CommandResponse Update(UpdateUserDto dto);

        CommandResponse Delete(int id);

        CommandResponse Get(int id);

        CommandResponse GetAll();
    }
}
