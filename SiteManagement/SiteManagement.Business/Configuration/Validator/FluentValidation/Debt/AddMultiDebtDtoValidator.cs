using FluentValidation;
using SiteManagement.DTO.Debt;

namespace SiteManagement.Business.Configuration.Validator.FluentValidation.Debt
{
    public class AddMultiDebtDtoValidator : AbstractValidator<AddMultiDebtDto>
    {
        public AddMultiDebtDtoValidator()
        {
            RuleFor(x => x.YearId).NotEmpty().WithMessage("Ödeme yılı boş geçilemez");

            RuleFor(x => x.UserIds).NotEmpty().WithMessage("Borç atanacak kullanıcı ekleyiniz");

            RuleFor(x => x.MonthIds).NotEmpty().WithMessage("Borç atanacak ayları ekleyiniz");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Borç miktarını ekleyiniz");

            RuleFor(x => x.DebtTypeId).NotEmpty().WithMessage("Borç tipi seçiniz");
        }
    }
}
