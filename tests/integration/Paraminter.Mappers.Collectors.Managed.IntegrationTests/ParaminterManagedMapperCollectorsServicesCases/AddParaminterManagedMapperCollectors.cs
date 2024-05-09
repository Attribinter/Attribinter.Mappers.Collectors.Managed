namespace Paraminter.Mappers.Collectors.Managed.ParaminterMapperCollectorsServicesCases;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Moq;

using System;

using Xunit;

public sealed class AddParaminterManagedMapperCollectors
{
    [Fact]
    public void NullServiceCollection_ArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidServiceCollection_ReturnsSameServiceCollection()
    {
        var services = Mock.Of<IServiceCollection>();

        var result = Target(services);

        Assert.Same(services, result);
    }

    [Fact]
    public void IParameterMappingRegistratorFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IParameterMappingRegistratorFactory>();

    [Fact]
    public void IManagedParameterMappingRegistratorContextFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IManagedParameterMappingRegistratorContextFactory>();

    private static IServiceCollection Target(IServiceCollection services) => ParaminterManagedMapperCollectorsServices.AddParaminterManagedMapperCollectors(services);

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
