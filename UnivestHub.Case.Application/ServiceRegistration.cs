using UnivestHub.Case.Application.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace UnivestHub.Case.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<LogWithMobileValidator>();
        }
    }
}
