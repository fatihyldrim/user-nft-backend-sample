using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnivestHub.Case.Application.Interfaces;

namespace UnivestHub.Case.Application.Features.Auth.SaveWallet
{
    public class SaveWalletHandler : IRequestHandler<SaveWalletRequest, bool>
    {
        private readonly IUserRepository userRepository;
        public SaveWalletHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<bool> Handle(SaveWalletRequest request, CancellationToken cancellationToken)
        {
            return userRepository.SaveWallet(request);
        }
    }
}
