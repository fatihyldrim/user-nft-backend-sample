using UnivestHub.Case.Domain.Entities;

namespace UnivestHub.Case.Application.Interfaces
{
    public interface IUserConnectionRepository : IRepository<UserConnection>
    {
        public Task UpdateAsync(UserConnection confirmationCode);
        public Task<bool> CheckMail(string walletAddress);
    }
}
