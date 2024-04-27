namespace Attribinter.Mappers.Collectors.Managed.ManagedParameterMappingRegistratorContextFactoryCases.ManagedParameterMappingRegistratorContextCases;

using Xunit;

public sealed class Collector
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var fixture = ContextFixtureFactory.Create<object, object, object, object, object>();

        var result = Target(fixture);

        Assert.Same(fixture.CollectorMock.Object, result);
    }

    private static IParameterMappingCollector<TParameter, TRecord, TData> Target<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>(IContextFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> fixture)
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        return fixture.Sut.Collector;
    }
}
