namespace Paraminter.Recorders.Mappers.Collectors.Managed.ManagedArgumentDataRecorderMappingRegistratorContext;

using Xunit;

public sealed class ParameterFactory
{
    [Fact]
    public void ReturnsFactory()
    {
        var fixture = FixtureFactory.Create<object, object, object, object, object>();

        var result = Target(fixture);

        Assert.Same(fixture.ParameterFactoryMock.Object, result);
    }

    private static TParameterFactory Target<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(
        IFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> fixture)
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        return fixture.Sut.ParameterFactory;
    }
}
