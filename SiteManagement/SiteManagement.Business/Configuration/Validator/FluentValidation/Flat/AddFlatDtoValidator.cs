using FluentValidation;
using SiteManagement.DTO.Flat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Configuration.Validator.FluentValidation.Flat
{
    public class AddFlatDtoValidator : AbstractValidator<AddFlatDto>
    {
        public AddFlatDtoValidator()
        {
            RuleFor(x => x.BlockId).NotEmpty().WithMessage("Blok seçimi boş geçilemez");

            RuleFor(x => x.FlatTypeId).NotEmpty().WithMessage("Kat tipi seçimi boş geçilemez");

            RuleFor(x => x.Floor).NotEmpty().WithMessage("Bulunduğu kat boş geçilemez");

            RuleFor(x => x.No).NotEmpty().WithMessage("Kat numarası boş geçilemez");
        }
    }
}
