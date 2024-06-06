namespace Paraminter.Recorders.Mappers.Collectors.Managed.ManagedArgumentExistenceRecorderMappingRegistratorContextFactoryCases.ManagedArgumentExistenceRecorderMappingRegistratorContextCases;

using Xunit;

public sealed class RecorderFactory
{
    [Fact]
    public void ReturnsFactory()
    {
        var fixture = ContextFixtureFactory.Create<object, object, object, object>();

        var result = Target(fixture);

        Assert.Same(fixture.RecorderFactoryMock.Object, result);
    }

    private static TRecorderFactory Target<TParameter, TRecord, TParameterFactory, TRecorderFactory>(
        IContextFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory> fixture)
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        return fixture.Sut.RecorderFactory;
    }
}
