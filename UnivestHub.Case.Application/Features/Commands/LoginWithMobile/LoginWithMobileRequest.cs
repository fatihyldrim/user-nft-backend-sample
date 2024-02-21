using MediatR;

namespace UnivestHub.Case.Application.Features.Commands.LoginWithMobile
{
    public class LoginWithMobileRequest : IRequest<LoginWithMobileResponse>
    {
        public string Email { get; set; } = null!;
        public string MobileId { get; set; } = null!;

        public string Code { get; set; } = null!;
    }
}
