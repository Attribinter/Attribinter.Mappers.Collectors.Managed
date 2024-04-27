namespace Attribinter.Mappers.Collectors.Managed.ParameterMappingRegistratorFactoryCases;

using Moq;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullContextFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidContextFactory_ReturnsFactory()
    {
        var result = Target(Mock.Of<IManagedParameterMappingRegistratorContextFactory>());

        Assert.NotNull(result);
    }

    private static ParameterMappingRegistratorFactory Target(IManagedParameterMappingRegistratorContextFactory contextFactory) => new(contextFactory);
}
