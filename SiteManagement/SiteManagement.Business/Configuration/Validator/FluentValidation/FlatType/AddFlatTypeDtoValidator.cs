using FluentValidation;
using SiteManagement.DTO.FlatType;

namespace SiteManagement.Business.Configuration.Validator.FluentValidation.FlatType
{
    public class AddFlatTypeDtoValidator : AbstractValidator<AddFlatTypeDto>
    {
        public AddFlatTypeDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Daire tipi adı boş olamaz.");
        }
    }
}
