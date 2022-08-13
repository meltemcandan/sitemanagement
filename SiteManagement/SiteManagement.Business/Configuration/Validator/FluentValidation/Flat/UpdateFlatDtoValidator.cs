using FluentValidation;
using SiteManagement.DTO.Flat;

namespace SiteManagement.Business.Configuration.Validator.FluentValidation.Flat
{
    public class UpdateFlatDtoValidator : AbstractValidator<UpdateFlatDto>
    {
        public UpdateFlatDtoValidator()
        {
            RuleFor(x => x.BlockId).NotEmpty().WithMessage("Blok seçimi boş geçilemez");

            RuleFor(x => x.FlatTypeId).NotEmpty().WithMessage("Kat tipi seçimi boş geçilemez");

            RuleFor(x => x.Floor).NotEmpty().WithMessage("Bulunduğu kat boş geçilemez");

            RuleFor(x => x.No).NotEmpty().WithMessage("Kat numarası boş geçilemez");
        }
    }
}
