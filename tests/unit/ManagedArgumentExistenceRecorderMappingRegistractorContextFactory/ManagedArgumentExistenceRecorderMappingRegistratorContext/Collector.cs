namespace Paraminter.Recorders.Mappers.Collectors.Managed.ManagedArgumentExistenceRecorderMappingRegistratorContext;

using Xunit;

public sealed class Collector
{
    [Fact]
    public void ReturnsCollector()
    {
        var fixture = FixtureFactory.Create<object, object, object, object>();

        var result = Target(fixture);

        Assert.Same(fixture.CollectorMock.Object, result);
    }

    private static IArgumentExistenceRecorderMappingCollector<TParameter, TRecord> Target<TParameter, TRecord, TParameterFactory, TRecorderFactory>(
        IFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory> fixture)
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        return fixture.Sut.Collector;
    }
}
