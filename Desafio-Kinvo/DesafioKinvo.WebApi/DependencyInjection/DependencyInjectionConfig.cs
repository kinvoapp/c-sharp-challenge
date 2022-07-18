using DesafioKinvo.Domain.Interfaces;
using DesafioKinvo.Data.Repository;
using DesafioKinvo.Domain.Service;
using DesafioKinvo.Data;
using DesafioKinvo.Core.DomainObjects;
using DesafioKinvo.Core.Interfaces;

namespace DesafioKinvo.WebApi.DependencyInjection
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientService, ClienteService>();
            services.AddScoped<IInvestmentService, InvestmentService>();
            services.AddScoped<IInvestmentRepository, InvestmentRepository>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<DataContext>();

            return services;
        }
    }
}
