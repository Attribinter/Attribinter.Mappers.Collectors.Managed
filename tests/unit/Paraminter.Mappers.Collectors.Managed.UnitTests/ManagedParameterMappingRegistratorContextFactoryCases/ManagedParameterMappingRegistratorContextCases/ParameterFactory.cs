namespace Paraminter.Mappers.Collectors.Managed.ManagedParameterMappingRegistratorContextFactoryCases.ManagedParameterMappingRegistratorContextCases;

using Xunit;

public sealed class ParameterFactory
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var fixture = ContextFixtureFactory.Create<object, object, object, object, object>();

        var result = Target(fixture);

        Assert.Same(fixture.ParameterFactoryMock.Object, result);
    }

    private static TParameterFactory Target<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(IContextFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> fixture)
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        return fixture.Sut.ParameterFactory;
    }
}
