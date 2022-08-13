using FluentValidation;
using SiteManagement.DTO.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Configuration.Validator.FluentValidation.Site
{
    public class AddSiteDtoValidator : AbstractValidator<AddSiteDto>
    {
        public AddSiteDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Site adı boş geçilemez");
            RuleFor(x => x.UserEmail).NotEmpty().WithMessage("Yönetici eposta adresi boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Yönetici adı boş geçilemez");
            RuleFor(x => x.UserSurname).NotEmpty().WithMessage("Yönetici soyadı boş geçilemez");
            RuleFor(x => x.IdentificationNumber).NotEmpty().WithMessage("Yönetici kimlik numarası boş geçilemez");
            RuleFor(x => x.NumberOfBlock).NotEmpty().WithMessage("Blok sayısı boş geçilemez");
            RuleFor(x => x.NumberOfFloors).NotEmpty().WithMessage("Blok başına kat sayısı boş geçilemez");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş geçilemez");
            RuleFor(x => x.PasswordRepeat).NotEmpty().WithMessage("Parola tekrarı boş geçilemez");
            RuleFor(x => x.PasswordRepeat).Equal(x=> x.Password).WithMessage("Parolalar aynı olmalı");
        }
    }
}
