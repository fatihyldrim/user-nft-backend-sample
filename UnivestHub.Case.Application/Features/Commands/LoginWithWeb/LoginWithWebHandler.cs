using UnivestHub.Case.Application.Interfaces;
using UnivestHub.Case.Common.Exceptions;
using UnivestHub.Case.Domain.Entities;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UnivestHub.Case.Application.Features.Commands.LoginWithWeb
{
    public class LoginWithWebHandler : IRequestHandler<LoginWithWebRequest, LoginWithWebResponse>
    {
        private readonly IUserConnectionRepository userConnectionRepository;
        private readonly IConfirmationCodeRepository confirmationCodeRepository;
        public LoginWithWebHandler(IUserConnectionRepository userConnectionRepository, IConfirmationCodeRepository confirmationCodeRepository)
        {
            this.userConnectionRepository = userConnectionRepository;
            this.confirmationCodeRepository = confirmationCodeRepository;
        }
        public async Task<LoginWithWebResponse> Handle(LoginWithWebRequest request, CancellationToken cancellationToken)
        {

            var userClaims = new List<Claim>();
            var endDate = DateTime.UtcNow.AddDays(1);
            var confirmationCode = await confirmationCodeRepository.GetAsync(x => x.Code == request.Code && x.Email == request.Email && x.CreatedDate > DateTime.UtcNow.Date && x.CreatedDate < endDate.Date);
            if (confirmationCode == null)
            {
                throw new BusinessException("Confirmation Code Not Match.", "20002");
            }
            var userConnection = await userConnectionRepository.FindAsync(x => x.Email == request.Email && x.IsActive);
            var customId = "";
            if (userConnection == null)
            {
                var isWalletExist = await userConnectionRepository.GetAsync(x => x.WalletAddress == request.Wallet);
                if (isWalletExist != null)
                {
                    throw new BusinessException("This wallet has already linked with another email.", "20005");
                }

                var newUserConnection = new UserConnection
                {
                    Email = request.Email,
                    IsActive = true,
                    WebEmailCode = request.Code,
                    WebEmailVerificationDate = DateTime.UtcNow,
                    WalletAddress = request.Wallet,
                    CustomId = Guid.NewGuid().ToString(),
                };
                await userConnectionRepository.CreateAsync(newUserConnection);
                customId = newUserConnection.CustomId;
            }
            else
            {
                if (userConnection.WalletAddress != request.Wallet && userConnection.WalletAddress != null)
                {
                    throw new BusinessException("This mail has already linked with another wallet.", "20006");
                }
                userConnection.WalletAddress ??= request.Wallet;
                userConnection.WebEmailCode = request.Code;
                userConnection.WebEmailVerificationDate = DateTime.UtcNow;
                customId = userConnection.CustomId;
                await userConnectionRepository.UpdateAsync(userConnection);
            }


            userClaims.Add(new Claim("wallet", request.Wallet));
            userClaims.Add(new Claim("customId", customId));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secRetKey!."));

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(issuer: "http://localhost", audience: "http://localhost", claims: userClaims, notBefore: DateTime.UtcNow, expires: DateTime.UtcNow.AddDays(30), signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);


            return new LoginWithWebResponse { CustomId = customId, Token = tokenString };
        }
    }
}
