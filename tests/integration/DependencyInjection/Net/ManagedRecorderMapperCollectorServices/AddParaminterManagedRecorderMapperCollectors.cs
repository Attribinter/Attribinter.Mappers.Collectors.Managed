namespace Paraminter.Recorders.Mappers.Collectors.Managed;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Xunit;

public sealed class AddParaminterManagedRecorderMapperCollectors
{
    [Fact]
    public void IArgumentDataRecorderMappingRegistratorFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IArgumentDataRecorderMappingRegistratorFactory>();

    [Fact]
    public void IArgumentExistenceRecorderMappingRegistratorFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IArgumentExistenceRecorderMappingRegistratorFactory>();

    [Fact]
    public void IManagedArgumentDataRecorderMappingRegistratorContextFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IManagedArgumentDataRecorderMappingRegistratorContextFactory>();

    [Fact]
    public void IManagedArgumentExistenceRecorderMappingRegistratorContextFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory>();

    private static void Target(
        IServiceCollection services)
    {
        ManagedRecorderMapperCollectorServices.AddParaminterManagedRecorderMapperCollectors(services);
    }

    private static void ServiceCanBeResolved<TService>()
        where TService : notnull
    {
        HostBuilder host = new();

        host.ConfigureServices(static (services) => Target(services));

        var serviceProvider = host.Build().Services;

        var result = serviceProvider.GetRequiredService<TService>();

        Assert.NotNull(result);
    }
}
