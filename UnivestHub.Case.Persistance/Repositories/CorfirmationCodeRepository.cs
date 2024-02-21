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
using System.Xml.Xsl;
using Microsoft.Extensions.Configuration;

namespace UnivestHub.Case.Persistance.Repositories
{
    public class CorfirmationCodeRepository : IConfirmationCodeRepository
    {
        private readonly IMongoCollection<ConfirmationCode> confirmationCodeCollection;
        public CorfirmationCodeRepository(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Default"); 
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var client = new MongoClient(settings);
            var database = client.GetDatabase("db");
            confirmationCodeCollection = database.GetCollection<ConfirmationCode>("ConfirmationCodes");
        }
        public async Task CreateAsync(ConfirmationCode entity)
        {
            await confirmationCodeCollection.InsertOneAsync(entity);
        }

        public async Task<ConfirmationCode?> FindAsync(Expression<Func<ConfirmationCode, bool>> filter)
        {
            return await confirmationCodeCollection.Find(filter).FirstOrDefaultAsync();

        }

        public async Task<List<ConfirmationCode>> GetAllAsync()
        {
            return await confirmationCodeCollection.Find(x => true).ToListAsync();
        }

        public async Task<ConfirmationCode?> GetAsync(Expression<Func<ConfirmationCode, bool>> filter)
        {
            return await confirmationCodeCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async void Remove(ConfirmationCode entity)
        {
            await confirmationCodeCollection.DeleteOneAsync(x => x.Id == entity.Id);
        }

        public async Task UpdateAsync(ConfirmationCode confirmationCode)
        {
            await confirmationCodeCollection.FindOneAndReplaceAsync(x => x.Id == confirmationCode.Id, confirmationCode);
        }
    }
}
