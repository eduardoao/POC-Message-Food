using Microsoft.Extensions.DependencyInjection;
using POC.Modules.Application.Commands.PlaceOrder;

namespace POC.Modules.Infrastructure.IoC.Application
{
    internal class ApplicationBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IPlaceOrderUseCase, PlaceOrderUseCase>();

        }
    }
}
