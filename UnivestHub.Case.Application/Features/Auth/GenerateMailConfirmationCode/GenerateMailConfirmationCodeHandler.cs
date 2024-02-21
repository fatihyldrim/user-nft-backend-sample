using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnivestHub.Case.Application.Interfaces;

namespace UnivestHub.Case.Application.Features.Auth.GenerateMailConfirmationCode
{
    public class GenerateMailConfirmationCodeHandler : IRequestHandler<GenerateMailConfirmationCodeRequest>
    {
        private readonly IUserRepository userRepository;
        private readonly IMailService mailService;

        public GenerateMailConfirmationCodeHandler(IUserRepository userRepository, IMailService mailService)
        {
            this.userRepository = userRepository;
            this.mailService = mailService;
        }

        public async Task<Unit> Handle(GenerateMailConfirmationCodeRequest request, CancellationToken cancellationToken)
        {
            await userRepository.GenerateMailConfirmationCode(request);

            return Unit.Value;
        }
    }
}
