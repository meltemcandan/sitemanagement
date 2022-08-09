using SiteManagement.Business.Configuration.Response;
using SiteManagement.DTO.Message;

namespace SiteManagement.Business.Abstract
{
    public interface IMessageService
    {
        CommandResponse Add(AddMessageDto model);

        CommandResponse Update(UpdateMessageDto model);

        CommandResponse Delete(int id);

        CommandResponse Get(int id);

        CommandResponse GetAll();
    }
}
