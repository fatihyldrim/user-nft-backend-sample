using UnivestHub.Case.Application.Interfaces;
using UnivestHub.Case.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Features.Queries.GetNftMetadata
{
    public class GetNftMetadataHandler : IRequestHandler<GetNftMetadataRequest, GetNftMetadataResponse>
    {
        private readonly INFTRepository _nFTRepository;

        public GetNftMetadataHandler(INFTRepository nFTRepository)
        {
            _nFTRepository = nFTRepository;
        }

        public async Task<GetNftMetadataResponse> Handle(GetNftMetadataRequest request, CancellationToken cancellationToken)
        {
            var nftMetaData = await _nFTRepository.GetNFTMetaData(request.TokenDna);
            if (nftMetaData == null)
            {
                throw new BusinessException("Dna not found", ErrorMessageCodes.DnaNotFound);
            }

            var responseData = new GetNftMetadataResponse()
            {
                Dna = nftMetaData.Dna,
                Name = nftMetaData.NFTData.Name,
                Description = nftMetaData.NFTData.Description,
                Image = nftMetaData.Image,
                TumbImage = nftMetaData.ThumbImage,
                ThreeDimension = nftMetaData.ThreeDimension,
                Collection = nftMetaData.NFTData.Collection,
                Class = nftMetaData.NFTData.Class,
                Type = nftMetaData.NFTData.Type,
                Variant = nftMetaData.NFTData.Variant,
                Rarity = nftMetaData.NFTData.Rarity,
            };
            var attributeList = new List<NFTMetaAttribute>();

            nftMetaData.NFTData.Attributes.ForEach(x =>
                {
                    var attributeData = new NFTMetaAttribute
                    {
                        TraitType = x.TraitType,
                        Value = x.Value
                    };

                    attributeList.Add(attributeData);
                });

            responseData.Attributes = attributeList;
            return responseData;

        }
    }
}
