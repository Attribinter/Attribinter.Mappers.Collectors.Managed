namespace Paraminter.Recorders.Mappers.Collectors.Managed.ManagedArgumentExistenceRecorderMappingRegistratorContextFactoryCases.ManagedArgumentExistenceRecorderMappingRegistratorContextCases;

using Xunit;

public sealed class Collector
{
    [Fact]
    public void ReturnsCollector()
    {
        var fixture = ContextFixtureFactory.Create<object, object, object, object>();

        var result = Target(fixture);

        Assert.Same(fixture.CollectorMock.Object, result);
    }

    private static IArgumentExistenceRecorderMappingCollector<TParameter, TRecord> Target<TParameter, TRecord, TParameterFactory, TRecorderFactory>(
        IContextFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory> fixture)
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        return fixture.Sut.Collector;
    }
}
