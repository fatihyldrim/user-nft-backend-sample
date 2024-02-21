using UnivestHub.Case.Application.Interfaces;
using UnivestHub.Case.Domain.Entities;
using MongoDB.Driver;
using System.Linq.Expressions;
using System.Security.Authentication;
using Microsoft.Extensions.Configuration;

namespace UnivestHub.Case.Persistance.Repositories
{
    public class UserConnectionRepository :IUserConnectionRepository
    {
        private readonly IMongoCollection<UserConnection> userConnectionCollection;
        public UserConnectionRepository(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Default");
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var client = new MongoClient(settings);
            var database = client.GetDatabase("db");
            userConnectionCollection = database.GetCollection<UserConnection>("UserConnections");
        }
        public async Task<bool> CheckMail(string walletAddress)
        {
            var result = await userConnectionCollection.Find(x=> x.WalletAddress == walletAddress).FirstOrDefaultAsync();
            if (string.IsNullOrWhiteSpace(result?.Email))
                return false;
            return true;
        }

        public async Task CreateAsync(UserConnection entity)
        {
            await userConnectionCollection.InsertOneAsync(entity);
        }

        public async Task<UserConnection?> FindAsync(Expression<Func<UserConnection, bool>> filter)
        {
            return await userConnectionCollection.Find(filter).FirstOrDefaultAsync();

        }

        public async Task<List<UserConnection>> GetAllAsync()
        {
            return await userConnectionCollection.Find(x => true).ToListAsync();
        }

        public async Task<UserConnection?> GetAsync(Expression<Func<UserConnection, bool>> filter)
        {
            return await userConnectionCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async void Remove(UserConnection entity)
        {
            await userConnectionCollection.DeleteOneAsync(x => x.Id == entity.Id);
        }

        public async Task UpdateAsync(UserConnection confirmationCode)
        {
            await userConnectionCollection.FindOneAndReplaceAsync(x => x.Id == confirmationCode.Id, confirmationCode);
        }
    }
}
