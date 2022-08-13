using MongoDB.Bson;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.DTO.Mongo;

namespace SiteManagement.Business.Abstract
{
    public interface ICreditCardService
    {
        CommandResponse Add(AddCreditCardDto dto);
    }
}
