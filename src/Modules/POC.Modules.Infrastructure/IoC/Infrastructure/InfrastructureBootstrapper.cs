using Microsoft.Extensions.DependencyInjection;
using POC.Adapters.KafkaStreaming.Producer;
using POC.Adapters.MySqlDataAccess.ReadOnlyRepositories;
using POC.Adapters.MySqlDataAccess.WriteOnlyRepositories;
using POC.Modules.Application.Abstractions.Commands;
using POC.Modules.Application.Abstractions.Queries;

namespace POC.Modules.Infrastructure.IoC.Infrastructure
{
    internal class InfrastructureBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<ICustomerReadOnlyRepository, CustomerReadOnlyRepository>();
            services.AddScoped<IProductReadOnlyRepository, ProductReadOnlyRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IKafkaAdapter, KafkaAdapterProducer>();

        }
    }
}
