using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Features.Queries.GetProfile
{
    public class GetProfileRequest : IRequest<GetProfileResponse>
    {
        public string CustomId { get; set; }

        public GetProfileRequest(string customId)
        {
            CustomId = customId;
        }
    }
}
