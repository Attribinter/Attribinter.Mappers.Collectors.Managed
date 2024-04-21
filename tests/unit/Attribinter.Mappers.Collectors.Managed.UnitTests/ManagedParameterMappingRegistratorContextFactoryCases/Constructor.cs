namespace Attribinter.Mappers.Collectors.Managed.ManagedParameterMappingRegistratorContextFactoryCases;

using Xunit;

public sealed class Constructor
{
    private static ManagedParameterMappingRegistratorContextFactory Target() => new();

    [Fact]
    public void ReturnsFactory()
    {
        var result = Target();

        Assert.NotNull(result);
    }
}
