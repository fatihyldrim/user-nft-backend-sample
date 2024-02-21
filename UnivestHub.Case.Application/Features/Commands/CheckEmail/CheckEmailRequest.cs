using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Features.Commands.CheckEmail
{
    public class CheckEmailRequest : IRequest<CheckEmailResponse>
    {
        public string WalletAddress { get; set; }

        public CheckEmailRequest(string walletAddress)
        {
            WalletAddress = walletAddress;
        }
    }

    public class CheckEmailResponse
    {
        public bool IsExist { get; set; }
    }
}
