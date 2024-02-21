using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Features.Auth.SaveWallet
{
    public class SaveWalletRequest : IRequest<bool>
    {
        public string Email { get; set; }
        public string WalletAddress { get; set; }
        public string WalletMnemonic { get; set; }
        public string WalletPrivateKey { get; set; }
    }
}
