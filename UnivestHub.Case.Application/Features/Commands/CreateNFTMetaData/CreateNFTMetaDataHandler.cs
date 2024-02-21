using UnivestHub.Case.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Features.Commands.CreateNFTMetaData
{
    public class CreateNFTMetaDataHandler : IRequestHandler<CreateNFTMetaDataRequest, bool>
    {
        private readonly INFTRepository _nFTRepository;

        public CreateNFTMetaDataHandler(INFTRepository nFTRepository)
        {
            _nFTRepository = nFTRepository;
        }

        public async Task<bool> Handle(CreateNFTMetaDataRequest request, CancellationToken cancellationToken)
        {
            request.MetaDatas.ForEach(async x =>
            {
                var NFTMetaData = await _nFTRepository.GetNFTMetaData(x.Id);
                if (NFTMetaData == null)
                {
                    await _nFTRepository.CreateNFTAsync(x);
                }
            });
            return true;
        }
    }
}
