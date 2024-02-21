using UnivestHub.Case.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Features.Queries.GetNFT
{
    public class GetNFTRequest : IRequest<NFTMetaData>
    {
        public string TokenId { get; set; }

        public GetNFTRequest(string tokenId)
        {
            TokenId = tokenId;
        }
    }

}
