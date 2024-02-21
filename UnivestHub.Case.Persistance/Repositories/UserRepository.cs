using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using UnivestHub.Case.Application.Features.Auth.GenerateMailConfirmationCode;
using UnivestHub.Case.Application.Features.Auth.LoginWithEmail;
using UnivestHub.Case.Application.Features.Auth.SaveWallet;
using UnivestHub.Case.Application.Interfaces;
using UnivestHub.Case.Domain.Entities;
using static MongoDB.Driver.WriteConcern;

namespace UnivestHub.Case.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserData> userData;

        public UserRepository(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Default");

            MongoClientSettings settings = MongoClientSettings.FromUrl(
          new MongoUrl(connectionString)
        );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var client = new MongoClient(settings);
            var database = client.GetDatabase("db");
            userData = database.GetCollection<UserData>("UserData");
        }

        public async Task CreateAsync(UserData entity)
        {
            await userData.InsertOneAsync(entity);
        }

        public async Task<UserData?> FindAsync(Expression<Func<UserData, bool>> filter)
        {
            return await userData.Find(filter).FirstOrDefaultAsync();
        }

        public async Task GenerateMailConfirmationCode(GenerateMailConfirmationCodeRequest generateMailConfirmationCodeRequest)
        {
            var data = await GetAsync(x => x.Email == generateMailConfirmationCodeRequest.Email);

            if (data is null)
            {
                await CreateAsync(new UserData
                {
                    Email = generateMailConfirmationCodeRequest.Email,
                    ConfirmationCode = "1111"
                });
            }
            else
            {
                //TODO create different code and update
            }
        }

        public async Task<List<UserData>> GetAllAsync()
        {
            return await userData.Find(x => true).ToListAsync();
        }

        public async Task<UserData?> GetAsync(Expression<Func<UserData, bool>> filter)
        {
            return await userData.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> LoginWithEmail(LoginWithEmailRequest loginWithEmailRequest)
        {
            var data = await GetAsync(x => x.Email == loginWithEmailRequest.Email && x.ConfirmationCode == loginWithEmailRequest.ConfirmationCode);

            if (data is null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public async void Remove(UserData entity)
        {
            await userData.DeleteOneAsync(x => x.Id == entity.Id);
        }

        public async Task<bool> SaveWallet(SaveWalletRequest saveWalletRequest)
        {
            var filter = Builders<UserData>.Filter
                .Eq(x => x.Email, saveWalletRequest.Email);

            var update = Builders<UserData>.Update
                .Set(x => x.WalletAddress, saveWalletRequest.WalletAddress)
                .Set(x => x.WalletMnemonic, saveWalletRequest.WalletMnemonic)
                .Set(x => x.WalletPrivateKey, saveWalletRequest.WalletPrivateKey);

            await userData.UpdateOneAsync(filter, update);

            return true;
        }
    }
}
