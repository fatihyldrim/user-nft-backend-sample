using UnivestHub.Case.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Features.Commands.CheckEmail
{
    public class CheckEmailHandler : IRequestHandler<CheckEmailRequest, CheckEmailResponse>
    {
        private readonly IUserConnectionRepository repository;

        public CheckEmailHandler(IUserConnectionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CheckEmailResponse> Handle(CheckEmailRequest request, CancellationToken cancellationToken)
        {
            var result = await this.repository.CheckMail(request.WalletAddress);
            return new CheckEmailResponse
            {
                IsExist = result,
            };
        }
    }
}
