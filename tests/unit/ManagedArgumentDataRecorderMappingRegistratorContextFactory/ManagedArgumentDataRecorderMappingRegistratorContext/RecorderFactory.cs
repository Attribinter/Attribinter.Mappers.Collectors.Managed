namespace Paraminter.Recorders.Mappers.Collectors.Managed.ManagedArgumentDataRecorderMappingRegistratorContext;

using Xunit;

public sealed class RecorderFactory
{
    [Fact]
    public void ReturnsFactory()
    {
        var fixture = FixtureFactory.Create<object, object, object, object, object>();

        var result = Target(fixture);

        Assert.Same(fixture.RecorderFactoryMock.Object, result);
    }

    private static TRecorderFactory Target<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(
        IFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> fixture)
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        return fixture.Sut.RecorderFactory;
    }
}
