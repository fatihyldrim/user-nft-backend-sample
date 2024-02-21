using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnivestHub.Case.Application.Interfaces;

namespace UnivestHub.Case.Application.Features.Auth.LoginWithEmail
{
    public class LoginWithEmailHandler : IRequestHandler<LoginWithEmailRequest, bool>
    {
        private readonly IUserRepository userRepository;
        public LoginWithEmailHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> Handle(LoginWithEmailRequest request, CancellationToken cancellationToken)
        {
            return await userRepository.LoginWithEmail(request);
        }
    }
}
