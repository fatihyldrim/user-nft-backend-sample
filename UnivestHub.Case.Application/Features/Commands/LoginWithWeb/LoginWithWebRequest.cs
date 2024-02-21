using MediatR;

namespace UnivestHub.Case.Application.Features.Commands.LoginWithWeb
{
    public class LoginWithWebRequest : IRequest<LoginWithWebResponse>
    {
        public string Wallet { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Code { get; set; } = null!;
    }
}
