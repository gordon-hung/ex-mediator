using GH.ExMediator.Core;
using GH.ExMediator.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExMediatorRepository(
        this IServiceCollection services)
        => services.AddTransient<IOrderRepository, OrderRepository>();
}
