using FluentValidation;
using SiteManagement.DTO.Message;

namespace SiteManagement.Business.Configuration.Validator.FluentValidation.Message
{
    public class UpdateMessageDtoValidator : AbstractValidator<UpdateMessageDto>
    {
        public UpdateMessageDtoValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mesaj başlığı boş geçilemez");

            RuleFor(x => x.Text).NotEmpty().WithMessage("Mesaj içeriği boş geçilemez");
        }
    }
}
