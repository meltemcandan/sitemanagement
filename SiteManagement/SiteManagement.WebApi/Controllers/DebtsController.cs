using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Abstract;
using SiteManagement.DTO.Debt;
using SiteManagement.DTO.MsSql.Debt;
using SiteManagement.Model.Enums;
using SiteManagement.WebApi.Configuration.Filters.Auth;
using System.Threading.Tasks;

namespace SiteManagement.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DebtsController : ControllerBase
    {
        private readonly IDebtService _debtService;

        public DebtsController(IDebtService debtService)
        {
            _debtService = debtService;
        }

        [HttpPost]
        [Permission(PermissionEnum.DebtPost)]
        public IActionResult AddDebt(AddDebtDto dto)
        {
            return Ok(_debtService.AddDebt(dto));
        }

        [HttpPost("AddMultiDebt")]
        [Permission(PermissionEnum.AddMultiDebt)]
        public IActionResult AddMultiDebt(AddMultiDebtDto dto)
        {
            return Ok(_debtService.AddMultiDebt(dto));
        }

        [HttpPost("AddDebtPayment")]
        [Permission(PermissionEnum.AddDebtPayment)]
        public async Task<IActionResult> AddDebtPayment(AddDebtPaymentDto dto)
        {
            return Ok(await _debtService.AddDebtPayment(dto));
        }

        [HttpGet("GetDebtListByUserId")]
        [Permission(PermissionEnum.GetDebtListByUserId)]
        public async Task<IActionResult> GetDebtListByUserId(int userId)
        {
            return Ok(_debtService.GetDebtListByUserId(userId));
        }

        [HttpGet("GetPayListByUserId")]
        [Permission(PermissionEnum.GetPayListByUserId)]
        public async Task<IActionResult> GetPayListByUserId(int userId)
        {
            return Ok(_debtService.GetPayListByUserId(userId));
        }
    }
}
