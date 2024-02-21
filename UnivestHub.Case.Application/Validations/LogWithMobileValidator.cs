using UnivestHub.Case.Application.Features.Commands.LoginWithMobile;
using FluentValidation;

namespace UnivestHub.Case.Application.Validations
{
    public class LogWithMobileValidator : BaseValidator<LoginWithMobileRequest>
    {
        public LogWithMobileValidator()
        {
            this.RuleFor(x => x.MobileId).NotEmpty().WithMessage("MobileId is required");
        }
    }
}
