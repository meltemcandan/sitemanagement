using FluentValidation;
using SiteManagement.DTO.FlatType;

namespace SiteManagement.Business.Configuration.Validator.FluentValidation.FlatType
{
    public class UpdateFlatTypeDtoValidator : AbstractValidator<UpdateFlatTypeDto>
    {
        public UpdateFlatTypeDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Kayıt id boş olamaz.");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Daire tipi adı boş olamaz.");
        }
    }
}
