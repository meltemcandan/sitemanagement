using SiteManagement.Business.Configuration.Response;
using SiteManagement.DTO.Message;

namespace SiteManagement.Business.Abstract
{
    public interface IMessageService
    {
        CommandResponse Add(AddMessageDto dto);

        CommandResponse Update(UpdateMessageDto dto);

        CommandResponse Delete(int id);

        CommandResponse Get(int id);

        CommandResponse GetAll();

        CommandResponse GetAllByUserId(int userId);
    }
}
