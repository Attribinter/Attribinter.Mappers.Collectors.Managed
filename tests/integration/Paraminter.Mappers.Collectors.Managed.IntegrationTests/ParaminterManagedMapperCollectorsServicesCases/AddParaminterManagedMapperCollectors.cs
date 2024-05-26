namespace Paraminter.Mappers.Collectors.Managed.ParaminterMapperCollectorsServicesCases;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Xunit;

public sealed class AddParaminterManagedMapperCollectors
{
    [Fact]
    public void IParameterMappingRegistratorFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IParameterMappingRegistratorFactory>();

    [Fact]
    public void IManagedParameterMappingRegistratorContextFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IManagedParameterMappingRegistratorContextFactory>();

    private static void Target(IServiceCollection services) => ParaminterManagedMapperCollectorsServices.AddParaminterManagedMapperCollectors(services);

    [AssertionMethod]
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
