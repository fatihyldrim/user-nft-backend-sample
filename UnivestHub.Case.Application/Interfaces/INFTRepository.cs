using UnivestHub.Case.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Interfaces
{
    public interface INFTRepository
    {
        Task<NFTMetaData?> GetNFTMetaData(string tokenDna);
        Task CreateNFTAsync(NFTMetaData NFT);
        Task CreateUserNFTDataAsync(UserNFTData userNFTData);
        Task DeleteUserNFTAsync(string id);
        Task<UserNFTData?> GetUserNFTData(int tokenId);

    }
}
