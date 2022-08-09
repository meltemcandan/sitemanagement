using SiteManagement.Business.Configuration.Response;
using SiteManagement.DTO.Mongo;
using System.Threading.Tasks;

namespace SiteManagement.Business.Integration.Abstract
{
    public interface IPaymentService
    {
        Task<CommandResponse> PayAsync(AddCreditCardDto dto);
    }
}
