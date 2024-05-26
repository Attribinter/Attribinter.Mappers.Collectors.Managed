namespace Paraminter.Mappers.Collectors.Managed.ParaminterMapperCollectorsServicesCases;

using Microsoft.Extensions.DependencyInjection;

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

    private static IServiceCollection Target(IServiceCollection services) => ParaminterManagedMapperCollectorsServices.AddParaminterManagedMapperCollectors(services);
}
