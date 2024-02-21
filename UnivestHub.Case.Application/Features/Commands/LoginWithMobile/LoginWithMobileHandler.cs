using UnivestHub.Case.Application.Interfaces;
using UnivestHub.Case.Common.Exceptions;
using UnivestHub.Case.Domain.Entities;
using MediatR;

namespace UnivestHub.Case.Application.Features.Commands.LoginWithMobile
{
    public class LoginWithMobileHandler : IRequestHandler<LoginWithMobileRequest, LoginWithMobileResponse>
    {
        private readonly IUserConnectionRepository userConnectionRepository;
        private readonly IConfirmationCodeRepository confirmationCodeRepository;

        public LoginWithMobileHandler(IUserConnectionRepository userConnectionRepository, IConfirmationCodeRepository confirmationCodeRepository)
        {
            this.userConnectionRepository = userConnectionRepository;
            this.confirmationCodeRepository = confirmationCodeRepository;
        }

        public async Task<LoginWithMobileResponse> Handle(LoginWithMobileRequest request, CancellationToken cancellationToken)
        {
            var customId = string.Empty;
            var confirmationCode = await confirmationCodeRepository.GetAsync(x => x.Email == request.Email);
            if (confirmationCode == null)
            {
                throw new BusinessException("verify your email address", ErrorMessageCodes.EmailValidationCode);
            }

            if (confirmationCode.Code != request.Code)
            {
                throw new BusinessException("your code doesn't match", ErrorMessageCodes.DoesnotMatch);
            }

            var emailExistControl = await userConnectionRepository.FindAsync(x => x.Email == request.Email);
            customId = Guid.NewGuid().ToString();

            if (emailExistControl == null)
            {
                var mobilIdExist = await userConnectionRepository.GetAsync(x => x.MobileId == request.MobileId);
                if (mobilIdExist != null)
                {
                    throw new BusinessException("MobileId already exist", ErrorMessageCodes.MobileIdIsExist);
                }
                var newRecord = new UserConnection
                {
                    Email = request.Email,
                    CustomId = customId,
                    MobileId = request.MobileId,
                    MobileEmailCode = confirmationCode.Code,
                    MobileEmailVerificationDate = DateTime.UtcNow,
                    IsActive = true,
                    ParentId = null,
                };
                await userConnectionRepository.CreateAsync(newRecord);
            }
            else
            {

                customId = emailExistControl.CustomId;
                emailExistControl.MobileId = request.MobileId;
                emailExistControl.MobileEmailCode = request.Code;
                emailExistControl.MobileEmailVerificationDate = DateTime.UtcNow;
                emailExistControl.IsActive = true;
                emailExistControl.ParentId = null;

                await userConnectionRepository.UpdateAsync(emailExistControl);
            }

            return new LoginWithMobileResponse
            {
                CustomId = customId
            };
        }
    }
}
