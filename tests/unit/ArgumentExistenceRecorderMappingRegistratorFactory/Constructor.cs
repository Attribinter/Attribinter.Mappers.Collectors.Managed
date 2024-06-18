namespace Paraminter.Recorders.Mappers.Collectors.Managed;

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
        var result = Target(Mock.Of<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory>());

        Assert.NotNull(result);
    }

    private static ArgumentExistenceRecorderMappingRegistratorFactory Target(
        IManagedArgumentExistenceRecorderMappingRegistratorContextFactory contextFactory)
    {
        return new ArgumentExistenceRecorderMappingRegistratorFactory(contextFactory);
    }
}
