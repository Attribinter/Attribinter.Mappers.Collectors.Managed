namespace Attribinter.Mappers.Collectors.Managed.ManagedParameterMappingRegistratorContextFactoryCases;

using Moq;

using System;

using Xunit;

public sealed class Create
{
    private IManagedParameterMappingRegistratorContext<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> Target<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>(IParameterMappingCollector<TParameter, TRecord, TData> collector, TParameterFactory parameterFactory, TRecorderFactory recorderFactory) => Fixture.Sut.Create(collector, parameterFactory, recorderFactory);

    private readonly IFactoryFixture Fixture = FactoryFixtureFactory.Create();

    [Fact]
    public void NullCollector_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object, object, object, object, object>(null!, Mock.Of<object>(), Mock.Of<object>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullParameterFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object, object, object, object, object>(Mock.Of<IParameterMappingCollector<object, object, object>>(), null!, Mock.Of<object>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullRecorderFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object, object, object, object, object>(Mock.Of<IParameterMappingCollector<object, object, object>>(), Mock.Of<object>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsContext()
    {
        var result = Target(Mock.Of<IParameterMappingCollector<object, object, object>>(), Mock.Of<object>(), Mock.Of<object>());

        Assert.NotNull(result);
    }
}
