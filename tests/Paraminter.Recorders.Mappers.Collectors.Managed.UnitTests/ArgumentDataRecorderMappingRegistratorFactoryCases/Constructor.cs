namespace Paraminter.Recorders.Mappers.Collectors.Managed.ArgumentDataRecorderMappingRegistratorFactoryCases;

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
        var result = Target(Mock.Of<IManagedArgumentDataRecorderMappingRegistratorContextFactory>());

        Assert.NotNull(result);
    }

    private static ArgumentDataRecorderMappingRegistratorFactory Target(
        IManagedArgumentDataRecorderMappingRegistratorContextFactory contextFactory)
    {
        return new ArgumentDataRecorderMappingRegistratorFactory(contextFactory);
    }
}
