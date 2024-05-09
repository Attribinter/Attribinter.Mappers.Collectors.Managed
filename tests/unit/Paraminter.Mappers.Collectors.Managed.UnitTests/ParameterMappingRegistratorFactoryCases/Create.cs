namespace Paraminter.Mappers.Collectors.Managed.ParameterMappingRegistratorFactoryCases;

using Moq;

using System;

using Xunit;

public sealed class Create
{
    [Fact]
    public void NullManagedRegistrator_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object, object, object, object, object>(null!, Mock.Of<object>(), Mock.Of<object>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullParameterFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<IManagedParameterMappingRegistrator<object, object, object, object, object>>(), null!, Mock.Of<object>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullRecorderFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<IManagedParameterMappingRegistrator<object, object, object, object, object>>(), Mock.Of<object>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsRegistrator()
    {
        var result = Target(Mock.Of<IManagedParameterMappingRegistrator<object, object, object, object, object>>(), Mock.Of<object>(), Mock.Of<object>());

        Assert.NotNull(result);
    }

    private IParameterMappingRegistrator<TParameter, TRecord, TArgumentData> Target<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(IManagedParameterMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> managedRegistrator, TParameterFactory parameterFactory, TRecorderFactory recorderFactory) => Fixture.Sut.Create(managedRegistrator, parameterFactory, recorderFactory);

    private readonly IFactoryFixture Fixture = FactoryFixtureFactory.Create();
}
