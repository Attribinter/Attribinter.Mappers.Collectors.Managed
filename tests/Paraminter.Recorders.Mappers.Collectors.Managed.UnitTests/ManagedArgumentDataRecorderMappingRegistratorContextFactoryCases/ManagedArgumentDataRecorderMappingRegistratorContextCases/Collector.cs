namespace Paraminter.Recorders.Mappers.Collectors.Managed.ManagedArgumentDataRecorderMappingRegistratorContextFactoryCases.ManagedArgumentDataRecorderMappingRegistratorContextCases;

using Xunit;

public sealed class Collector
{
    [Fact]
    public void ReturnsCollector()
    {
        var fixture = ContextFixtureFactory.Create<object, object, object, object, object>();

        var result = Target(fixture);

        Assert.Same(fixture.CollectorMock.Object, result);
    }

    private static IArgumentDataRecorderMappingCollector<TParameter, TRecord, TArgumentData> Target<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(
        IContextFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> fixture)
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        return fixture.Sut.Collector;
    }
}
