using UnivestHub.Case.Application.Features.Queries.GetNftMetadata;
using UnivestHub.Case.Application.Interfaces;
using UnivestHub.Case.Common.Exceptions;
using UnivestHub.Case.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Features.Queries.GetNFT
{
    public class GetNFTHandler : IRequestHandler<GetNFTRequest, NFTMetaData>
    {
        private readonly INFTRepository _nFTRepository;

        public GetNFTHandler(INFTRepository nFTRepository)
        {
            _nFTRepository = nFTRepository;
        }

        public async Task<NFTMetaData> Handle(GetNFTRequest request, CancellationToken cancellationToken)
        {
            var NFTMetaData = await _nFTRepository.GetNFTMetaData(request.TokenId);
            if (NFTMetaData == null)
            {
                throw new BusinessException("Dna not found", ErrorMessageCodes.DnaNotFound);
            }
            return NFTMetaData;

        }
    }
}
