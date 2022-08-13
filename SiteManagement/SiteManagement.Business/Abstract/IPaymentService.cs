using SiteManagement.Business.Configuration.Response;
using SiteManagement.DTO.Mongo;
using System.Threading.Tasks;

namespace SiteManagement.Business.Abstract
{
    public interface IPaymentService
    {
        Task<CommandResponse> Payment(AddCreditCardDto dto);
    }
}
