using SiteManagement.Business.Configuration.Response;
using SiteManagement.DTO.Debt;
using SiteManagement.DTO.MsSql.Debt;
using System.Threading.Tasks;

namespace SiteManagement.Business.Abstract
{
    public interface IDebtService
    {
        CommandResponse AddMultiDebt(AddMultiDebtDto dto);

        Task<CommandResponse> AddDebtPayment(AddDebtPaymentDto dto);

        CommandResponse AddDebt(AddDebtDto dto);

        CommandResponse GetDebtListByUserId(int userId);

        CommandResponse GetPayListByUserId(int userId);
    }
}
