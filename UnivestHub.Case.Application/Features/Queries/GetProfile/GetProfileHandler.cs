using UnivestHub.Case.Application.Interfaces;
using UnivestHub.Case.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Features.Queries.GetProfile
{
    public class GetProfileHandler : IRequestHandler<GetProfileRequest, GetProfileResponse>
    {
        private readonly IUserConnectionRepository userConnectionRepository;

        public GetProfileHandler(IUserConnectionRepository userConnectionRepository)
        {
            this.userConnectionRepository = userConnectionRepository;
        }

        public async Task<GetProfileResponse> Handle(GetProfileRequest request, CancellationToken cancellationToken)
        {
            var userConnection = await this.userConnectionRepository.GetAsync(x => x.CustomId == request.CustomId);
            if(userConnection == null)
            {
                throw new BusinessException("CustomId not found",ErrorMessageCodes.CustomIdNotFound);
            }

            return new GetProfileResponse
            {
                Email = userConnection?.Email,
            };
        }
    }
}
