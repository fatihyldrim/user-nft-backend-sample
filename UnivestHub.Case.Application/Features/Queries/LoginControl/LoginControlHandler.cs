using UnivestHub.Case.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Features.Queries.LoginControl
{
    public class LoginControlHandler : IRequestHandler<LoginControlRequest, bool>
    {
        private readonly IUserConnectionRepository _userConnectionRepository;

        public LoginControlHandler(IUserConnectionRepository userConnectionRepository)
        {
            _userConnectionRepository = userConnectionRepository;
        }

        public async Task<bool> Handle(LoginControlRequest request, CancellationToken cancellationToken)
        {
            var user = await _userConnectionRepository.FindAsync(x => x.Email == request.Email && x.MobileId == request.MobileId);
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}
