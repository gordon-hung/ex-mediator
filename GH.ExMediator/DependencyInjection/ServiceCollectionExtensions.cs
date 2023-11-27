using GH.ExMediator.Core;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExMediator(
        this IServiceCollection services,
        Action<IPAddressOptions, IServiceProvider> ipAddressOptions)
        => services
        .AddOptions<IPAddressOptions>()
        .Configure(ipAddressOptions)
        .Services
        .AddExMediatorCore()
        .AddExMediatorRepository();
}
