using FluentValidation;
using SiteManagement.DTO.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Configuration.Validator.FluentValidation.Block
{
    public class UpdateBlockDtoValidator : AbstractValidator<UpdateBlockDto>
    {
        public UpdateBlockDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Blok adı boş geçilemez");
        }
    }
}
