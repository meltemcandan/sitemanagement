using FluentValidation;
using SiteManagement.DTO.MsSql.Debt;

namespace SiteManagement.Business.Configuration.Validator.FluentValidation.Debt
{
    public class AddDebtPaymentDtoValidator : AbstractValidator<AddDebtPaymentDto>
    {
        public AddDebtPaymentDtoValidator()
        {
            RuleFor(x => x.DebtId).NotEmpty().WithMessage("Ödeme seçimi boş geçilemez");

            RuleFor(x => x.CardNumber).NotEmpty().WithMessage("Ödeme için kart numarası geçilemez");

            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Ödeme için kart sahibi geçilemez");

            RuleFor(x => x.ExpireMonth).NotEmpty().WithMessage("Ödeme için son kullanma ay bilgisi boş geçilemez");

            RuleFor(x => x.ExpireYear).NotEmpty().WithMessage("Ödeme için son kullanma yıl bilgisi boş geçilemez");
        }
    }
}
