using System.Reflection;
using GH.ExMediator.Core;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExMediatorCore(
        this IServiceCollection services)
        => services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
        .AddScoped<ISnowflakeWork, SnowflakeWork>();
}
