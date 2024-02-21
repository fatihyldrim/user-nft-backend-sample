using UnivestHub.Case.Application.Interfaces;
using UnivestHub.Case.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Features.Commands.NFTTransaction
{
    public class NFTTransactionHandler : IRequestHandler<NFTTransactionRequest, NFTTransactionResponse>
    {
        private readonly INFTRepository _nFTRepository;
        private readonly string bankAddress = "0x0000000000000000000000000000000000000000";
        public NFTTransactionHandler(INFTRepository nFTRepository)
        {
            _nFTRepository = nFTRepository;
        }

        public async Task<NFTTransactionResponse> Handle(NFTTransactionRequest request, CancellationToken cancellationToken)
        {
            foreach (var activity in request.Event.Activity)
            {
                var nft = Convert.ToInt32(activity.Erc721TokenId, 16);
                if (activity.FromAddress != bankAddress)
                {
                    var sellerNft = await _nFTRepository.GetUserNFTData(nft);
                    if (sellerNft != null)
                    {
                        await _nFTRepository.DeleteUserNFTAsync(sellerNft.Id);
                    }
                }
                var buyer = new UserNFTData();
                buyer.NFT = nft;
                buyer.WalletAddress = activity.ToAddress;
                await _nFTRepository.CreateUserNFTDataAsync(buyer);

            }
            return new NFTTransactionResponse() { Result = true };
        }
    }
}
