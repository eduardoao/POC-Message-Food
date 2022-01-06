using Microsoft.Extensions.DependencyInjection;
using POC.Modules.Infrastructure.IoC.Application;
using POC.Modules.Infrastructure.IoC.Infrastructure;

namespace POC.Modules.Infrastructure.IoC
{
    public class RootBootstrapper
    {
        public void BootstrapperRegisterServices(IServiceCollection services)
        {
            new ApplicationBootstrapper().ChildServiceRegister(services);
            new InfrastructureBootstrapper().ChildServiceRegister(services);
        }
    }
}
