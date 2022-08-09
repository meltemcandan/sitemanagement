using SiteManagement.Business.Configuration.Response;
using SiteManagement.DTO.Debt;

namespace SiteManagement.Business.Abstract
{
    public interface IDebtService
    {
        CommandResponse Add(AddDebtDto model);
    }
}
