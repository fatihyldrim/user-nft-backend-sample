using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnivestHub.Case.Application.Features.Auth.GenerateMailConfirmationCode;
using UnivestHub.Case.Application.Features.Auth.LoginWithEmail;
using UnivestHub.Case.Application.Features.Auth.SaveWallet;
using UnivestHub.Case.Domain.Entities;

namespace UnivestHub.Case.Application.Interfaces
{
    public interface IUserRepository : IRepository<UserData>
    {
        public Task<bool> LoginWithEmail(LoginWithEmailRequest loginWithEmailRequest);
        public Task<bool> SaveWallet(SaveWalletRequest saveWalletRequest);
        public Task GenerateMailConfirmationCode(GenerateMailConfirmationCodeRequest generateMailConfirmationCodeRequest);
    }
}
