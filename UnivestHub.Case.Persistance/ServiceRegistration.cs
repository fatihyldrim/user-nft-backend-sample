using UnivestHub.Case.Application.Interfaces;
using UnivestHub.Case.Persistance.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnivestHub.Case.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IConfirmationCodeRepository, CorfirmationCodeRepository>();
            services.AddScoped<IUserConnectionRepository, UserConnectionRepository>();
            services.AddScoped<INFTRepository, NFTRepository>();
            services.AddScoped<IMailSubscribeRepository, MailSubscribeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
