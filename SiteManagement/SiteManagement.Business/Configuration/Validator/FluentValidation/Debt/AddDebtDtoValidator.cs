using FluentValidation;
using SiteManagement.DTO.MsSql.Debt;

namespace SiteManagement.Business.Configuration.Validator.FluentValidation.Debt
{
    public class AddDebtDtoValidator : AbstractValidator<AddDebtDto>
    {
        public AddDebtDtoValidator()
        {
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ödeme alanı boş geçilemez");

            RuleFor(x => x.MonthId).NotEmpty().WithMessage("Ödeme ayı boş geçilemez");

            RuleFor(x => x.YearId).NotEmpty().WithMessage("Ödeme yılı boş geçilemez");

            RuleFor(x => x.DebtTypeId).NotEmpty().WithMessage("Ödeme türü boş geçilemez");

            RuleFor(x => x.UserId).NotEmpty().WithMessage("ödeme atanacak kullanızı boş geçilemez");
        }
    }
}
