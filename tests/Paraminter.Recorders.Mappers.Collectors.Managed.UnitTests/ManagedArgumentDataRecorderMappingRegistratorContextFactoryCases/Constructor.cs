namespace Paraminter.Recorders.Mappers.Collectors.Managed.ManagedArgumentDataRecorderMappingRegistratorContextFactoryCases;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void ReturnsFactory()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private static ManagedArgumentDataRecorderMappingRegistratorContextFactory Target() => new();
}
