using FluentValidation;
using SiteManagement.DTO.Message;

namespace SiteManagement.Business.Configuration.Validator.FluentValidation.Message
{
    public class AddMessageDtoValidator : AbstractValidator<AddMessageDto>
    {
        public AddMessageDtoValidator()
        {
            RuleFor(x => x.SendedUserId).NotEmpty().WithMessage("Mesajı gönderen kişi boş geçilemez");

            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mesaj başlığı boş geçilemez");

            RuleFor(x => x.Text).NotEmpty().WithMessage("Mesaj içeriği boş geçilemez");
        }
    }
}
