using UnivestHub.Case.Application.Interfaces;
using UnivestHub.Case.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace UnivestHub.Case.Persistance.Repositories
{
    public class NFTRepository : INFTRepository
    {
        private readonly IMongoCollection<NFTMetaData> _nftMetaDataCollection;
        private readonly IMongoCollection<NFTData> _nftDataCollection;
        private readonly IMongoCollection<NFTAttribute> _nftAttributeCollection;
        private readonly IMongoCollection<NFTMetaData> _NFTMetaDataCollection;
        private readonly IMongoCollection<UserNFTData> _userNFTDataCollection;
    

        public NFTRepository(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Default"); 
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var client = new MongoClient(settings);
            var database = client.GetDatabase("db");
            _nftMetaDataCollection = database.GetCollection<NFTMetaData>("NFTMetaData");
            _nftDataCollection = database.GetCollection<NFTData>("NFTData");
            _nftAttributeCollection = database.GetCollection<NFTAttribute>("NFTAttribute");
            _NFTMetaDataCollection = database.GetCollection<NFTMetaData>("NFTMetaData");
            _userNFTDataCollection = database.GetCollection<UserNFTData>("UserNFTData");
        }
        public async Task<NFTMetaData?> GetNFTMetaData(string tokenDna)
        {
            var nftMetaData = await _nftMetaDataCollection.Find(x => x.Dna == tokenDna).SingleOrDefaultAsync();
            if (nftMetaData == null)
            {
                return null;
            }
            var nftData = await _nftDataCollection.Find(x => x.Id == nftMetaData.NFTDataId).SingleOrDefaultAsync();
            var nftAttribute = await _nftAttributeCollection.Find(x => x.DataId == nftMetaData.NFTDataId).ToListAsync();
            nftData.Attributes = nftAttribute;
            nftMetaData.NFTData = nftData;
            return nftMetaData;
        }
        public async Task CreateNFTAsync(NFTMetaData entity)
        {
            await _NFTMetaDataCollection.InsertOneAsync(entity);
        }

        public async Task CreateUserNFTDataAsync(UserNFTData userNFTData)
        {
            await _userNFTDataCollection.InsertOneAsync(userNFTData);
        }

        public async Task DeleteUserNFTAsync(string id)
        {
            await _userNFTDataCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<UserNFTData?> GetUserNFTData(int tokenId)
        {
            return await _userNFTDataCollection.Find(x => x.NFT == tokenId).SingleOrDefaultAsync();
        }

    }
}
