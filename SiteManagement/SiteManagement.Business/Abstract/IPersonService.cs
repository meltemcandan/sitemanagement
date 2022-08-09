using SiteManagement.Business.Configuration.Response;
using SiteManagement.DTO.Person;

namespace SiteManagement.Business.Abstract
{
    public interface IPersonService
    {
        CommandResponse Add(AddPersonDto model);

        CommandResponse Update(UpdatePersonDto model);

        CommandResponse Delete(int id);

        CommandResponse Get(int id);

        CommandResponse GetAll();
    }
}
