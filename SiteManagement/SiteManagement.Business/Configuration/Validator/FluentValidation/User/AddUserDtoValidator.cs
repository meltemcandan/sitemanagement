using FluentValidation;
using SiteManagement.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Configuration.Validator.FluentValidation.User
{
    public class AddUserDtoValidator : AbstractValidator<AddUserDto>
    {
        public AddUserDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Kullanıcı soyadı boş olamaz.");

            RuleFor(x => x.IdentificationNumber).NotEmpty().WithMessage("Kullanıcı kimlik numarası boş olamaz.");

            RuleFor(x => x.IdentificationNumber).NotEmpty().WithMessage("Kullanıcı eposta adresi boş olamaz.");
        }
    }
}
