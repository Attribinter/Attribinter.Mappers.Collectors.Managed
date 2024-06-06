namespace Paraminter.Recorders.Mappers.Collectors.Managed.ManagedArgumentExistenceRecorderMappingRegistratorContextFactoryCases.ManagedArgumentExistenceRecorderMappingRegistratorContextCases;

using Xunit;

public sealed class ParameterFactory
{
    [Fact]
    public void ReturnsFactory()
    {
        var fixture = ContextFixtureFactory.Create<object, object, object, object>();

        var result = Target(fixture);

        Assert.Same(fixture.ParameterFactoryMock.Object, result);
    }

    private static TParameterFactory Target<TParameter, TRecord, TParameterFactory, TRecorderFactory>(
        IContextFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory> fixture)
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        return fixture.Sut.ParameterFactory;
    }
}
