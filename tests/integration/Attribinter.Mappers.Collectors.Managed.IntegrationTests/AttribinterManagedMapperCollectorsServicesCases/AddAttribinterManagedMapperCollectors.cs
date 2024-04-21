namespace Attribinter.Mappers.Collectors.Managed.AttribinterMapperCollectorsServicesCases;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Moq;

using System;

using Xunit;

public sealed class AddAttribinterManagedMapperCollectors
{
    private static IServiceCollection Target(IServiceCollection services) => AttribinterManagedMapperCollectorsServices.AddAttribinterManagedMapperCollectors(services);

    [Fact]
    public void NullServiceCollection_ArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidServiceCollection_ReturnsSameServiceCollection()
    {
        var serviceCollection = Mock.Of<IServiceCollection>();

        var result = Target(serviceCollection);

        Assert.Same(serviceCollection, result);
    }

    [Fact]
    public void IParameterMappingRegistratorFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IParameterMappingRegistratorFactory>();

    [Fact]
    public void IManagedParameterMappingRegistratorContextFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IManagedParameterMappingRegistratorContextFactory>();

    [AssertionMethod]
    private static void ServiceCanBeResolved<TService>() where TService : notnull
    {
        HostBuilder host = new();

        host.ConfigureServices(static (services) => Target(services));

        var serviceProvider = host.Build().Services;

        var result = serviceProvider.GetRequiredService<TService>();

        Assert.NotNull(result);
    }
}
