namespace Paraminter.Recorders.Mappers.Collectors.Managed.ManagedArgumentExistenceRecorderMappingRegistratorContextFactoryCases;

using Moq;

using System;

using Xunit;

public sealed class Create
{
    private readonly IFactoryFixture Fixture = FactoryFixtureFactory.Create();

    [Fact]
    public void NullCollector_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object, object, object, object>(null!, Mock.Of<object>(), Mock.Of<object>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullParameterFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object, object, object, object>(Mock.Of<IArgumentExistenceRecorderMappingCollector<object, object>>(), null!, Mock.Of<object>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullRecorderFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object, object, object, object>(Mock.Of<IArgumentExistenceRecorderMappingCollector<object, object>>(), Mock.Of<object>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsContext()
    {
        var result = Target(Mock.Of<IArgumentExistenceRecorderMappingCollector<object, object>>(), Mock.Of<object>(), Mock.Of<object>());

        Assert.NotNull(result);
    }

    private IManagedArgumentExistenceRecorderMappingRegistratorContext<TParameter, TRecord, TParameterFactory, TRecorderFactory> Target<TParameter, TRecord, TParameterFactory, TRecorderFactory>(
        IArgumentExistenceRecorderMappingCollector<TParameter, TRecord> collector,
        TParameterFactory parameterFactory,
        TRecorderFactory recorderFactory)
    {
        return Fixture.Sut.Create(collector, parameterFactory, recorderFactory);
    }
}
