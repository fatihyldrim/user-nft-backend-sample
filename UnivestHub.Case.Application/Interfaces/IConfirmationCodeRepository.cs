using UnivestHub.Case.Domain.Entities;

namespace UnivestHub.Case.Application.Interfaces
{
    public interface IConfirmationCodeRepository : IRepository<ConfirmationCode>
    {
        public Task UpdateAsync(ConfirmationCode confirmationCode);
    }
}
