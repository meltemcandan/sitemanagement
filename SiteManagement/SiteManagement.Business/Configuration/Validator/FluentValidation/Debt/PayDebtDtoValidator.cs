using FluentValidation;
using SiteManagement.DTO.Debt;

namespace SiteManagement.Business.Configuration.Validator.FluentValidation.Debt
{
    public class PayDebtDtoValidator : AbstractValidator<PayDebtDto>
    {
        public PayDebtDtoValidator()
        {
            RuleFor(x => x.DebtId).NotEmpty().WithMessage("Ödeme seçimi boş geçilemez");
        }
    }
}
