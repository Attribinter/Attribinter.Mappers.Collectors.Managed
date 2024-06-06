namespace Paraminter.Recorders.Mappers.Collectors.Managed.ArgumentDataRecorderMappingRegistratorFactoryCases;

using Moq;

using System;

using Xunit;

public sealed class Create
{
    private readonly IFactoryFixture Fixture = FactoryFixtureFactory.Create();

    [Fact]
    public void NullManagedRegistrator_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object, object, object, object, object>(null!, Mock.Of<object>(), Mock.Of<object>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullParameterFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<IManagedArgumentDataRecorderMappingRegistrator<object, object, object, object, object>>(), null!, Mock.Of<object>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullRecorderFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<IManagedArgumentDataRecorderMappingRegistrator<object, object, object, object, object>>(), Mock.Of<object>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsRegistrator()
    {
        var result = Target(Mock.Of<IManagedArgumentDataRecorderMappingRegistrator<object, object, object, object, object>>(), Mock.Of<object>(), Mock.Of<object>());

        Assert.NotNull(result);
    }

    private IArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData> Target<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(
        IManagedArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> managedRegistrator,
        TParameterFactory parameterFactory,
        TRecorderFactory recorderFactory)
    {
        return Fixture.Sut.Create(managedRegistrator, parameterFactory, recorderFactory);
    }
}
