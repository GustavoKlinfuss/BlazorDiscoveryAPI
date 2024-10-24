using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorDiscoveryAPI.Application
{
    public static class ApplicationIoC
    {
        public static void ResolveApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(ApplicationIoC).Assembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(FailFastValidationBehavior<,>));
            });

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidationBehavior<,>));
        }
    }
}
