using UnivestHub.Case.Application.Interfaces;
using UnivestHub.Case.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace UnivestHub.Case.Persistance.Repositories
{
    public class MailSubscribeRepository : IMailSubscribeRepository
    {
        private readonly IMongoCollection<MailSubscribe> mailSubscribeCollection;
        public MailSubscribeRepository(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Default"); MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var client = new MongoClient(settings);
            var database = client.GetDatabase("db");
            mailSubscribeCollection = database.GetCollection<MailSubscribe>("MailSubscribe");
        }
        public async Task CreateAsync(MailSubscribe entity)
        {
            await mailSubscribeCollection.InsertOneAsync(entity);
        }

        public async Task<MailSubscribe?> FindAsync(Expression<Func<MailSubscribe, bool>> filter)
        {
            return await mailSubscribeCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<MailSubscribe>> GetAllAsync()
        {
            return await mailSubscribeCollection.Find(x => true).ToListAsync();
        }

        public Task<MailSubscribe?> GetAsync(Expression<Func<MailSubscribe, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async void Remove(MailSubscribe entity)
        {

            await mailSubscribeCollection.UpdateOneAsync(x => x.Id == entity.Id, Builders<MailSubscribe>.Update.Set(x => x.IsSubscribeActive, false)).ConfigureAwait(false);
        }
    }
}
