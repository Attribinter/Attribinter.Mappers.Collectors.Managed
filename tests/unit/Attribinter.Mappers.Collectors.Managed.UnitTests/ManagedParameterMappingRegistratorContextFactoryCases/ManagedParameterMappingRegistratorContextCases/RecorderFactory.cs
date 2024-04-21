namespace Attribinter.Mappers.Collectors.Managed.ManagedParameterMappingRegistratorContextFactoryCases.ManagedParameterMappingRegistratorContextCases;

using Xunit;

public sealed class RecorderFactory
{
    private static TRecorderFactory Target<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>(IContextFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> fixture) where TParameterFactory : class where TRecorderFactory : class => fixture.Sut.RecorderFactory;

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var fixture = ContextFixtureFactory.Create<object, object, object, object, object>();

        var result = Target(fixture);

        Assert.Same(fixture.RecorderFactoryMock.Object, result);
    }
}
