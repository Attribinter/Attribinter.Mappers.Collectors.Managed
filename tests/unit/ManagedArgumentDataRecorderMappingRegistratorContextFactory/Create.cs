namespace Paraminter.Recorders.Mappers.Collectors.Managed;

using Moq;

using System;

using Xunit;

public sealed class Create
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NullCollector_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object, object, object, object, object>(null!, Mock.Of<object>(), Mock.Of<object>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullParameterFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object, object, object, object, object>(Mock.Of<IArgumentDataRecorderMappingCollector<object, object, object>>(), null!, Mock.Of<object>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullRecorderFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object, object, object, object, object>(Mock.Of<IArgumentDataRecorderMappingCollector<object, object, object>>(), Mock.Of<object>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsContext()
    {
        var result = Target(Mock.Of<IArgumentDataRecorderMappingCollector<object, object, object>>(), Mock.Of<object>(), Mock.Of<object>());

        Assert.NotNull(result);
    }

    private IManagedArgumentDataRecorderMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> Target<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(
        IArgumentDataRecorderMappingCollector<TParameter, TRecord, TArgumentData> collector,
        TParameterFactory parameterFactory,
        TRecorderFactory recorderFactory)
    {
        return Fixture.Sut.Create(collector, parameterFactory, recorderFactory);
    }
}
